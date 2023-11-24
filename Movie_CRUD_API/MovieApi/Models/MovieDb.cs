using Microsoft.EntityFrameworkCore;

namespace MovieApi.Models
{
    public class MovieDb : DbContext
    {
        public MovieDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
