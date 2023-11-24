using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseEntity;

namespace Domain.Models
{
    public class Product:BaseEntityClass
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
