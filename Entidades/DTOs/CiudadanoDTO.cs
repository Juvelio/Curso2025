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

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Direccion { get; set; }

        public ICollection<Incidente> Incidentes { get; set; }

        public int GeneroId { get; set; }
        public GeneroDTO Genero { get; set; }
    }
}
