using Library_Management_Module_MVC_PopUp.HelperClass;
using Library_Management_Module_MVC_PopUp.Models;
using Library_Management_Module_MVC_PopUp.Models.Dbcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Module_MVC_PopUp.Controllers
{
    public class UserController : Controller
    {
        private readonly MainDbContext _context;

        public UserController(MainDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stud = await _context.Users.ToListAsync();
            return View(stud);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new User());
            }
            else
            {
                var emp = await _context.Users.FirstOrDefaultAsync(x => x.UserID == id);
                if (emp == null)
                {
                    return NotFound();
                }
                return View(emp);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, User student)
        {

            if (id == 0)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                try
                {

                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    if (!StudentExist(student.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.Users.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", student) });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var stud = await _context.Users.FindAsync(id);
            if (stud != null)
            {
                _context.Remove(stud);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        private bool StudentExist(int student_Id)
        {
            throw new NotImplementedException();
        }
        private bool StudentExist(object student_Id)
        {
            throw new NotImplementedException();
        }
    }
}
