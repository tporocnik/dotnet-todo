using Microsoft.EntityFrameworkCore;

namespace Todo
{
    public class TodoDbContext : DbContext
    {

        // The DbSet property will tell the Entity Framework that we have a table that needs to be created
        public virtual DbSet<Task> Tasks { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        // On model creating function will provide us with the ability to manage the tables properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}