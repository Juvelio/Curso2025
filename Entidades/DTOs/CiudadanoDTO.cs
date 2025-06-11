using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Models;

namespace Entidades.DTOs
{
    public class CiudadanoDTO: Persona
    {
        public int Id { get; set; }

        [Required, MaxLength(15, ErrorMessage = "El telefono es requerido")]
        public string Telefono { get; set; }

        [Required, MaxLength(50, ErrorMessage = "La dirreccion es requerido")]
        public string Direccion { get; set; }

        public ICollection<Incidente> Incidentes { get; set; }

        [Required, MaxLength(50, ErrorMessage = "El genero es requerido")]
        public int GeneroId { get; set; }
        public GeneroDTO Genero { get; set; }
    }
}
