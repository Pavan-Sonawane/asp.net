using Library_Management_Module_MVC_PopUp.HelperClass;
using Library_Management_Module_MVC_PopUp.Models;
using Library_Management_Module_MVC_PopUp.Models.Dbcontext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Module_MVC_PopUp.Controllers
{
    
    public class BookController : Controller
    {
        private readonly MainDbContext _dbContext;

        public BookController(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var course = await _dbContext.Books.ToListAsync();
            return View(course);
        }
        [HttpGet]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Book());
            }
            else
            {
                var emp = await _dbContext.Books.FindAsync(id);
                if (emp == null)
                {
                    return NotFound();
                }
                return View(emp);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("BookID,Title,ISBN")] Book student)
        {

            if (id == 0)
            {
                _dbContext.Books.Add(student);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                try
                {

                    _dbContext.Update(student);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExist(student.BookID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _dbContext.Books.ToListAsync()) });
            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", student) });

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var stud = await _dbContext.Books.FindAsync(id);
            if (stud != null)
            {
                _dbContext.Remove(stud);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        private bool CourseExist(int bookID)
        {
            throw new NotImplementedException();
        }
    }
}
