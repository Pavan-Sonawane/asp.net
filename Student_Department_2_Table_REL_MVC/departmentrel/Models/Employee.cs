using System.ComponentModel.DataAnnotations;

namespace departmentrel.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Addr { get; set; }
      
        public Department Department { get; set; }

        public int Department_Id { get; set; }
    }
}
