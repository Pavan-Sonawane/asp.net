using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Author.Models;

namespace Author.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorDbContext _context;

        public AuthorsController(AuthorDbContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
              return _context.Authors != null ? 
                          View(await _context.Authors.ToListAsync()) :
                          Problem("Entity set 'AuthorDbContext.Authors'  is null.");
        }
       [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Authors());
            else
            {
                var transactionModel = await _context.Authors.FindAsync(id);
                   return View(transactionModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>AddOrEdit(int id, [Bind("BookID, BookTitle,AuthorName,PageCount,Price,BookType,BookQuantity,Ratings, Date")] Authors transactionModel)
        { 
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    transactionModel.Date = DateTime.Now;
                    _context.Add(transactionModel);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    _context.Update(transactionModel);
                    await _context.SaveChangesAsync();
                }
                
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Authors.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
        }
       
        public async Task<IActionResult> Delete(int? id)
        {
            
            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.BookID == id);
            return View(authors);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Authors.ToList()) });
        }

       
    }
}
