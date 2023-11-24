using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Test_One_to_Many_Popup.Models;

namespace Test_One_to_Many_Popup.Controllers
{
    public class studentsController : Controller
    {
        private readonly StudentDbContext _context;

        public studentsController(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var student = await _context.Students.Include(d => d.Course).ToListAsync();
            return View(student);
        }



        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Coursename");
                return View(new student());
            }
            else
            {
                var student= await _context.Students.FindAsync(id);
                if (student== null)
                {
                    return NotFound();
                }
                ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Coursename");
                return View(student);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id,[Bind("Id,Name,Class,CourseID,Coursename")] student student)
        {
           
                if (id == 0)
                {
                    ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Coursename", student.CourseID);
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.Students.ToList()) });
                }
                else
                {
                    if (id != null)
                    {
                        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseId", "Coursename", student.CourseID);
                        _context.Update(student);
                        await _context.SaveChangesAsync();
                        return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.Students.ToList()) });
                    }


                }
            
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", student) });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.viewtostring(this, "_ViewAll", _context.Students.ToList())});
        }
    }
}
