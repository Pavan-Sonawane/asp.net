using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test_One_to_Many_Popup.Mapper;

namespace Test_One_to_Many_Popup.Models
{
    public class StudentDbContext : IdentityDbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentMapper());
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CourseMapper());
            base.OnModelCreating(builder);
        }
    }
}
