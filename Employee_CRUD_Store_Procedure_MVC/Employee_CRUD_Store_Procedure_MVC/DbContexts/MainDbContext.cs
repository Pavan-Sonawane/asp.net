using Employee_CRUD_Store_Procedure_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_CRUD_Store_Procedure_MVC.DbContexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> students { get; set; }
    }
}
