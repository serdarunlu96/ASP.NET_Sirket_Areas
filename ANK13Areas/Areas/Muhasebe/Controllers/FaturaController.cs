using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANK13Areas.Areas.Muhasebe.Data;

namespace ANK13Areas.Areas.Muhasebe.Controllers
{
    [Area("Muhasebe")]
    public class FaturaController : Controller
    {
        private readonly UygulamaDbContext _context;

        public FaturaController(UygulamaDbContext context)
        {
            _context = context;
        }

        // GET: Muhasebe/Fatura
        public async Task<IActionResult> Index()
        {
              return _context.Fatura != null ? 
                          View(await _context.Fatura.ToListAsync()) :
                          Problem("Entity set 'UygulamaDbContext.Fatura'  is null.");
        }

        // GET: Muhasebe/Fatura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fatura == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // GET: Muhasebe/Fatura/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Muhasebe/Fatura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tutar,Odenen,Odeyen")] Fatura fatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fatura);
        }

        // GET: Muhasebe/Fatura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fatura == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura.FindAsync(id);
            if (fatura == null)
            {
                return NotFound();
            }
            return View(fatura);
        }

        // POST: Muhasebe/Fatura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tutar,Odenen,Odeyen")] Fatura fatura)
        {
            if (id != fatura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaturaExists(fatura.Id))
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
            return View(fatura);
        }

        // GET: Muhasebe/Fatura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fatura == null)
            {
                return NotFound();
            }

            var fatura = await _context.Fatura
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fatura == null)
            {
                return NotFound();
            }

            return View(fatura);
        }

        // POST: Muhasebe/Fatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fatura == null)
            {
                return Problem("Entity set 'UygulamaDbContext.Fatura'  is null.");
            }
            var fatura = await _context.Fatura.FindAsync(id);
            if (fatura != null)
            {
                _context.Fatura.Remove(fatura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaturaExists(int id)
        {
          return (_context.Fatura?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
