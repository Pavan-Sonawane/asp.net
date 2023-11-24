using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVC_Course_Enrollment_Student.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required(ErrorMessage = "Student ID is required.")]
        public int Student_Id { get; set; }
             
        [Required(ErrorMessage = "Course ID is required.")]
        public int Course_Id { get; set; }

        [Required(ErrorMessage = "Date of Enrollment is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfEnrollment { get; set; }

        [JsonIgnore]
        public Student Student { get; set; }

        [JsonIgnore]
        public Course Course { get; set; }

    }
}
