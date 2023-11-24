using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test_One_to_Many_Popup.Models;

namespace Test_One_to_Many_Popup.Mapper
{
    public class StudentMapper : IEntityTypeConfiguration<student>
    {

        public void Configure(EntityTypeBuilder<student> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("Pk_Id");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .HasColumnType("INT");

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("Nvarchar(100)")
                .IsRequired();

          /*  builder.Property(x => x.Course)
               .HasColumnName("Course")
               .HasColumnType("Nvarchar(100)")
               .IsRequired();*/

            builder.Property(x => x.Class)
               .HasColumnName("Class")
               .HasColumnType("Nvarchar(100)")
            .IsRequired();

           
             builder.HasOne<Course>(d => d.Course)
             .WithMany(e => e.students)
             .HasForeignKey(f => f.Id)
             .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
