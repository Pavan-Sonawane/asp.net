using System.ComponentModel.DataAnnotations;

namespace Test_One_to_Many_Popup.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Coursename { get; set; }
        public IList<student> students { get; set; }
    }
}