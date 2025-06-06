using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
   public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Nombres { get; set; }
        [Required, StringLength(50)]
        public string Paterno { get; set; }
        [Required, StringLength(50)]
        public string Materno { get; set; }

        [ForeignKey(nameof(Genero))]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
