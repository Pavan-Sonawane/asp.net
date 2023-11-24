using Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Orders:BaseEntityClass
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public string TotalAmount { get; set; }

      
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
