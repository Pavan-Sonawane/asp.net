using Microsoft.AspNetCore.Mvc;
using Student_One__to_Many.Models;

namespace Student_One__to_Many.Controllers
{
    public class SearchController : Controller
    {
        private readonly StudentDbC _context;

        public SearchController(StudentDbC context)
        {
            _context = context;
        }

        public ActionResult Index(string query)
        {
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            if (!string.IsNullOrEmpty(query))
            {
                Student student = _context.Students.FirstOrDefault(s => s.Student_Name == query);
                if (student != null)
                {
                    students.Add(student);
                    courses = _context.Courses.Where(c => c.Course_Id == student.Course_Id).ToList();
                }
                else
                {
                    courses = _context.Courses.Where(c => c.CourseName.Contains(query)).ToList();
                    foreach (var course in courses)
                    {
                        students.AddRange(_context.Students.Where(s => s.Course_Id == course.Course_Id).ToList());
                    }
                }
            }
            else
            {
                students = _context.Students.ToList();
                courses = _context.Courses.ToList();
            }

            var results = new SearchResultViewModel
            {
                Students = students,
                Courses = courses
            };

            return View(results);
        }
    }
}
