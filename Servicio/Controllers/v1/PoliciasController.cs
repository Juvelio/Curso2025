using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entidades.Models;
using Servicio.Data;

namespace Servicio.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PoliciasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PoliciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Policias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Policia>>> GetPolicias()
        {
            return await _context.Policias.ToListAsync();
        }

        // GET: api/Policias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policia>> GetPolicia(int id)
        {
            var policia = await _context.Policias.FindAsync(id);

            if (policia == null)
            {
                return NotFound();
            }

            return policia;
        }

        // PUT: api/Policias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicia(int id, Policia policia)
        {
            if (id != policia.Id)
            {
                return BadRequest();
            }

            _context.Entry(policia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliciaExists(id))
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

        // POST: api/Policias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Policia>> PostPolicia(Policia policia)
        {
            _context.Policias.Add(policia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicia", new { id = policia.Id }, policia);
        }

        // DELETE: api/Policias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicia(int id)
        {
            var policia = await _context.Policias.FindAsync(id);
            if (policia == null)
            {
                return NotFound();
            }

            _context.Policias.Remove(policia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliciaExists(int id)
        {
            return _context.Policias.Any(e => e.Id == id);
        }
    }
}
