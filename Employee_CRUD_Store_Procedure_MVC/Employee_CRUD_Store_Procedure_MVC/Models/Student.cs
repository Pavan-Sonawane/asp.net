using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_CRUD_Store_Procedure_MVC.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int StudentID { get; set; }
        public string Student_Name { get; set; }
        public string Addresss { get; set; }
        public string Email { get; set; }
    }
}
