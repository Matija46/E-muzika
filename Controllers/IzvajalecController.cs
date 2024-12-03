using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class IzvajalecController : Controller
    {
        private readonly EmuzikaContext _context;

        public IzvajalecController(EmuzikaContext context)
        {
            _context = context;
        }

        // GET: Izvajalec
        public async Task<IActionResult> Index()
        {
            return View(await _context.Izvajalci.ToListAsync());
        }

        // GET: Izvajalec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izvajalec = await _context.Izvajalci
                .FirstOrDefaultAsync(m => m.ID == id);
            if (izvajalec == null)
            {
                return NotFound();
            }

            return View(izvajalec);
        }

        // GET: Izvajalec/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Izvajalec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Opis,poslusalci")] Izvajalec izvajalec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(izvajalec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(izvajalec);
        }

        // GET: Izvajalec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izvajalec = await _context.Izvajalci.FindAsync(id);
            if (izvajalec == null)
            {
                return NotFound();
            }
            return View(izvajalec);
        }

        // POST: Izvajalec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Opis,poslusalci")] Izvajalec izvajalec)
        {
            if (id != izvajalec.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(izvajalec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IzvajalecExists(izvajalec.ID))
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
            return View(izvajalec);
        }

        // GET: Izvajalec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izvajalec = await _context.Izvajalci
                .FirstOrDefaultAsync(m => m.ID == id);
            if (izvajalec == null)
            {
                return NotFound();
            }

            return View(izvajalec);
        }

        // POST: Izvajalec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var izvajalec = await _context.Izvajalci.FindAsync(id);
            if (izvajalec != null)
            {
                _context.Izvajalci.Remove(izvajalec);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IzvajalecExists(int id)
        {
            return _context.Izvajalci.Any(e => e.ID == id);
        }
    }
}
