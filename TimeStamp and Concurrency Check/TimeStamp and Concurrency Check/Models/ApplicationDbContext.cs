using Microsoft.EntityFrameworkCore;

namespace TimeStamp_and_Concurrency_Check.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
