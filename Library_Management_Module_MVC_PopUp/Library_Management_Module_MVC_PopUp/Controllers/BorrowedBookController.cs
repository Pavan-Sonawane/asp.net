using Library_Management_Module_MVC_PopUp.HelperClass;
using Library_Management_Module_MVC_PopUp.Models;
using Library_Management_Module_MVC_PopUp.Models.Dbcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Module_MVC_PopUp.Controllers
{
    public class BorrowedBookController : Controller
    {
        private readonly MainDbContext _context;

        public BorrowedBookController(MainDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var enrollment = await _context.BorrowedBooks.Include(x => x.User).Include(D => D.Book).ToListAsync();
            return View(enrollment);
        }
/*        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["User_Id"] = new SelectList(_context.Users, "User_Id", "User_Id");
                ViewData["BookID"] = new SelectList(_context.Books, "User_Id", "User_Name");
                return View(new Borrowed_Book());
            }
            else
            {
                var student = await _context.BorrowedBooks.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                ViewData["User_Id"] = new SelectList(_context.Users, "User_Id", "User_Name");
                ViewData["BookID"] = new SelectList(_context.Books, "User_Id", "User_Name");
                return View(student);
            }
        }*/
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                ViewData["UserID"] = new SelectList(_context.Users, "UserID", "User_Name");
                ViewData["BookID"] = new SelectList(_context.Books, "BookID", "Title", "ISBN");
                return View(new Borrowed_Book());
            }
            else
            {
                var student = await _context.BorrowedBooks.FindAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                ViewData["UserID"] = new SelectList(_context.Users, "UserID", "User_Name");
                ViewData["BookID"] = new SelectList(_context.Books, "BookID", "Title", "ISBN");
                return View(student);

            }
        }
        [HttpPost]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("BorrowedID,BookID,UserID,User_Name,BorrowDate,ISBN,Title,ReturnDate")] Borrowed_Book enrollment)
        {
            if (id == 0)
            {
                ViewData["UserID"] = new SelectList(_context.Users, "UserID", "User_Name", enrollment.UserID);
                ViewData["BookID"] = new SelectList(_context.Books, "BookID", "Title", enrollment.BookID);
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
            }
            else
            {
                try
                {
                    ViewData["UserID"] = new SelectList(_context.Users, "UserID", "User_Name", enrollment.UserID);
                    ViewData["BookID"] = new SelectList(_context.Books, "BookID", "Title", enrollment.BookID);
                    _context.BorrowedBooks.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExist(enrollment.BorrowedID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.viewtostring(this, "_ViewAll", _context.BorrowedBooks.ToListAsync()) });

            }
            return Json(new { isValid = false, html = Helper.viewtostring(this, "AddOrEdit", enrollment) });

        }

        private bool EnrollmentExist(object enrollmentId)
        {
            throw new NotImplementedException();
        }
    }
}
