using Microsoft.EntityFrameworkCore;

namespace MVC_Project.Models.Db
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<book> books { get; set; }
    }
}
