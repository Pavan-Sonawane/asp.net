using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Course_Enrollment_Student.HelperClass;
using MVC_Course_Enrollment_Student.Models;
using MVC_Course_Enrollment_Student.Models.Context;

namespace MVC_Course_Enrollment_Student.Controllers
{
    public class CourseController : Controller
    {
        private readonly MainDbContext _dbContext;

        public CourseController(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var course = await _dbContext.Courses.ToListAsync();
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Course());
            }
            else
            {
                var emp = await _dbContext.Courses.FindAsync(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return View(emp);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Course_Id,Course_Name,Instructor,Credit")] Course student)
        {

            if (id == 0)
            {
                _dbContext.Courses.Add(student);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                try
                {

                    _dbContext.Update(student);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExist(student.Course_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _dbContext.Courses.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", student) });

        }

        private bool CourseExist(int course_Id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var stud = await _dbContext.Courses.FindAsync(id);
            if (stud != null)
            {
                _dbContext.Remove(stud);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
