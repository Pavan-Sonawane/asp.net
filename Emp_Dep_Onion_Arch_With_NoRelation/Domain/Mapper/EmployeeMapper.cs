using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
{
    public  class EmployeeMapper : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("pk_Emp_Id");
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("integer");
            builder.Property(e => e.EmpName)
                .HasColumnName("Name")
                .HasColumnType("varchar(500)")
                .IsRequired();
            builder.Property(e => e.Location)
                .HasColumnName("location")
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(e => e.City)
                .HasColumnName("City")
                .HasColumnType("Varchar(100)")
                .IsRequired();
            builder.Property(e => e.Profile_Picture)
                .HasColumnName("ProfilePhoto")
                .HasColumnType("varchar(500)");
               

                        
        }

       
    }
}
