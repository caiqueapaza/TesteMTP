using Microsoft.EntityFrameworkCore;
using TesteMTP.Model;

namespace TesteMTP.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TaskModel> T_TASK { get; set; }
    }
}
