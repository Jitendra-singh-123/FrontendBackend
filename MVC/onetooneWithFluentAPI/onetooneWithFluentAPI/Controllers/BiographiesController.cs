using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onetooneWithFluentAPI.Data;
using onetooneWithFluentAPI.Models;

namespace onetooneWithFluentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiographiesController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BiographiesController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Biographies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biography>>> GetBiographies()
        {
          if (_context.Biographies == null)
          {
              return NotFound();
          }
            return await _context.Biographies.ToListAsync();
        }

        // GET: api/Biographies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biography>> GetBiography(int id)
        {
          if (_context.Biographies == null)
          {
              return NotFound();
          }
            var biography = await _context.Biographies.FindAsync(id);

            if (biography == null)
            {
                return NotFound();
            }

            return biography;
        }

        // PUT: api/Biographies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiography(int id, Biography biography)
        {
            if (id != biography.Id)
            {
                return BadRequest();
            }

            _context.Entry(biography).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiographyExists(id))
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

        // POST: api/Biographies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Biography>> PostBiography(Biography biography)
        {
          if (_context.Biographies == null)
          {
              return Problem("Entity set 'BookStoreDbContext.Biographies'  is null.");
          }
            _context.Biographies.Add(biography);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiography", new { id = biography.Id }, biography);
        }

        // DELETE: api/Biographies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiography(int id)
        {
            if (_context.Biographies == null)
            {
                return NotFound();
            }
            var biography = await _context.Biographies.FindAsync(id);
            if (biography == null)
            {
                return NotFound();
            }

            _context.Biographies.Remove(biography);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BiographyExists(int id)
        {
            return (_context.Biographies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
