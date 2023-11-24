using Employee_CRUD_Store_Procedure_MVC.DbContexts;
using Employee_CRUD_Store_Procedure_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace Employee_CRUD_Store_Procedure_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly MainDbContext _context;

        public StudentController(MainDbContext context)
        {
            _context=context;
        }

        public IActionResult Index()
        {
            var students = _context.students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult InsertStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertStudent(int StuId,string studentName, string address, string email)
        {
            _context.Database.ExecuteSqlRaw("EXEC InsertStudent @StudentID, @StudentName, @Addresss, @Email",
                new SqlParameter("@StudentID", StuId),
                new SqlParameter("@StudentName", studentName),
                new SqlParameter("@Addresss", address),
                new SqlParameter("@Email", email));

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStudent(int studentID)
        {
            var student = _context.students.Find(studentID);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(int studentID, string studentName, string address, string email)
        {
            _context.Database.ExecuteSqlRaw("EXEC UpdateStudent @StudentID, @StudentName, @Addresss, @Email",
                new SqlParameter("@StudentID", studentID),
                new SqlParameter("@StudentName", studentName),
                new SqlParameter("@Addresss", address),
                new SqlParameter("@Email", email)
               );

            return RedirectToAction("Index");
        }

        public IActionResult DeleteStudent(int studentID)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC DeleteStudent @StudentID", new SqlParameter("@StudentID", studentID));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Error");
            }
        }
        
    }
}
