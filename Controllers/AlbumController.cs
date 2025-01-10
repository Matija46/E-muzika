using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly EmuzikaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public AlbumController(EmuzikaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Album
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var albumi = from a in _context.Albumi
                        select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                albumi = albumi.Where(a => a.Ime.Contains(searchString) || a.Opis.Contains(searchString));
            }

            return View(await albumi.ToListAsync());
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albumi
                .Include(a => a.Pesmi)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (album == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _usermanager.GetUserAsync(User);
                var playlists = await _context.Playlist
                    .Where(p => p.Owner == currentUser)
                    .ToListAsync();
                ViewBag.Playlists = playlists;
            }

            return View(album);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Opis,DatumIzdaje")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albumi.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Opis,DatumIzdaje")] Album album)
        {
            if (id != album.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.ID))
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
            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albumi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albumi.FindAsync(id);
            if (album != null)
            {
                _context.Albumi.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albumi.Any(e => e.ID == id);
        }
    }
}
