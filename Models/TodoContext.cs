using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TaskOrder> TaskOrders { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<FarmEvent> FarmEvents { get; set; }
        public DbSet<TaskOrderTarget> TaskOrderTargets { get; set; }
    }

    
}