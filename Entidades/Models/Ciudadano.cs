using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Ciudadano : Persona
    {
        [Key, Required, MaxLength(8)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Direccion { get; set; }

        public ICollection<Incidente> Incidentes { get; set; }

        [ForeignKey(nameof(Genero))]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }

}
