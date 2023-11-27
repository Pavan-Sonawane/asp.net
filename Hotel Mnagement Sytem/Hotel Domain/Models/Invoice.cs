using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Domain.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; } 
        public int ReservationId { get; set; } 
        public decimal TotalAmount { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime IssueDate { get; set; }
        [DataType(DataType.DateTime)]
        [Compare("IssueDate", ErrorMessage = "Due date must be after issue date.")]
        public DateTime DueDate { get; set; }
        public string PaymentStatus { get; set; }
        public Reservation Reservation { get; set; }
    }
}
