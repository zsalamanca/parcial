using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueñoController : ControllerBase
    {
        private readonly VeterinariaContext _context;

        public DueñoController(VeterinariaContext context)
        {
            _context = context;
        }

        // GET: api/Dueño
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dueño>>> GetDueños()
        {
          if (_context.Dueños == null)
          {
              return NotFound();
          }
            return await _context.Dueños.ToListAsync();
        }

        // GET: api/Dueño/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dueño>> GetDueño(string id)
        {
          if (_context.Dueños == null)
          {
              return NotFound();
          }
            var dueño = await _context.Dueños.FindAsync(id);

            if (dueño == null)
            {
                return NotFound();
            }

            return dueño;
        }

        // PUT: api/Dueño/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDueño(string id, Dueño dueño)
        {
            if (id != dueño.Iddueños)
            {
                return BadRequest();
            }

            _context.Entry(dueño).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DueñoExists(id))
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

        // POST: api/Dueño
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dueño>> PostDueño(Dueño dueño)
        {
          if (_context.Dueños == null)
          {
              return Problem("Entity set 'VeterinariaContext.Dueños'  is null.");
          }
            _context.Dueños.Add(dueño);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DueñoExists(dueño.Iddueños))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDueño", new { id = dueño.Iddueños }, dueño);
        }

        // DELETE: api/Dueño/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDueño(string id)
        {
            if (_context.Dueños == null)
            {
                return NotFound();
            }
            var dueño = await _context.Dueños.FindAsync(id);
            if (dueño == null)
            {
                return NotFound();
            }

            _context.Dueños.Remove(dueño);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DueñoExists(string id)
        {
            return (_context.Dueños?.Any(e => e.Iddueños == id)).GetValueOrDefault();
        }
    }
}
