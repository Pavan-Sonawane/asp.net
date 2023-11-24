using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Course_Enrollment_Student.HelperClass;
using MVC_Course_Enrollment_Student.Models;
using MVC_Course_Enrollment_Student.Models.Context;
using System.Text;

namespace MVC_Course_Enrollment_Student.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly MainDbContext _context;

        public EnrollmentController( MainDbContext context)
        {
            _context=   context;
        }
        public async Task<IActionResult> Index()
        {
            var enrollment=await _context.Enrollments.Include(x => x.Student).Include(D=>D.Course).ToListAsync();
            return View(enrollment);
        }

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            { 
                ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id", "First_Name");
                ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "Course_Name");
                return View(new Enrollment());
            }
            else
            {
                var student = await _context.Enrollments.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id", "First_Name");
                ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "Course_Name");
                return View(student);

            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("EnrollmentId,Course_Id,Student_Id,DateOfEnrollment,First_Name")]Enrollment enrollment)
        {
            if(id==0)
            {
                ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id,First_Name,Last_Name,DOB,Address");
                ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id,Course_Name,Instructor,Credit");
                _context.Add(enrollment); 
                await _context.SaveChangesAsync();
            }
            else
            {
                try
                {
                    ViewData["Student_Id"] = new SelectList(_context.Students, "Student_Id,First_Name,Last_Name,DOB,Address");
                    ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id,Course_Name,Instructor,Credit");
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExist(enrollment.EnrollmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.Enrollments.ToListAsync()) });

            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", enrollment) });

        }
        public async Task<IActionResult>Delete(int id)
        {
            var enrol = await _context.Enrollments.Include(d => d.Student).Include(d => d.Course).FirstOrDefaultAsync(d => d.EnrollmentId == id);
            _context.Enrollments.Remove(enrol);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.viewtostring(this, "_ViewAll", enrol) });
        }

        private bool EnrollmentExist(int enrollmentId)
        {
            throw new NotImplementedException();
        }
    }
}
