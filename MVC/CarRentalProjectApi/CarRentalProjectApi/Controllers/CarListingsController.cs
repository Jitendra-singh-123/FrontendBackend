using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalProjectApi.Models;

namespace CarRentalProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarListingsController : ControllerBase
    {
        private readonly RoadReadyContext _context;

        public CarListingsController(RoadReadyContext context)
        {
            _context = context;
        }

        // GET: api/CarListings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarListing>>> GetCarListings()
        {
          if (_context.CarListings == null)
          {
              return NotFound();
          }
            return await _context.CarListings.ToListAsync();
        }

        // GET: api/CarListings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarListing>> GetCarListing(int id)
        {
          if (_context.CarListings == null)
          {
              return NotFound();
          }
            var carListing = await _context.CarListings.FindAsync(id);

            if (carListing == null)
            {
                return NotFound();
            }

            return carListing;
        }

        // PUT: api/CarListings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarListing(int id, CarListing carListing)
        {
            if (id != carListing.CarId)
            {
                return BadRequest();
            }

            _context.Entry(carListing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarListingExists(id))
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

        // POST: api/CarListings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarListing>> PostCarListing(CarListing carListing)
        {
          if (_context.CarListings == null)
          {
              return Problem("Entity set 'RoadReadyContext.CarListings'  is null.");
          }
            _context.CarListings.Add(carListing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarListing", new { id = carListing.CarId }, carListing);
        }

        // DELETE: api/CarListings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarListing(int id)
        {
            if (_context.CarListings == null)
            {
                return NotFound();
            }
            var carListing = await _context.CarListings.FindAsync(id);
            if (carListing == null)
            {
                return NotFound();
            }

            _context.CarListings.Remove(carListing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarListingExists(int id)
        {
            return (_context.CarListings?.Any(e => e.CarId == id)).GetValueOrDefault();
        }
    }
}
