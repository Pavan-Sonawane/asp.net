using Employee_StoreProcedure_2_Table.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_StoreProcedure_2_Table.Context
{
    public class MainDbC : DbContext
    {
        public MainDbC(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }    
        public DbSet<Course> courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);
        }
    }
}
