using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string YearOfPurchase { get; set; }
        public string ExpectedPrice { get; set; }
        public string CarCompany { get; set; }
        public string KilometerDriven { get; set; }
        public string OwnerType { get; set; }

    }
    public class CarInsertModel
    {
        public string Name { get; set; }
        public string YearOfPurchase { get; set; }
        public string ExpectedPrice { get; set; }
        public string CarCompany { get; set; }
        public string KilometerDriven { get; set; }
        public string OwnerType { get; set; }
    }
    public class CarUpdateModel:CarInsertModel
    {
        public int Id { get; set; }
    }
}
