﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.EmployeeDbContext;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(EmployeeDb))]
    [Migration("20230824094118_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("Varchar(100)")
                        .HasColumnName("City");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Name");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("location");

                    b.Property<string>("Profile_Picture")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("ProfilePhoto");

                    b.HasKey("Id")
                        .HasName("pk_Emp_Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Domain.Models.department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department_Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("pk_Dep_ID");

                    b.ToTable("department");
                });
#pragma warning restore 612, 618
        }
    }
}
