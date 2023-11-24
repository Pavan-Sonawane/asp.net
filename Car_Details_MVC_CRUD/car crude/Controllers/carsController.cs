using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using car_crude.Data;
using car_crude.Models;

namespace car_crude.Controllers
{
    public class carsController : Controller
    {
        private readonly CarDbContexts _context;

        public carsController(CarDbContexts context)
        {
            _context = context;
        }

        // GET: cars
        public async Task<IActionResult> Index()
        {
              return _context.cars != null ? 
                          View(await _context.cars.ToListAsync()) :
                          Problem("Entity set 'CarDbContexts.cars'  is null.");
        }

        // GET: cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cars == null)
            {
                return NotFound();
            }

            var car = await _context.cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Car_Number,Car_Name,Car_Colour,Company,make")] car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cars == null)
            {
                return NotFound();
            }

            var car = await _context.cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Car_Number,Car_Name,Car_Colour,Company,make")] car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!carExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cars == null)
            {
                return NotFound();
            }

            var car = await _context.cars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cars == null)
            {
                return Problem("Entity set 'CarDbContexts.cars'  is null.");
            }
            var car = await _context.cars.FindAsync(id);
            if (car != null)
            {
                _context.cars.Remove(car);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool carExists(int id)
        {
          return (_context.cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
