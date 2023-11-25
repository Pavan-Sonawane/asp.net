using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace MVC_Project.Models
{
    public class book
    {
        [Key]
        public int bokid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int ISBN { get; set; }
        public string author { get; set; }
        public int version { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
