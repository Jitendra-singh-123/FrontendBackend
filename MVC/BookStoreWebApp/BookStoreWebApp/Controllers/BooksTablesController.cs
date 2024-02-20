using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Controllers
{
    public class BooksTablesController : Controller
    {
        private readonly DatabaseFirstApproachContext _context;

        public BooksTablesController(DatabaseFirstApproachContext context)
        {
            _context = context;
        }

        // GET: BooksTables
        public async Task<IActionResult> Index()
        {
            var databaseFirstApproachContext = _context.BooksTables.Include(b => b.BcategoryNavigation);
            return View(await databaseFirstApproachContext.ToListAsync());
        }

        // GET: BooksTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BooksTables == null)
            {
                return NotFound();
            }

            var booksTable = await _context.BooksTables
                .Include(b => b.BcategoryNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booksTable == null)
            {
                return NotFound();
            }

            return View(booksTable);
        }

        // GET: BooksTables/Create
        public IActionResult Create()
        {
            ViewData["Bcategory"] = new SelectList(_context.Categories, "Cid", "Cid");
            return View();
        }

        // POST: BooksTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Author,Bcategory")] BooksTable booksTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booksTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Bcategory"] = new SelectList(_context.Categories, "Cid", "Cid", booksTable.Bcategory);
            return View(booksTable);
        }

        // GET: BooksTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BooksTables == null)
            {
                return NotFound();
            }

            var booksTable = await _context.BooksTables.FindAsync(id);
            if (booksTable == null)
            {
                return NotFound();
            }
            ViewData["Bcategory"] = new SelectList(_context.Categories, "Cid", "Cid", booksTable.Bcategory);
            return View(booksTable);
        }

        // POST: BooksTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Author,Bcategory")] BooksTable booksTable)
        {
            if (id != booksTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booksTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksTableExists(booksTable.Id))
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
            ViewData["Bcategory"] = new SelectList(_context.Categories, "Cid", "Cid", booksTable.Bcategory);
            return View(booksTable);
        }

        // GET: BooksTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BooksTables == null)
            {
                return NotFound();
            }

            var booksTable = await _context.BooksTables
                .Include(b => b.BcategoryNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booksTable == null)
            {
                return NotFound();
            }

            return View(booksTable);
        }

        // POST: BooksTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BooksTables == null)
            {
                return Problem("Entity set 'DatabaseFirstApproachContext.BooksTables'  is null.");
            }
            var booksTable = await _context.BooksTables.FindAsync(id);
            if (booksTable != null)
            {
                _context.BooksTables.Remove(booksTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksTableExists(int id)
        {
          return (_context.BooksTables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
