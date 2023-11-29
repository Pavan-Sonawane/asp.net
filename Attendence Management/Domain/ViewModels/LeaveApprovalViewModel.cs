using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class LeaveApprovalViewModel
    {
      
        public int ApprovalID { get; set; }
        public int LeaveID { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime ApprovalDateTime { get; set; }
        public string Comments { get; set; }

       
        public List<LeaveRequestViewModel> LeaveRequests { get; set; }
    }

}

