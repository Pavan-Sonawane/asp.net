using System.ComponentModel.DataAnnotations;

namespace departmentrel.Models
{
    public class Department
    {
        [Key] 
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}