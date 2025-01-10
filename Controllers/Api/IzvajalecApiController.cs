using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers_Api
{
    [Route("api/v1/izvajalec")]
    [ApiController]
    public class IzvajalecApiController : ControllerBase
    {
        private readonly EmuzikaContext _context;

        public IzvajalecApiController(EmuzikaContext context)
        {
            _context = context;
        }

        // GET: api/IzvajalecApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Izvajalec>>> GetIzvajalci()
        {
            return await _context.Izvajalci.ToListAsync();
        }

        // GET: api/IzvajalecApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Izvajalec>> GetIzvajalec(int id)
        {
            var izvajalec = await _context.Izvajalci.FindAsync(id);

            if (izvajalec == null)
            {
                return NotFound();
            }

            return izvajalec;
        }

        // PUT: api/IzvajalecApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIzvajalec(int id, Izvajalec izvajalec)
        {
            if (id != izvajalec.ID)
            {
                return BadRequest();
            }

            _context.Entry(izvajalec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IzvajalecExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IzvajalecApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Izvajalec>> PostIzvajalec(Izvajalec izvajalec)
        {
            _context.Izvajalci.Add(izvajalec);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IzvajalecExists(izvajalec.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIzvajalec", new { id = izvajalec.ID }, izvajalec);
        }

        // DELETE: api/IzvajalecApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIzvajalec(int id)
        {
            var izvajalec = await _context.Izvajalci.FindAsync(id);
            if (izvajalec == null)
            {
                return NotFound();
            }

            _context.Izvajalci.Remove(izvajalec);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IzvajalecExists(int id)
        {
            return _context.Izvajalci.Any(e => e.ID == id);
        }
    }
}
