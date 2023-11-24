using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class OrderViewModels
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string TotalAmount { get; set; }
    }
    public class OrderInsertModels
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string TotalAmount { get; set; }
    }
    public class OrderUpdateModel:OrderInsertModels
    {
        public int Id { get; set; }
    }
}
