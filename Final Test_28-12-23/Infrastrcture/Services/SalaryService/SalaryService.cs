using Domain.Models;
using Domain.ViewModels;
using Infrastrcture.Database;
using Infrastrcture.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrcture.Services.SalaryService
{
    public class SalaryService : ISalaryService
    {
        private readonly IRepository<Salary> _salaryRepository;
        private readonly MainDbconetxt _context;

        public SalaryService(IRepository<Salary> salaryRepository, MainDbconetxt context)
        {
            _salaryRepository = salaryRepository;
            _context = context;
        }

        public async Task<IEnumerable<SalaryViewModel>> GetAllSalaries()
        {
            var salaries = await _salaryRepository.GetAllAsync();
            return salaries.Select(s => new SalaryViewModel
            {
                Id = s.Id,
                EmpId = s.EmpId,
                Amount = s.Amount,
                Date = s.Date,
                Employee = s.Employee
            });
        }

        public async Task<SalaryViewModel> GetSalaryById(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            return new SalaryViewModel
            {
                Id = salary?.Id ?? 0,
                EmpId = salary?.EmpId ?? 0,
                Amount = salary?.Amount ?? 0,
                Date = salary?.Date ?? default,
                Employee = salary?.Employee
            };
        }

        public async Task AddSalary(SalaryInsertModel salaryModel)
        {
            var salary = new Salary
            {
                Id = salaryModel.Id,
                EmpId = salaryModel.EmpId,
                Amount = salaryModel.Amount,
                Date = salaryModel.Date,
               
            };

            await _salaryRepository.AddAsync(salary);
        }

        public async Task UpdateSalary(SalaryInsertModel salaryModel)
        {
            var salary = await _salaryRepository.GetByIdAsync(salaryModel.Id);

            if (salary != null)
            {
                salary.EmpId = salaryModel.EmpId;
                salary.Amount = salaryModel.Amount;
                salary.Date = salaryModel.Date;
               

                await _salaryRepository.UpdateAsync(salary);
            }
        }

        public async Task DeleteSalary(int id)
        {
            await _salaryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SalaryViewModel>> GetSalariesInSalaryRange(int minSalary, int maxSalary)
        {
            var salaries = await _salaryRepository.FindAll(s => s.Amount >= minSalary && s.Amount <= maxSalary);
            return salaries.Select(s => new SalaryViewModel
            {
                Id = s.Id,
                EmpId = s.EmpId,
                Amount = s.Amount,
                Date = s.Date,
                Employee = s.Employee
            });
        }

        /*  public async Task<int> GetDepartmentWiseMonthlySalary(int departmentId, int year)
          {
              var monthlySalaries = await _context.Salaries
                  .Where(s => s.Employee.Department.Id == departmentId && s.Date.Year == year)
                  .GroupBy(s => s.Date.Month)
                  .Select(group => new
                  {
                      Month = group.Key,
                      TotalSalary = group.Sum(s => s.Amount)
                  })
                  .ToListAsync();

              return monthlySalaries.Sum(item => item.TotalSalary);
          }*/
        public async Task<IEnumerable<DepartmentMonthlySalaryViewModel>> GetDepartmentWiseMonthlySalary(int departmentId, int year)
        {
            var departmentMonthlySalaries = await _context.Departments
                .Where(d => d.Id == departmentId)
                .Include(d => d.Employees)
                .ThenInclude(e => e.Salaries)
                .Select(department => new DepartmentMonthlySalaryViewModel
                {
                    DepartmentId = department.Id,
                    DepartmentName = department.Name,
                    MonthlySalaries = department.Employees
                        .SelectMany(e => e.Salaries.Where(s => s.Date.Year == year)
                            .GroupBy(s => s.Date.Month)
                            .Select(group => new MonthlySalaryViewModel
                            {
                                Month = group.Key,
                                TotalSalary = group.Sum(s => s.Amount)
                            }))
                })
                .ToListAsync();

            return departmentMonthlySalaries;
        }





    }
}

