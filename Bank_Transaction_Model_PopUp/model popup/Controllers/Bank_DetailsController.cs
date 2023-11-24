using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using model_popup.Models;

namespace model_popup.Controllers
{
    public class Bank_DetailsController : Controller
    {
        private readonly BankContext _context;

        public Bank_DetailsController(BankContext context)
        {
            _context = context;
        }

        // GET: Bank_Details
        public async Task<IActionResult> Index()
        {
              return _context.Details != null ? 
                          View(await _context.Details.ToListAsync()) :
                          Problem("Entity set 'BankContext.Details'  is null.");
        }

        // GET: Bank_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           var detils=_context.Details.Include(e=>e.Transaction_Id).ToList();
            return View(Details);
        }

        // GET: Bank_Details/Create
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new Bank_Details());
            else
            {
                var transactionModel = _context.Details.Find(id);
                return View(transactionModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit(int id, [Bind("Transaction_Id, Account_number,IFSC_Code,Mobile_Number,Zip_code,Name_of_customer")] Bank_Details transactionModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    _context.Add(transactionModel);
                    _context.SaveChanges();
                }
                //Update
                else
                {
                    _context.Update(transactionModel);
                    _context.SaveChanges();
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Details.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddorEdit", transactionModel) });
        }

        // GET: Bank_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Details == null)
            {
                return NotFound();
            }

            var bank_Details = await _context.Details
                .FirstOrDefaultAsync(m => m.Transaction_Id == id);
            if (bank_Details == null)
            {
                return NotFound();
            }

            return View(bank_Details);
        }

        // POST: Bank_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Details == null)
            {
                return Problem("Entity set 'BankContext.Details'  is null.");
            }
            var bank_Details = await _context.Details.FindAsync(id);
            if (bank_Details != null)
            {
                _context.Details.Remove(bank_Details);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
