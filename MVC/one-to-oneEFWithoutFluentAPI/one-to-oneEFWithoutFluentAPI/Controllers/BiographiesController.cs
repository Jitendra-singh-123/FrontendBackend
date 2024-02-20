using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using one_to_oneEFWithoutFluentAPI.Data;
using one_to_oneEFWithoutFluentAPI.Models;

namespace one_to_oneEFWithoutFluentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiographiesController : ControllerBase
    {
        private readonly one_to_oneEFWithoutFluentAPIContext _context;

        public BiographiesController(one_to_oneEFWithoutFluentAPIContext context)
        {
            _context = context;
        }

        // GET: api/Biographies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biography>>> GetBiography()
        {
          if (_context.Biography == null)
          {
              return NotFound();
          }
            return await _context.Biography.ToListAsync();
        }

        // GET: api/Biographies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biography>> GetBiography(int id)
        {
          if (_context.Biography == null)
          {
              return NotFound();
          }
            var biography = await _context.Biography.FindAsync(id);

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
            if (id != biography.BioId)
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
          if (_context.Biography == null)
          {
              return Problem("Entity set 'one_to_oneEFWithoutFluentAPIContext.Biography'  is null.");
          }
            _context.Biography.Add(biography);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiography", new { id = biography.BioId }, biography);
        }

        // DELETE: api/Biographies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiography(int id)
        {
            if (_context.Biography == null)
            {
                return NotFound();
            }
            var biography = await _context.Biography.FindAsync(id);
            if (biography == null)
            {
                return NotFound();
            }

            _context.Biography.Remove(biography);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BiographyExists(int id)
        {
            return (_context.Biography?.Any(e => e.BioId == id)).GetValueOrDefault();
        }
    }
}
