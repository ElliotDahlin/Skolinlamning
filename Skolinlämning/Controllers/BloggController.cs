using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skolinlämning.Data;
using Skolinlämning.Models;
using System.Reflection.Metadata;

namespace Skolinlämning.Controllers
{
    [Authorize]
    public class BloggController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BloggController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Bloggs != null ?
                          View(await _context.Bloggs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Manufacturer'  is null.");
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Content,Author")] BloggPost blogg)
        {
            
            if (ModelState.IsValid)
            {
                blogg.Author = User.Identity.Name; // Sätt författaren till den inloggade användarens namn
                _context.Add(blogg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(blogg);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Bloggs.FindAsync(id);
            if (blogg == null)
            {
                return NotFound();
            }
            return View(blogg);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Content, Author")] BloggPost blogg)
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

        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.IsInRole("Admin")) { return NotFound(); }
            if (id == null)
            {
                return NotFound();
            }

            var blogg = await _context.Bloggs.FirstOrDefaultAsync(m => m.ID == id);
            if (blogg == null)
            {
                return NotFound();
            }

            return View(blogg);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogg = await _context.Bloggs.FindAsync(id);

            if (blogg != null)
            {
                _context.Bloggs.Remove(blogg);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Bloggs.Any(e => e.ID == id);
        }



    }
}
