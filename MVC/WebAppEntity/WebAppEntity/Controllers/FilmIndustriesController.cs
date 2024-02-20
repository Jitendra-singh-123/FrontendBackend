using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppEntity.Data;
using WebAppEntity.Models;

namespace WebAppEntity.Controllers
{
    public class FilmIndustriesController : Controller
    {
        private readonly WebAppEntityContext _context;

        public FilmIndustriesController(WebAppEntityContext context)
        {
            _context = context;
        }

        // GET: FilmIndustries
        public async Task<IActionResult> Index()
        {
              return _context.FilmIndustry != null ? 
                          View(await _context.FilmIndustry.ToListAsync()) :
                          Problem("Entity set 'WebAppEntityContext.FilmIndustry'  is null.");
        }

        // GET: FilmIndustries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FilmIndustry == null)
            {
                return NotFound();
            }

            var filmIndustry = await _context.FilmIndustry
                .FirstOrDefaultAsync(m => m.MId == id);
            if (filmIndustry == null)
            {
                return NotFound();
            }

            return View(filmIndustry);
        }

        // GET: FilmIndustries/Create
        public IActionResult Create()
        {
            return View(new FilmIndustry());
        }

        // POST: FilmIndustries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MId,MName,StarCast,Producer,Director,ReleaseDate")] FilmIndustry filmIndustry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmIndustry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filmIndustry);
        }

        // GET: FilmIndustries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FilmIndustry == null)
            {
                return NotFound();
            }

            var filmIndustry = await _context.FilmIndustry.FindAsync(id);
            if (filmIndustry == null)
            {
                return NotFound();
            }
            return View(filmIndustry);
        }

        // POST: FilmIndustries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MId,MName,StarCast,Producer,Director,ReleaseDate")] FilmIndustry filmIndustry)
        {
            if (id != filmIndustry.MId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmIndustry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmIndustryExists(filmIndustry.MId))
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
            return View(filmIndustry);
        }

        // GET: FilmIndustries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FilmIndustry == null)
            {
                return NotFound();
            }

            var filmIndustry = await _context.FilmIndustry
                .FirstOrDefaultAsync(m => m.MId == id);
            if (filmIndustry == null)
            {
                return NotFound();
            }

            return View(filmIndustry);
        }

        // POST: FilmIndustries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FilmIndustry == null)
            {
                return Problem("Entity set 'WebAppEntityContext.FilmIndustry'  is null.");
            }
            var filmIndustry = await _context.FilmIndustry.FindAsync(id);
            if (filmIndustry != null)
            {
                _context.FilmIndustry.Remove(filmIndustry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmIndustryExists(int id)
        {
          return (_context.FilmIndustry?.Any(e => e.MId == id)).GetValueOrDefault();
        }
    }
}
