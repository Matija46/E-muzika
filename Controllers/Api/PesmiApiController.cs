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
    [Route("api/v1/Pesmi")]
    [ApiController]
    public class PesmiApiController : ControllerBase
    {
        private readonly EmuzikaContext _context;

        public PesmiApiController(EmuzikaContext context)
        {
            _context = context;
        }

        // GET: api/PesmiApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pesem>>> GetPesmi()
        {
            return await _context.Pesmi.ToListAsync();
        }

        // GET: api/PesmiApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pesem>> GetPesem(int id)
        {
            var pesem = await _context.Pesmi.FindAsync(id);

            if (pesem == null)
            {
                return NotFound();
            }

            return pesem;
        }

        // PUT: api/PesmiApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPesem(int id, Pesem pesem)
        {
            if (id != pesem.ID)
            {
                return BadRequest();
            }

            _context.Entry(pesem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PesemExists(id))
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

        // POST: api/PesmiApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pesem>> PostPesem(Pesem pesem)
        {
            _context.Pesmi.Add(pesem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PesemExists(pesem.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPesem", new { id = pesem.ID }, pesem);
        }

        // DELETE: api/PesmiApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePesem(int id)
        {
            var pesem = await _context.Pesmi.FindAsync(id);
            if (pesem == null)
            {
                return NotFound();
            }

            _context.Pesmi.Remove(pesem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PesemExists(int id)
        {
            return _context.Pesmi.Any(e => e.ID == id);
        }
    }
}
