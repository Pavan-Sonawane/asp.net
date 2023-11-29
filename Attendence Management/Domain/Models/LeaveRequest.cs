using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveID { get; set; }
        public int UserID { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

       
        public User User { get; set; }

        public LeaveApproval LeaveApproval { get; set; }
    }
}
