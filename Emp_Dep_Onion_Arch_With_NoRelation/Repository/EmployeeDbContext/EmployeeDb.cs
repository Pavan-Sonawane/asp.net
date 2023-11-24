using Domain.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EmployeeDbContext
{
    public  class EmployeeDb:DbContext
    {
        public EmployeeDb(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMapper());
            modelBuilder.ApplyConfiguration(new DepartmentMapper());
            base.OnModelCreating(modelBuilder);
        }

    }
}
