using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test_One_to_Many_Popup.Models;

namespace Test_One_to_Many_Popup.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly StudentDbContext _context;

        public CoursesController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
              return _context.Courses != null ? 
                          View(await _context.Courses.ToListAsync()) :
                          Problem("Entity set 'StudentDbContext.Courses'  is null.");
        }
        public async Task<IActionResult>AddOrEdit(int id=0)
        {
            if(id==0)
            {
                return View(new Course());
            }
            else
            {
                var student=await _context.Courses.FindAsync(id);
                if(student==null)
                {
                    return NotFound();
                }
                return View(student);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Course course)
        {
        
            if (id == 0)
            {
                    _context.Add(course);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.Courses.ToList()) });
            }
            else
            {
                if (id != 0)
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.Courses.ToList()) });
                }
                    
            }

            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", course) });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var dep = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(dep);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.viewtostring(this, "_ViewAll",_context.Courses.ToList()) });
        }
    }
}
