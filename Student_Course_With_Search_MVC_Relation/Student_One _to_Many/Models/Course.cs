using System.ComponentModel.DataAnnotations;

namespace Student_One__to_Many.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }
        public string CourseName { get; set; }
        public ICollection<Student>students { get; set; }
    }
}
