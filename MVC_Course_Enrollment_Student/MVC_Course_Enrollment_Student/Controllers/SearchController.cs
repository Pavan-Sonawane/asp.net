using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Course_Enrollment_Student.Models.Context;
using System.Text.Json.Serialization;

namespace MVC_Course_Enrollment_Student.Controllers
{
    public class SearchController : Controller
    {
        private readonly MainDbContext _Context;

        public SearchController(MainDbContext context)
        {
            _Context=context;
        }

        public IActionResult CoursesByFirstName(string firstName)
        {
            firstName = firstName.ToLower();

            var enrolledCourses = _Context.Enrollments
                .Where(e => e.Student.First_Name.ToLower().Contains(firstName))
                .Select(e => e.Course)
                .ToList();

            return View("CoursesByFirstName", enrolledCourses);
        }

        public IActionResult GetStudentByEnrollmentId(int enrollmentId)
        {
            var enrollment = _Context.Enrollments
                .Include(e => e.Student)
                .FirstOrDefault(e => e.EnrollmentId == enrollmentId);

            if (enrollment != null)
            {
                return View(enrollment.Student);
            }
            else
            {
                ViewBag.Message = "No student found for the provided EnrollmentId.";
                return View("NotFound");
            }
        }

        public IActionResult GetStudentEnrollmentDates(int studentId)
        {
            var student = _Context.Students
                .Include(s => s.Enrollments)
                .FirstOrDefault(s => s.Student_Id == studentId);

            if (student != null)
            {
                var enrollmentDates = student.Enrollments
                    .Select(e => e.DateOfEnrollment)
                    .ToList();

                return View(enrollmentDates);
            }
            else
            {
                ViewBag.Message = "No student found for the provided StudentId.";
                return View("NotFound");
            }
        }


    }
}
