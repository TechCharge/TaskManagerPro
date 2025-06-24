using System.ComponentModel.DataAnnotations;

namespace TaskManagerPro.API.Dtos
{
    public class TaskItemDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string? Status { get; set; }

        public int? Priority { get; set; }

        public bool IsComplete { get; set; }
    }
}
