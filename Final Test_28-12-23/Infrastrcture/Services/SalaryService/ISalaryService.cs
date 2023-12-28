using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.SalaryService
{
    public interface ISalaryService
    {
        Task<IEnumerable<SalaryViewModel>> GetAllSalaries();
        Task<SalaryViewModel> GetSalaryById(int id);
        Task AddSalary(SalaryInsertModel salaryModel);
        Task UpdateSalary(SalaryInsertModel salaryModel);
        Task DeleteSalary(int id);
        Task<IEnumerable<SalaryViewModel>> GetSalariesInSalaryRange(int minSalary, int maxSalary);
        Task<IEnumerable<DepartmentMonthlySalaryViewModel>> GetDepartmentWiseMonthlySalary(int departmentId, int year);
    }
}
