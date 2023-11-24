
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreProcedure2.Models;

namespace StoreProcedure2.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        internal void CreateEmployee(Employee employee)
        {
            var employeeName = new SqlParameter("@EmployeeName", employee.EmployeeName);
            var jobRole = new SqlParameter("@Job_Role", employee.Job_Role);
            var email = new SqlParameter("@Email", employee.Email);
            var mobileNum = new SqlParameter("@Mobile_Num", employee.Mobile_Num);
            var salary = new SqlParameter("@Salary", employee.Salary);

            Database.ExecuteSqlRaw("CreateEmployee @EmployeeName, @Job_Role, @Email, @Mobile_Num, @Salary",
                employeeName, jobRole, email, mobileNum, salary);
        }

        public void UpdateEmployee(Employee employee)
        {
            var employeeId = new SqlParameter("@EmployeeId", employee.EmployeeId);
            var employeeName = new SqlParameter("@EmployeeName", employee.EmployeeName);
            var jobRole = new SqlParameter("@Job_Role", employee.Job_Role);
            var email = new SqlParameter("@Email", employee.Email);
            var mobileNum = new SqlParameter("@Mobile_Num", employee.Mobile_Num);
            var salary = new SqlParameter("@Salary", employee.Salary);

            Database.ExecuteSqlRaw("UpdateEmployee @EmployeeId, @EmployeeName, @Job_Role, @Email, @Mobile_Num, @Salary",
                employeeId, employeeName, jobRole, email, mobileNum, salary);
        }

        public void DeleteEmployee(int id)
        {
            var employeeId = new SqlParameter("@EmployeeId", id);

            Database.ExecuteSqlRaw("DeleteEmployee @EmployeeId", employeeId);
        }
        public List<Employee> SearchEmployees(string employeeName, string salary, string jobRole)
        {
            var employeeNameParam = new SqlParameter("@EmployeeName", (object)employeeName ?? DBNull.Value);
            var salaryParam = new SqlParameter("@Salary", (object)salary ?? DBNull.Value);
            var jobRoleParam = new SqlParameter("@Job_Role", (object)jobRole ?? DBNull.Value);

            var searchResults = Employees.FromSqlRaw("EXECUTE SearchEmployees @EmployeeName, @Salary, @Job_Role",
                employeeNameParam, salaryParam, jobRoleParam).ToList();

            return searchResults;
        }
    }
   
       
}
