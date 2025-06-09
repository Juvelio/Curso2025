
using AutoMapper;
using Entidades.DTOs;
using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Servicio.Data;

namespace Servicio.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PersonasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<PersonaDTO>> GetPersona()
        {
            var personas = await _context.Personas
                .Include(p => p.Genero) // Incluye la entidad Genero relacionada
                .ToListAsync();

            var personasDTO = _mapper.Map<List<PersonaDTO>>(personas);

            return personasDTO;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDTO>> GetPersona(int id)
        {
            var persona = await _context.Personas
                .Where(p => p.Id == id)                
                .Include(p => p.Genero)                 
                .FirstOrDefaultAsync();

            if (persona == null)
            {
                return NotFound($"no existe persona con id {id}");
            }
            // Mapear la entidad Persona a PersonaDTO usando AutoMapper
            var personaDTO = _mapper.Map<PersonaDTO>(persona);

            return personaDTO;
        }

        [HttpPost]
        public async Task<IActionResult> PostPersona([FromBody] Persona persona)
        {
            try
            {
                if (persona == null)
                {
                    return BadRequest("Persona no puede ser nulo");
                }
                _context.Personas.Add(persona);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPersona), new { id = persona.Id }, persona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, [FromBody] Persona persona)
        {
            if (id != persona.Id)
            {
                return BadRequest("El ID de la persona no coincide con el ID en la URL.");
            }
            _context.Entry(persona).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound($"No existe persona con id {id}");
            }
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }        
    }
}
