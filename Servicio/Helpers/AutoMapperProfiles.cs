using AutoMapper;
using Entidades.DTOs;
using Entidades.Models;

namespace Servicio.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PersonaX, PersonaDTO>().ReverseMap();
            CreateMap<Genero, GeneroDTO>().ReverseMap();
        }
    }
}
