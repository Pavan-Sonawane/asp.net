using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class Employee:BaseEntity
    {
        public string EmpName { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Profile_Picture { get; set; }
    }
}
