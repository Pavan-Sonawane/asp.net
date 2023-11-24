namespace Employee_StoreProcedure_2_Table.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
