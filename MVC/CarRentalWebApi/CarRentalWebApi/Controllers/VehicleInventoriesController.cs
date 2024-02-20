using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalWebApi.Models;

namespace CarRentalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleInventoriesController : ControllerBase
    {
        private readonly CarRentalSystemWebContext _context;

        public VehicleInventoriesController(CarRentalSystemWebContext context)
        {
            _context = context;
        }

        // GET: api/VehicleInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleInventory>>> GetVehicleInventories()
        {
          if (_context.VehicleInventories == null)
          {
              return NotFound();
          }
            return await _context.VehicleInventories.ToListAsync();
        }

        // GET: api/VehicleInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleInventory>> GetVehicleInventory(int id)
        {
          if (_context.VehicleInventories == null)
          {
              return NotFound();
          }
            var vehicleInventory = await _context.VehicleInventories.FindAsync(id);

            if (vehicleInventory == null)
            {
                return NotFound();
            }

            return vehicleInventory;
        }

        // PUT: api/VehicleInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleInventory(int id, VehicleInventory vehicleInventory)
        {
            if (id != vehicleInventory.VehicleId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleInventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehicleInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VehicleInventory>> PostVehicleInventory(VehicleInventory vehicleInventory)
        {
          if (_context.VehicleInventories == null)
          {
              return Problem("Entity set 'CarRentalSystemWebContext.VehicleInventories'  is null.");
          }
            _context.VehicleInventories.Add(vehicleInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleInventory", new { id = vehicleInventory.VehicleId }, vehicleInventory);
        }

        // DELETE: api/VehicleInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleInventory(int id)
        {
            if (_context.VehicleInventories == null)
            {
                return NotFound();
            }
            var vehicleInventory = await _context.VehicleInventories.FindAsync(id);
            if (vehicleInventory == null)
            {
                return NotFound();
            }

            _context.VehicleInventories.Remove(vehicleInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleInventoryExists(int id)
        {
            return (_context.VehicleInventories?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        }
    }
}
