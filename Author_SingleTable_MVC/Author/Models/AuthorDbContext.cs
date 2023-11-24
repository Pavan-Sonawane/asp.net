using Microsoft.EntityFrameworkCore;

namespace Author.Models
{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Authors> Authors { get; set; } 
    }
}
