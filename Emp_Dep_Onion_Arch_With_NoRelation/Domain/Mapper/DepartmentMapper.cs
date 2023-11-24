using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
{
    public  class DepartmentMapper:IEntityTypeConfiguration<department>
    {
        public void Configure(EntityTypeBuilder<department> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("pk_Dep_ID");
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(x => x.Department_Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
