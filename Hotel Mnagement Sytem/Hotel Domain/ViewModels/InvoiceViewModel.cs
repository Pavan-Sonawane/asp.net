using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.ViewModels
{
    public class InvoiceViewModel
    {
        public int InvoiceId { get; set; }
        public int ReservationId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string PaymentStatus { get; set; }

      
    }
}
