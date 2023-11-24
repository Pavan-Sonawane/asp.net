using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Student_One__to_Many.Models
{
    public class StudentDbC : DbContext
    {
        public StudentDbC(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<Course>(e=>e.Course)
                .WithMany(e=>e.students)
                .HasForeignKey(e=>e.Course_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
