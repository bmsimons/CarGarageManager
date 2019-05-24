using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarGarageManager.Models;

namespace CarGarageManager.Controllers
{
    public class ModelController : Controller
    {
        private readonly CarGarageManagerContext _context;

        public ModelController(CarGarageManagerContext context)
        {
            _context = context;
        }

        // GET: Model
        public async Task<IActionResult> Index()
        {
            var carGarageManagerContext = _context.CarModel.Include(c => c.CarBrand);
            return View(await carGarageManagerContext.ToListAsync());
        }

        // GET: Model/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .Include(c => c.CarBrand)
                .FirstOrDefaultAsync(m => m.CarModelID == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // GET: Model/Create
        public IActionResult Create()
        {
            ViewData["CarBrandFK"] = new SelectList(_context.CarBrand, "CarBrandID", "CarBrandName");
            return View();
        }

        // POST: Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarModelID,CarBrandFK,CarModelName")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarBrandFK"] = new SelectList(_context.CarBrand, "CarBrandID", "CarBrandName", carModel.CarBrandFK);
            return View(carModel);
        }

        // GET: Model/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }
            ViewData["CarBrandFK"] = new SelectList(_context.CarBrand, "CarBrandID", "CarBrandName", carModel.CarBrandFK);
            return View(carModel);
        }

        // POST: Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarModelID,CarBrandFK,CarModelName")] CarModel carModel)
        {
            if (id != carModel.CarModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelExists(carModel.CarModelID))
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
            ViewData["CarBrandFK"] = new SelectList(_context.CarBrand, "CarBrandID", "CarBrandName", carModel.CarBrandFK);
            return View(carModel);
        }

        // GET: Model/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carModel = await _context.CarModel
                .Include(c => c.CarBrand)
                .FirstOrDefaultAsync(m => m.CarModelID == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // POST: Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carModel = await _context.CarModel.FindAsync(id);
            _context.CarModel.Remove(carModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelExists(int id)
        {
            return _context.CarModel.Any(e => e.CarModelID == id);
        }
    }
}
