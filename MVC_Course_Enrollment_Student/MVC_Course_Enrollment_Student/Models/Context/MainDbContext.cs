using Microsoft.EntityFrameworkCore;

namespace MVC_Course_Enrollment_Student.Models.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasOne(d => d.Student)
                .WithMany(d => d.Enrollments)
                .HasForeignKey(d => d.Student_Id)
                .IsRequired();

            modelBuilder.Entity<Enrollment>()
                .HasOne(d => d.Course)
                .WithMany(d => d.Enrollments)
                .HasForeignKey(d => d.Course_Id)
                .IsRequired();

        }
    }
}
