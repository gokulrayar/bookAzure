using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookAs.models;

namespace bookAs.Controllers
{
    public class BookstoresController : Controller
    {
        private readonly BookrayarContext _context;

        public BookstoresController(BookrayarContext context)
        {
            _context = context;
        }

        // GET: Bookstores
        public async Task<IActionResult> Index()
        {
              return _context.Bookstores != null ? 
                          View(await _context.Bookstores.ToListAsync()) :
                          Problem("Entity set 'BookrayarContext.Bookstores'  is null.");
        }

        // GET: Bookstores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookstores == null)
            {
                return NotFound();
            }

            var bookstore = await _context.Bookstores
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookstore == null)
            {
                return NotFound();
            }

            return View(bookstore);
        }

        // GET: Bookstores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookstores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,PublisherName,Address,AuthorId,BookName,BookCategory,Price")] Bookstore bookstore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookstore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookstore);
        }

        // GET: Bookstores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookstores == null)
            {
                return NotFound();
            }

            var bookstore = await _context.Bookstores.FindAsync(id);
            if (bookstore == null)
            {
                return NotFound();
            }
            return View(bookstore);
        }

        // POST: Bookstores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,PublisherName,Address,AuthorId,BookName,BookCategory,Price")] Bookstore bookstore)
        {
            if (id != bookstore.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookstore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookstoreExists(bookstore.BookId))
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
            return View(bookstore);
        }

        // GET: Bookstores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookstores == null)
            {
                return NotFound();
            }

            var bookstore = await _context.Bookstores
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookstore == null)
            {
                return NotFound();
            }

            return View(bookstore);
        }

        // POST: Bookstores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookstores == null)
            {
                return Problem("Entity set 'BookrayarContext.Bookstores'  is null.");
            }
            var bookstore = await _context.Bookstores.FindAsync(id);
            if (bookstore != null)
            {
                _context.Bookstores.Remove(bookstore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookstoreExists(int id)
        {
          return (_context.Bookstores?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
