using departmentrel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace departmentrel.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbContexts _context;

        public EmployeeController(DbContexts context)
        {
            _context=context;
        }

        public async Task<IActionResult> Index()
        {
            var details = _context.Employees.Include(e => e.Department);
            return View(await details.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult>Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Employee_Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);

        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Department_Id"] = new SelectList(_context.Department, "Department_Id", "Department_Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int id, [Bind("Employee_Id,Employee_Name,Employee_Addr,Department_Id")] Employee employee)
        {
            if (id != null)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["Department_Id"] = new SelectList(_context.Department, "Department_Id", "Department_Name", employee.Department_Id);
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult>Edit(int? id)
        {
            if(id == null || _context.Employees==null) 
            {
            return NotFound();
            }
            var employee = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Employee_Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["Department_Id"] = new SelectList(_context.Department, "Department_Id", "Department_Name", employee.Department_Id);
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id,Employee employee)
        {
            if(id != null)
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Deparment_Id"]=new SelectList(_context.Department,"Department_Id","Department_Name",employee.Department_Id);
            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult>Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Employee_Id == id);
            if(employee != null)
            {
                return View(employee);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
