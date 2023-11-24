using Microsoft.EntityFrameworkCore;

namespace sports.Models
{
    public class DbContextcs : DbContext
    {
        public DbContextcs(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Game>Games { get; set; }
    }
}
