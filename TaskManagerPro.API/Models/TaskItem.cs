using System.ComponentModel.DataAnnotations;

namespace TaskManagerPro.API.Models
{
    public class TaskItem
    {
        public int Id { get; set; }                         // Primary key

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }                   // Task title

        [MaxLength(250)]
        public string? Description { get; set; }            // Optional details

        public DateTime DueDate { get; set; }               // Deadline
        public string Status { get; set; } = "Pending";     // Pending, Completed, etc.
        public int Priority { get; set; }                   // Priority scale (1–5)
        public bool IsComplete => Status != null && Status.Equals("completed", StringComparison.OrdinalIgnoreCase);

    }
}
