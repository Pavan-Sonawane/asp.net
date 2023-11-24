using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test_One_to_Many_Popup.Models
{
    public class student
    {
        [Key]
        [Required]
        public int Id { get; set; } 
        [DisplayName("Student Name")]
        [Required (ErrorMessage ="Enter the Name")]
        public string Name { get; set; }
        [DisplayName("Student Class")]
        [Required (ErrorMessage ="Enter the Class of the student")]
        public string Class { get; set; }
        public Course Course { get; set; }
        public int CourseID { get; set; }

    }

  
}
