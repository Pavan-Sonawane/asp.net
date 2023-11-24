using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVC_Course_Enrollment_Student.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }

        [Required(ErrorMessage = "Course Name is required.")]
        [StringLength(100, ErrorMessage = "Course Name cannot exceed 100 characters.")]
        public string Course_Name { get; set; }

        [Required(ErrorMessage = "Instructor name is required.")]
        [StringLength(50, ErrorMessage = "Instructor name cannot exceed 50 characters.")]
        public string Instructor { get; set; }

        [Range(0.5, 10.0, ErrorMessage = "Credit must be between 0.5 and 10.0")]
        public double Credit { get; set; }

        [JsonIgnore]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    
}
