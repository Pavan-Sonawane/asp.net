using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Student_One__to_Many.Models;

namespace Student_One__to_Many.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbC _context;

        public StudentController(StudentDbC context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var details = _context.Students.Include(e => e.Course);
            return View(await details.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(e => e.Course).FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "CourseName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, [Bind("Id,Student_Name, Student_Email, Student_Phone, Student_City, Course_Id,CourseName")]Student student)
        {
            if(id != null)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "CourseName", student.Course_Id);
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(e => e.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "CourseName", student.Course_Id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Student student)
        {
            if (id != null)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["Course_Id"] = new SelectList(_context.Courses, "Course_Id", "CourseName", student.Course_Id);
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.Include(e => e.Course).FirstOrDefaultAsync(e => e.Id == id);
            if(student!= null)
            {
                return View(student);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult>Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if(student!=null)
            {
                _context.Remove(student);
                await _context.SaveChangesAsync();
                
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchName)
        {
            if (string.IsNullOrEmpty(searchName))
            {
                ViewBag.ErrorMessage = "Please enter a search term.";
                return View("Index", await _context.Students.Include(e => e.Course).ToListAsync());
            }

            var students = _context.Students
                .Include(e => e.Course)
                .Where(s => s.Student_Name.ToLower().Contains(searchName.ToLower()));

            return View("Index", await students.ToListAsync());
        }
        public IActionResult SomeAction()
        {
            return View("Index", model: null); // Use "null" as the model to indicate no layout.
        }
    }

}

