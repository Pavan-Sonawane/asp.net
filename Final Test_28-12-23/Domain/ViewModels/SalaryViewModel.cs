using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class SalaryViewModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public Employee Employee { get; set; }
    }

    public class SalaryInsertModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
    public class DepartmentMonthlySalaryViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<MonthlySalaryViewModel> MonthlySalaries { get; set; }
    }

    public class MonthlySalaryViewModel
    {
        public int Month { get; set; }
        public decimal TotalSalary { get; set; }
    }

}
