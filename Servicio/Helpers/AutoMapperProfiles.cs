using AutoMapper;
using Entidades.DTOs;
using Entidades.Models;

namespace Servicio.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero, GeneroDTO>().ReverseMap();

            CreateMap<Policia, PoliciaDTO>().ReverseMap();
            CreateMap<Policia, PoliciaCrearDTO>().ReverseMap();

            CreateMap<Grado, GradoDTO>().ReverseMap();
            CreateMap<Intervencion, IntervencionDTO>().ReverseMap();

            CreateMap<Ciudadano, CiudadanoDTO>().ReverseMap();
            CreateMap<Ciudadano, CiudadanoCrearDTO>().ReverseMap();
        }
    }
}
