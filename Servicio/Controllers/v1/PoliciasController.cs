using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entidades.Models;
using Servicio.Data;
using AutoMapper;
using Entidades.DTOs;

namespace Servicio.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PoliciasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PoliciasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Policias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PoliciaDTO>>> GetPolicias()
        {
            var policias = await _context.Policias
                .Include(p => p.Grado)
                .ToListAsync();

            return _mapper.Map<List<PoliciaDTO>>(policias);
        }

        // GET: api/Policias/5
        [HttpGet("{CIP}")]
        public async Task<ActionResult<Policia>> GetPolicia(int CIP)
        {
            var policia = await _context.Policias
                .Include(p => p.Grado)
                .Where(x => x.CIP == CIP)
                .FirstOrDefaultAsync();

            if (policia == null)
            {
                return NotFound();
            }

            return policia;
        }

        // PUT: api/Policias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{CIP}")]
        public async Task<IActionResult> PutPolicia(int CIP, Policia policia)
        {
            if (CIP != policia.CIP)
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
                if (!PoliciaExists(CIP))
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
        public async Task<ActionResult<Policia>> PostPolicia(PoliciaCrearDTO policiaCrear)
        {
            var policia = _mapper.Map<Policia>(policiaCrear);
            _context.Policias.Add(policia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicia", new { CIP = policia.CIP }, policia);
        }

        // DELETE: api/Policias/5
        [HttpDelete("{CIP}")]
        public async Task<IActionResult> DeletePolicia(int CIP)
        {
            var policia = await _context.Policias.FindAsync(CIP);
            if (policia == null)
            {
                return NotFound();
            }

            _context.Policias.Remove(policia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliciaExists(int CIP)
        {
            return _context.Policias.Any(e => e.CIP == CIP);
        }
    }
}
