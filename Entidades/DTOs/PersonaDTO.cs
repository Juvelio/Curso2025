using Entidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int GeneroId { get; set; }
        public GeneroDTO Genero { get; set; }
    }
}
