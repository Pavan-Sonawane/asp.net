using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LeaveApproval
    {
        [Key]
        public int ApprovalID { get; set; }
        public int LeaveID { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime ApprovalDateTime { get; set; }
        public string Comments { get; set; }

        public LeaveRequest LeaveRequest { get; set; }
    }
}
