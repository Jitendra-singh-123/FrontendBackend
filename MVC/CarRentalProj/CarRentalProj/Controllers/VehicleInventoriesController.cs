using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRentalProj.Models;

namespace CarRentalProj.Controllers
{
    public class VehicleInventoriesController : Controller
    {
        private readonly CarRentalTempContext _context;

        public VehicleInventoriesController(CarRentalTempContext context)
        {
            _context = context;
        }

        // GET: VehicleInventories
        public async Task<IActionResult> Index()
        {
              return _context.VehicleInventories != null ? 
                          View(await _context.VehicleInventories.ToListAsync()) :
                          Problem("Entity set 'CarRentalTempContext.VehicleInventories'  is null.");
        }

        // GET: VehicleInventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VehicleInventories == null)
            {
                return NotFound();
            }

            var vehicleInventory = await _context.VehicleInventories
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleInventory == null)
            {
                return NotFound();
            }

            return View(vehicleInventory);
        }

        // GET: VehicleInventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,AvailabilityStatus,Maintenance")] VehicleInventory vehicleInventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleInventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleInventory);
        }

        // GET: VehicleInventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VehicleInventories == null)
            {
                return NotFound();
            }

            var vehicleInventory = await _context.VehicleInventories.FindAsync(id);
            if (vehicleInventory == null)
            {
                return NotFound();
            }
            return View(vehicleInventory);
        }

        // POST: VehicleInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,AvailabilityStatus,Maintenance")] VehicleInventory vehicleInventory)
        {
            if (id != vehicleInventory.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleInventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleInventoryExists(vehicleInventory.VehicleId))
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
            return View(vehicleInventory);
        }

        // GET: VehicleInventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VehicleInventories == null)
            {
                return NotFound();
            }

            var vehicleInventory = await _context.VehicleInventories
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleInventory == null)
            {
                return NotFound();
            }

            return View(vehicleInventory);
        }

        // POST: VehicleInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VehicleInventories == null)
            {
                return Problem("Entity set 'CarRentalTempContext.VehicleInventories'  is null.");
            }
            var vehicleInventory = await _context.VehicleInventories.FindAsync(id);
            if (vehicleInventory != null)
            {
                _context.VehicleInventories.Remove(vehicleInventory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleInventoryExists(int id)
        {
          return (_context.VehicleInventories?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        }
    }
}
