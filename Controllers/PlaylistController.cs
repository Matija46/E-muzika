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
    [Authorize]
    public class PlaylistController : Controller
    {
        private readonly EmuzikaContext _context;

        private readonly UserManager<ApplicationUser> _usermanager;

        public PlaylistController(EmuzikaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Playlist
        public async Task<IActionResult> Index()
        {
            // Get the currently logged-in user
            var currentUser = await _usermanager.GetUserAsync(User);

            if (currentUser == null)
            {
                return Unauthorized();
            }

            // Filter playlists based on the current user
            var playlists = await _context.Playlist
                .Where(p => p.Owner.Id == currentUser.Id)
                .ToListAsync();

            return View(playlists);
        }

        // GET: Playlist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // GET: Playlist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Playlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("ID,Ime,Opis")] Playlist playlist)
{
    var currentUser = await _usermanager.GetUserAsync(User);

    if (currentUser == null)
    {
        ModelState.AddModelError("", "User must be logged in to create a playlist.");
        return View(playlist);
    }

    playlist.DateCreated = DateTime.Now;
    playlist.DateEdited = DateTime.Now;
    playlist.Owner = currentUser;
    playlist.playlistSongs = new List<PlaylistSong>();
ModelState.Remove(nameof(playlist.Owner));
    ModelState.Remove(nameof(playlist.playlistSongs));
    if (ModelState.IsValid)
    {
        _context.Add(playlist);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
else{
                Console.WriteLine(
                    "INvalid"
                );
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(playlist);
            }
    return View(playlist);
}

        // GET: Playlist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return View(playlist);
        }

        // POST: Playlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Opis,DateCreated,DateEdited")] Playlist playlist)
        {
            if (id != playlist.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaylistExists(playlist.ID))
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
            return View(playlist);
        }

        // GET: Playlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playlist = await _context.Playlist
                .FirstOrDefaultAsync(m => m.ID == id);
            if (playlist == null)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // POST: Playlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playlist = await _context.Playlist.FindAsync(id);
            if (playlist != null)
            {
                _context.Playlist.Remove(playlist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaylistExists(int id)
        {
            return _context.Playlist.Any(e => e.ID == id);
        }
    }
}
