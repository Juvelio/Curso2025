
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

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }       

        //[HttpGet]
        //public async Task<List<Persona>> GetPersona()
        //{
        //    var personas = await _context.Personas.ToListAsync();
        //    return personas;
        //}

        //[HttpGet("{id}")]
        //public async Task<Persona> GetPersona(int id)
        //{
        //    var persona = await _context.Personas.Where(p => p.Id == id).FirstOrDefaultAsync();
        //    return persona;
        //}


        //[HttpGet]
        //public List<Persona> GetPersona()
        //{
        //    List<Persona> personas = new List<Persona>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Persona persona = new Persona()
        //        {
        //            Id = i +1,
        //            Paterno = $"Miranda {i}",
        //            Materno = $"Luna {i}",
        //            Nombres = $"Jose {i}"
        //        };
        //        personas.Add(persona);
        //    }
        //    return personas;
        //}

        //[HttpGet("{id}")]
        //public Persona GetPersona(int id)
        //{
        //    Persona persona = new Persona()
        //    {
        //        Id = 2,
        //        Paterno = "CANDIA",
        //        Materno = "CHACMANA",
        //        Nombres = "Melisa"
        //    };
        //    return persona;
        //}
    }
}
