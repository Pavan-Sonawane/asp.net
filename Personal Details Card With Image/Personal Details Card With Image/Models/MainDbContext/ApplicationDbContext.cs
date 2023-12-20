using Microsoft.EntityFrameworkCore;

namespace Personal_Details_Card_With_Image.Models.MainDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
