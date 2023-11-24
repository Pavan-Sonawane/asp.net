using departmentrel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace departmentrel.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DbContexts _context;

        public DepartmentController(DbContexts context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Department != null ?
                View(await _context.Department.ToListAsync()) : Problem("Department is null");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                var department = await _context.Department.FirstOrDefaultAsync(e => e.Department_Id == id);
                return View(department);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public  IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department Department, int id)
        {
            if(id !=null)
            {
                _context.Add(Department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Department);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null|| _context.Department==null) 
            {
                return NotFound();
            }
            var department = await _context.Department.FindAsync(id);
            if(department == null) 
            {
                return NotFound();
            }
            return View(department );
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id ,Department department)
        {
            if (id != null)
            {
                _context.Department.Update(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            if (id == null)
            {
                return NotFound();  
            }
            var department=await _context.Department.FindAsync(id);
            if(department != null)
            {
                _context.Department.Remove(department);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
            

    }
}
