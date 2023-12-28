using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public Employee Employee { get; set; }
    }
}
