using System.ComponentModel.DataAnnotations;

namespace Student_One__to_Many.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Student_Name { get; set; }
        public string Student_Email { get; set; }
        public string Student_Phone { get; set; }
        public string Student_City { get; set; }
        public Course Course { get; set;}
        public int Course_Id { get; set; }
    }
}
    