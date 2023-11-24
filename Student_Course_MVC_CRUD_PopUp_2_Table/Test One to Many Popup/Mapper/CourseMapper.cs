using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test_One_to_Many_Popup.Models;

namespace Test_One_to_Many_Popup.Mapper
{
    public class CourseMapper : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.CourseID)
                .HasName("PK_CourseID");

            builder.Property(x =>x.CourseID)
                .ValueGeneratedOnAdd()
                .HasColumnName("CourseID")
                .HasColumnType("INT");

            builder.Property(x => x.Coursename)
              .HasColumnName("Coursename")
              .HasColumnType("Nvarchar(100)")
              .IsRequired();
        }
    }
}
