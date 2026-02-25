using Microsoft.EntityFrameworkCore;
using task_manager_api.Models;

namespace TaskManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        //public DbSet<User> Users => Set<User>();
        //public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<User> Users {  get; set; }
        public DbSet<TaskItem> Tasks {get; set; }
    }
}