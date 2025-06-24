using Microsoft.EntityFrameworkCore;
using TaskManagerPro.API.Models;

namespace TaskManagerPro.API.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<TaskItem> Tasks { get; set; }
    }
}