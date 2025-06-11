using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "El DNI es requerido "), Range(1, int.MaxValue, ErrorMessage = "El numero de DNI debe ser mayor a 1")]
        public int DNI { get; set; }
        [Required(ErrorMessage = "El apellido paterno es requerido"), MaxLength(50)]
        public string Paterno { get; set; }

        [Required(ErrorMessage = "El apellido materno es requerido"), MaxLength(50)]
        public string Materno { get; set; }

        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(100)]
        public string Nombres { get; set; }
    }
}
