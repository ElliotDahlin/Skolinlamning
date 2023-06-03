using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skolinlämning.Data;
using Skolinlämning.Models;
using System.Reflection.Metadata;

namespace Skolinlämning.Controllers
{
    public class BloggController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloggController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Bloggs.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content")] BloggPost blogg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogg);
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Bloggs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] BloggPost blogg)
        {
            if (id != blogg.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blogg.ID))
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
            return View(blogg);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Bloggs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (blogg == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: Blogg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogg = await _context.Bloggs.FindAsync(id);
            _context.Bloggs.Remove(blogg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Bloggs.Any(e => e.ID == id);
        }
    }
}
