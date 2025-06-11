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
    public class IntervencionesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IntervencionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Intervenciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervencion>>> GetIntervenciones()
        {
            return await _context.Intervenciones.ToListAsync();
        }

        // GET: api/Intervenciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervencion>> GetIntervencion(int id)
        {
            var intervencion = await _context.Intervenciones.FindAsync(id);

            if (intervencion == null)
            {
                return NotFound();
            }

            return intervencion;
        }

        // PUT: api/Intervenciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntervencion(int id, Intervencion intervencion)
        {
            if (id != intervencion.IntervencionId)
            {
                return BadRequest();
            }

            _context.Entry(intervencion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntervencionExists(id))
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

        // POST: api/Intervenciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intervencion>> PostIntervencion(Intervencion intervencion)
        {
            _context.Intervenciones.Add(intervencion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntervencion", new { id = intervencion.IntervencionId }, intervencion);
        }

        // DELETE: api/Intervenciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntervencion(int id)
        {
            var intervencion = await _context.Intervenciones.FindAsync(id);
            if (intervencion == null)
            {
                return NotFound();
            }

            _context.Intervenciones.Remove(intervencion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntervencionExists(int id)
        {
            return _context.Intervenciones.Any(e => e.IntervencionId == id);
        }
    }
}
