using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_One__to_Many.Models;

namespace Student_One__to_Many.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentDbC _context;

        public CourseController(StudentDbC context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Courses != null ?
                View(await _context.Courses.ToListAsync()) : Problem("Department is null");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Add(Course course,int id)
        {
            if (id!= null)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var department = await _context.Courses.FirstOrDefaultAsync(e => e.Course_Id == id);
                return View(department);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }
            var department = await _context.Courses.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Course department)
        {
            if (id != null)
            {
                _context.Courses.Update(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Courses.FindAsync(id);
            if (department != null)
            {
                _context.Courses.Remove(department);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
    }

}
