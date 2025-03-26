using Microsoft.EntityFrameworkCore;

namespace Assignment.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }
        public DbSet<Models.User> Users { get; set; }

        public DbSet<Models.TaskItem> Tasks { get; set; }

    }
}
