using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ANK13Areas.Areas.Yonetim.Data;

namespace ANK13Areas.Areas.Yonetim.Controllers
{
    [Area("Yonetim")]
    public class YoneticiController : Controller
    {
        private readonly UygulamaDbContext _context;

        public YoneticiController(UygulamaDbContext context)
        {
            _context = context;
        }

        // GET: Yonetim/Yonetici
        public async Task<IActionResult> Index()
        {
              return _context.Yonetici != null ? 
                          View(await _context.Yonetici.ToListAsync()) :
                          Problem("Entity set 'UygulamaDbContext.Yonetici'  is null.");
        }

        // GET: Yonetim/Yonetici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yonetici == null)
            {
                return NotFound();
            }

            var yonetici = await _context.Yonetici
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetici == null)
            {
                return NotFound();
            }

            return View(yonetici);
        }

        // GET: Yonetim/Yonetici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yonetim/Yonetici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Soyad,SicilNo")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yonetici);
        }

        // GET: Yonetim/Yonetici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yonetici == null)
            {
                return NotFound();
            }

            var yonetici = await _context.Yonetici.FindAsync(id);
            if (yonetici == null)
            {
                return NotFound();
            }
            return View(yonetici);
        }

        // POST: Yonetim/Yonetici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,SicilNo")] Yonetici yonetici)
        {
            if (id != yonetici.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YoneticiExists(yonetici.Id))
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
            return View(yonetici);
        }

        // GET: Yonetim/Yonetici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yonetici == null)
            {
                return NotFound();
            }

            var yonetici = await _context.Yonetici
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yonetici == null)
            {
                return NotFound();
            }

            return View(yonetici);
        }

        // POST: Yonetim/Yonetici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yonetici == null)
            {
                return Problem("Entity set 'UygulamaDbContext.Yonetici'  is null.");
            }
            var yonetici = await _context.Yonetici.FindAsync(id);
            if (yonetici != null)
            {
                _context.Yonetici.Remove(yonetici);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YoneticiExists(int id)
        {
          return (_context.Yonetici?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
