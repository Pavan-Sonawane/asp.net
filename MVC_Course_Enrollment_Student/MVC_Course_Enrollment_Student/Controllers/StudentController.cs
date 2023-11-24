using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Course_Enrollment_Student.HelperClass;
using MVC_Course_Enrollment_Student.Models;
using MVC_Course_Enrollment_Student.Models.Context;

namespace MVC_Course_Enrollment_Student.Controllers
{
    public class StudentController : Controller
    {
        private readonly MainDbContext _context;

        public StudentController(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stud = await _context.Students.ToListAsync();
            return View(stud);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Student());
            }
            else
            {
                var emp = await _context.Students.FirstOrDefaultAsync(x => x.Student_Id == id);
                if (emp == null)
                {
                    return NotFound();
                }
                return View(emp);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Student student)
        {

            if (id == 0)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                try
                {

                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!StudentExist(student.Student_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.Students.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", student) });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var stud = await _context.Students.FindAsync(id);
            if (stud != null)
            {
                _context.Remove(stud);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        private bool StudentExist(int student_Id)
        {
            throw new NotImplementedException();
        }
    }
}
