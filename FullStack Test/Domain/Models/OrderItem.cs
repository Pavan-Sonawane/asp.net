using Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItem:BaseEntityClass
    {
        [Key]
        public int OrderItemId { get; set; }

        
        public int OrderId { get; set; }

       
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

       
        public Orders Order { get; set; }

        
        public Product Product { get; set; }
    }
}
