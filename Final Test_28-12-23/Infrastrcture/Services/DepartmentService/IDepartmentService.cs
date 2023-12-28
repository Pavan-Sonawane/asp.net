using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentViewModel>> GetAllDepartments();
        Task<DepartmentViewModel> GetDepartmentById(int id);
        Task AddDepartment(DepartmentInsertModel departmentModel);
        Task UpdateDepartment(int id,DepartmentUpdateModel departmentModel);
        Task DeleteDepartment(int id);
    }
}
