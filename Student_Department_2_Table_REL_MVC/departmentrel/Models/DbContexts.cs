using Microsoft.EntityFrameworkCore;

namespace departmentrel.Models
{
    public class DbContexts : DbContext
    {
        public DbContexts(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(e => e.employees)
                .HasForeignKey(e => e.Department_Id)
                .OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
