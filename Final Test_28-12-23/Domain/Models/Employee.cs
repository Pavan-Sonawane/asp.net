using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Employee : IdentityUser<int>
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int DeptId { get; set; }

        public ICollection<Salary> Salaries { get; set; }
        public Department Department { get; set; }
    }
}
