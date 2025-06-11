using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Policia : Persona
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(100000, 99999999, ErrorMessage = "CIP debe tener 6 dígitos y estar entre 100000 y 99999999")]
        public int CIP { get; set; }

        [Required, MaxLength(100)]
        public string Comisaria { get; set; }

        public ICollection<Intervencion> Intervenciones { get; set; }

        [ForeignKey(nameof(Grado))]
        public int GradoId { get; set; }
        public Grado Grado { get; set; }
    }
}
