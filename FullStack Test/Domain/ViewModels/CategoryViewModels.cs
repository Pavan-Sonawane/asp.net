using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class CategoryViewModels
    {
       
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryInsertModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryUpdateModel:CategoryInsertModel
    {
        public int Id { get; set; }
    }
}
