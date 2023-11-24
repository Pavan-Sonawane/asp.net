using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreProcedure2.Context;
using StoreProcedure2.Models;

namespace StoreProcedure2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MainDbContext _context;

        public EmployeeController(MainDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Employees.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _context.CreateEmployee(employee);

            return RedirectToAction("Index");
        }
        public IActionResult UpdateEmployee(int id)
        {
           
            Employee employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound(); 
            }

            return View(employee); 
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _context.UpdateEmployee(employee);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public IActionResult DeleteEmployee(int id)
        {
            _context.DeleteEmployee(id);

            return RedirectToAction("Index");
        }
        public IActionResult SearchEmployees(string employeeName, string salary, string jobRole)
        {
            var searchResults = _context.SearchEmployees(employeeName, salary, jobRole);

            return View(searchResults);
        }

    }
}
