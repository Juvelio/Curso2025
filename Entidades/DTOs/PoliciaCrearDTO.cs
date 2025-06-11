using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Models;

namespace Entidades.DTOs
{
    public class PoliciaCrearDTO : Persona
    {
        [Required, Range(100000, 99999999)]
        public int CIP { get; set; }

        [Required, MaxLength(100)]
        public string Comisaria { get; set; }

        [Required]
        public int GradoId { get; set; }
    }
}
