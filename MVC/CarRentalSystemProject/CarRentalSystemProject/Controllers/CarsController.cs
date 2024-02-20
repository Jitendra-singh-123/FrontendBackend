using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalSystemProject.Data;
using CarRentalSystemProject.Models;

namespace CarRentalSystemProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRentalSystemProjectContext _context;

        public CarsController(CarRentalSystemProjectContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var carRentalSystemProjectContext = _context.Car.Include(c => c.Location).Include(c => c.Model).Include(c => c.Type);
            return View(await carRentalSystemProjectContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Location)
                .Include(c => c.Model)
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id");
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Id");
            ViewData["TypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Id");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegistrationNumber,ModelId,TypeId,LocationId")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", car.LocationId);
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Id", car.ModelId);
            ViewData["TypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Id", car.TypeId);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", car.LocationId);
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Id", car.ModelId);
            ViewData["TypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Id", car.TypeId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegistrationNumber,ModelId,TypeId,LocationId")] Car car)
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
                    if (!CarExists(car.Id))
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
            ViewData["LocationId"] = new SelectList(_context.Set<Location>(), "Id", "Id", car.LocationId);
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Id", car.ModelId);
            ViewData["TypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Id", car.TypeId);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Location)
                .Include(c => c.Model)
                .Include(c => c.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Car == null)
            {
                return Problem("Entity set 'CarRentalSystemProjectContext.Car'  is null.");
            }
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
          return (_context.Car?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
