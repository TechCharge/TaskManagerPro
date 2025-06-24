using System.ComponentModel.DataAnnotations;

namespace TaskManagerPro.API.Dtos
{
    public class UpdateTaskDto
    {
        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string? Status { get; set; }

        public int? Priority { get; set; }
    }
}