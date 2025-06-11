using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Ciudadano : Persona
    {
        [Key, Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El telefono es requerido"), MaxLength(15)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirreccion es requerido"), MaxLength(50)]
        public string Direccion { get; set; }

        public ICollection<Incidente> Incidentes { get; set; }

        [ForeignKey(nameof(Genero))]
        [Required(ErrorMessage = "El genero es requerido"), Range(1, int.MaxValue, ErrorMessage = "El genero es requerido")]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }

}
