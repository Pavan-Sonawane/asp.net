using car_crude.Models;
using Microsoft.EntityFrameworkCore;

namespace car_crude.Data
{
    public class CarDbContexts : DbContext
    {
        public CarDbContexts(DbContextOptions options) : base(options)
        {

        }
        public DbSet<car> cars { get; set; } 
    }
}
