using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerPro.API.Data;
using TaskManagerPro.API.Dtos;
using TaskManagerPro.API.Models;

namespace TaskManagerPro.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TasksController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks(
            [FromQuery] string? status, 
            [FromQuery] bool? isComplete,
            [FromQuery] string? sortBy,
            [FromQuery] string? order,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.Tasks.AsQueryable();

            // Filter by status
            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(t => t.Status != null && t.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by completion status
            if (isComplete.HasValue)
            {
                query = query.Where(t => t.IsComplete == isComplete.Value);
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                bool descending = order != null && order.Equals("desc", StringComparison.OrdinalIgnoreCase);

                string normalizedSortBy = sortBy.Trim().ToLowerInvariant();

                query = normalizedSortBy switch
                {
                    "duedate" => descending ? query.OrderByDescending(t => t.DueDate) : query.OrderBy(t => t.DueDate),
                    "priority" => descending ? query.OrderByDescending(t => t.Priority) : query.OrderBy(t => t.Priority),
                    "title" => descending ? query.OrderByDescending(t => t.Title) : query.OrderBy(t => t.Title),
                    _ => query
                };
            }

            // Pagination
            int totalTasks = await query.CountAsync();
            var tasks = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<TaskItemDto>>(tasks);

            return Ok(new
            {
                page,
                pageSize,
                totalTasks,
                totalPages = (int)Math.Ceiling(totalTasks / (double)pageSize),
                tasks = result
            });
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            TaskItem? task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }
            else
            {
                return Ok(_mapper.Map<TaskItemDto>(task));
            }
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> CreateTask(CreateTaskDto dto)
        {
            var task = _mapper.Map<TaskItem>(dto);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TaskItemDto>(task);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, result);
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID in URL must match ID in body.");
            }

            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            _mapper.Map(dto, task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            TaskItem? task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchTask(int id, [FromBody] PatchTaskDto dto)
        {
            if (dto.Title == null && dto.Description == null && dto.DueDate == null && dto.Status == null && dto.Priority == null)
            {
                return BadRequest("No fields were provided to update.");
            }

            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            _mapper.Map(dto, task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
