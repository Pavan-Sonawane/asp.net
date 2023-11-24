using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.HelperFolder;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly MainDbContext _dbContext;
        public EmployeeController(MainDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> Index()
        {
            var emp = await _dbContext.Employees.Include(d => d.department).Include(d => d.Country).Include(d => d.State).Include(c => c.City).ToListAsync();
            return View(emp);
        }

        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Countries = _dbContext.Countries.ToList();
                ViewBag.States = _dbContext.Statements.ToList();
                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName");
                ViewData["StateId"] = new SelectList(_dbContext.Statements, "StateId", "StateName");
                ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName");
                ViewData["Dept_Id"] = new SelectList(_dbContext.Departments, "Dept_Id", "Department_Name");

                return View(new Employee());
            }
            else
            {
                var emp = await _dbContext.Employees.FindAsync(id);
                if (emp == null)
                {
                    return NotFound();
                }
                ViewBag.Countries = _dbContext.Countries.ToList();
                ViewBag.States = _dbContext.Statements.ToList();
                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName");

                ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName");

                ViewData["StateId"] = new SelectList(_dbContext.Statements, "StateId", "StateName");

                ViewData["Dept_Id"] = new SelectList(_dbContext.Departments, "Dept_Id", "Department_Name");
                return View(emp);
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("EmpId", "Emp_Name", "mobno", "Dept_Id", "Department_Name", "CountryId", "CountryName", "StateId", "StateName", "CityId", "CityName")] Employee employee)
        {
            if (id == 0)
            {
                ViewData["CountryId"] = new SelectList(_dbContext.Countries, "CountryId", "CountryName", employee.CountryId);
                ViewData["StateId"] = new SelectList(_dbContext.Statements, "StateId", "StateName", employee.StateId);
                ViewData["CityId"] = new SelectList(_dbContext.Cities, "CityId", "CityName", employee.CityId);
                ViewData["Dept_Id"] = new SelectList(_dbContext.Departments, "Dept_Id", "Department_Name", employee.Dept_Id);
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                var existingEmployee = await _dbContext.Employees.FindAsync(id);
                if (existingEmployee != null)
                {
                    existingEmployee.Emp_Name = employee.Emp_Name;
                    existingEmployee.mobno = employee.mobno;
                    existingEmployee.Dept_Id = employee.Dept_Id;
                    existingEmployee.CountryId = employee.CountryId;
                    existingEmployee.StateId = employee.StateId;
                    existingEmployee.CityId = employee.CityId;
                    _dbContext.Update(existingEmployee);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }

            var updatedEmployees = await _dbContext.Employees
                .Include(d => d.department)
                .Include(d => d.Country)
                .Include(d => d.State)
                .Include(c => c.City)
                .ToListAsync();

            var updatedHtml = Helper.RenderRazorViewToString(this, "_ViewAll", updatedEmployees);

            return Json(new { isValid = true, html = updatedHtml });
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var emp = await _dbContext.Employees.Include(d => d.department).FirstOrDefaultAsync(x => x.Emp_Id == id);
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", emp) });


        }
        [HttpGet]
        public JsonResult GetCitiesByState(int stateId)
        {
            var cities = _dbContext.Cities.Where(c => c.StateId == stateId).ToList();
            return Json(cities);
        }

        [HttpGet]
        public JsonResult GetStatesByCountry(int countryId)
        {
            var states = _dbContext.Statements.Where(s => s.CountryId == countryId).ToList();
            return Json(states);
        }

    }
}
