using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.Employee_Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeViewModels>> GetAllEmployees();
        Task<EmployeeViewModels> GetEmployeeById(int id);
        Task AddEmployee(EmployeeInsertModels employeeModel);
        Task UpdateEmployee(EmployeeInsertModels employeeModel);
        Task DeleteEmployee(int id);
        /*        Task<IEnumerable<EmployeeViewModels>> SearchEmployeesByName(string employeeName);
        */
        Task<IEnumerable<EmployeeViewModels>> SearchEmployeesByNameAsync(string name);

    }

}
