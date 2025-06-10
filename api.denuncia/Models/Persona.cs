using System.ComponentModel.DataAnnotations;

namespace api.denuncia.Models
{
    public abstract class Persona
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
