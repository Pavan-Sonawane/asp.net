using Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Category:BaseEntityClass
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        
        public ICollection<Product> Products { get; set; }
    }
}

