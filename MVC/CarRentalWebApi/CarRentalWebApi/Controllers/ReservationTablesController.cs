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
    public class ReservationTablesController : ControllerBase
    {
        private readonly CarRentalSystemWebContext _context;

        public ReservationTablesController(CarRentalSystemWebContext context)
        {
            _context = context;
        }

        // GET: api/ReservationTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationTable>>> GetReservationTables()
        {
          if (_context.ReservationTables == null)
          {
              return NotFound();
          }
            return await _context.ReservationTables.ToListAsync();
        }

        // GET: api/ReservationTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationTable>> GetReservationTable(int id)
        {
          if (_context.ReservationTables == null)
          {
              return NotFound();
          }
            var reservationTable = await _context.ReservationTables.FindAsync(id);

            if (reservationTable == null)
            {
                return NotFound();
            }

            return reservationTable;
        }

        // PUT: api/ReservationTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationTable(int id, ReservationTable reservationTable)
        {
            if (id != reservationTable.ReservationId)
            {
                return BadRequest();
            }

            _context.Entry(reservationTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationTableExists(id))
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

        // POST: api/ReservationTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationTable>> PostReservationTable(ReservationTable reservationTable)
        {
          if (_context.ReservationTables == null)
          {
              return Problem("Entity set 'CarRentalSystemWebContext.ReservationTables'  is null.");
          }
            _context.ReservationTables.Add(reservationTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationTable", new { id = reservationTable.ReservationId }, reservationTable);
        }

        // DELETE: api/ReservationTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationTable(int id)
        {
            if (_context.ReservationTables == null)
            {
                return NotFound();
            }
            var reservationTable = await _context.ReservationTables.FindAsync(id);
            if (reservationTable == null)
            {
                return NotFound();
            }

            _context.ReservationTables.Remove(reservationTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationTableExists(int id)
        {
            return (_context.ReservationTables?.Any(e => e.ReservationId == id)).GetValueOrDefault();
        }
    }
}
