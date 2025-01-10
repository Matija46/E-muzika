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
    public class PesemController : Controller
    {
        private readonly EmuzikaContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public PesemController(EmuzikaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Pesem
        public async Task<IActionResult> Index(string searchString)
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _usermanager.GetUserAsync(User);

                if (currentUser == null)
                {
                    return Unauthorized();
                }

                var playlists = await _context.Playlist
                    .Where(p => p.Owner.Id == currentUser.Id)
                    .ToListAsync();

                ViewBag.Playlists = playlists;
            }

            var pesmiQuery = _context.Pesmi
                .Include(p => p.Album)
                .Include(p => p.izvajalecPesems)
                .ThenInclude(ip => ip.izvajalec)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                pesmiQuery = pesmiQuery.Where(p => p.Naslov.Contains(searchString) ||
                                                p.Album.Ime.Contains(searchString) ||
                                                p.izvajalecPesems.Any(ip => ip.izvajalec.Ime.Contains(searchString)));
            }

            var pesmi = await pesmiQuery.ToListAsync();

            ViewData["CurrentFilter"] = searchString;

            return View(pesmi);
        }



        // GET: Pesem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesem = await _context.Pesmi
                .Include(p => p.Album)
                .Include(p => p.izvajalecPesems)
                .ThenInclude(ip => ip.izvajalec)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (pesem == null)
            {
                return NotFound();
            }

            return View(pesem);
        }

        // GET: Pesem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pesem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naslov,Album,Dolzina,Ocena")] Pesem pesem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pesem);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int pesemId)
        {
            var currentUser = await _usermanager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Unauthorized();
            }

            var playlist = await _context.Playlist
                .Include(p => p.playlistSongs)
                .FirstOrDefaultAsync(p => p.ID == playlistId && p.Owner.Id == currentUser.Id);

            if (playlist == null)
            {
                return NotFound();
            }

            var pesem = await _context.Pesmi.FindAsync(pesemId);
            if (pesem == null)
            {
                return NotFound();
            }

            if (!playlist.playlistSongs.Any(ps => ps.PesemID == pesemId))
            {
                playlist.playlistSongs.Add(new PlaylistSong
                {
                    PlaylistID = playlistId,
                    PesemID = pesemId
                });

                playlist.DateEdited = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Pesem");
        }


        // GET: Pesem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesem = await _context.Pesmi.FindAsync(id);
            if (pesem == null)
            {
                return NotFound();
            }
            return View(pesem);
        }

        // POST: Pesem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naslov,Album,Dolzina,Ocena")] Pesem pesem)
        {
            if (id != pesem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesemExists(pesem.ID))
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
            return View(pesem);
        }

        // GET: Pesem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesem = await _context.Pesmi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pesem == null)
            {
                return NotFound();
            }

            return View(pesem);
        }

        // POST: Pesem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pesem = await _context.Pesmi.FindAsync(id);
            if (pesem != null)
            {
                _context.Pesmi.Remove(pesem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesemExists(int id)
        {
            return _context.Pesmi.Any(e => e.ID == id);
        }
    }
}
