using Library_Management_Module_MVC_PopUp.Models;
using Library_Management_Module_MVC_PopUp.Models.Dbcontext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Module_MVC_PopUp.Controllers
{
    public class UniversalSearchController : Controller
    {
        private readonly MainDbContext _context;

        public UniversalSearchController(MainDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*  public IActionResult Search(string searchTerm)
          {

              searchTerm = searchTerm.ToLower();

              var borrowedBooks = _context.BorrowedBooks
                  .Include(bb => bb.Book)
                  .Include(bb => bb.User)
                  .Where(bb => bb.Book.Title.ToLower().Contains(searchTerm))
                  .ToList();

              return View(borrowedBooks);
          }*/

        public IActionResult UniversalSearch(string searchType, string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            switch (searchType)
            {
                case "ByTitle":
                    var borrowedBooksByTitle = _context.BorrowedBooks
                        .Include(bb => bb.Book)
                        .Include(bb => bb.User)
                        .Where(bb => bb.Book.Title.ToLower().Contains(searchTerm))
                        .ToList();

                    return View("Search", borrowedBooksByTitle);

                case "ByUser":
                    if (int.TryParse(searchTerm, out int userId))
                    {
                        var borrowedBooksByUser = _context.BorrowedBooks
                            .Where(b => b.UserID == userId)
                            .Select(b => b.Book)
                            .ToList();

                        return View("BooksTakenByUser", borrowedBooksByUser);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                case "ByUserId":
                    if (int.TryParse(searchTerm, out int userIdForDate))
                    {
                        var borrowedDatesByUser = _context.BorrowedBooks
                            .Where(b => b.UserID == userIdForDate)
                            .Select(b =>b.BorrowDate)
                            
                            .ToList();

                        return View("BorrowedDatesByUser", borrowedDatesByUser);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                    

                default:
                    return RedirectToAction("Index");
            }
        }


    }
}

