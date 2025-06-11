using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicio.Data;

namespace Servicio.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TiposIncidentesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TiposIncidentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TiposIncidentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIncidente>>> GetTipoIncidente()
        {
            return await _context.TiposIncidente.ToListAsync();
        }

        // GET: api/TiposIncidentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIncidente>> GetTipoIncidente(int id)
        {
            var tipoIncidente = await _context.TiposIncidente.FindAsync(id);

            if (tipoIncidente == null)
            {
                return NotFound();
            }

            return tipoIncidente;
        }

        // PUT: api/TiposIncidentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIncidente(int id, TipoIncidente tipoIncidente)
        {
            if (id != tipoIncidente.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoIncidente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIncidenteExists(id))
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

        // POST: api/TiposIncidentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoIncidente>> PostTipoIncidente(TipoIncidente tipoIncidente)
        {
            _context.TiposIncidente.Add(tipoIncidente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoIncidente", new { id = tipoIncidente.Id }, tipoIncidente);
        }

        // DELETE: api/TiposIncidentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoIncidente(int id)
        {
            var tipoIncidente = await _context.TiposIncidente.FindAsync(id);
            if (tipoIncidente == null)
            {
                return NotFound();
            }

            _context.TiposIncidente.Remove(tipoIncidente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoIncidenteExists(int id)
        {
            return _context.TiposIncidente.Any(e => e.Id == id);
        }
    }
}
