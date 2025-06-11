using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Persona
    {
        [Required]
        public int DNI { get; set; }
        [Required, MaxLength(50)]
        public string Paterno { get; set; }

        [Required, MaxLength(50)]
        public string Materno { get; set; }

        [Required, MaxLength(100)]
        public string Nombres { get; set; }        
    }
}
