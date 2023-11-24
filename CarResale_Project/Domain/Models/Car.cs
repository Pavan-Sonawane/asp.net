using Domain.BaseEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Car:BaseClass
    {
      
        public string Name { get; set; }
        public string YearOfPurchase { get; set; }
        public string ExpectedPrice { get; set; }
        public string CarCompany { get; set; }
        public string KilometerDriven { get; set; }
        public string OwnerType { get; set; }
       
    }
}
