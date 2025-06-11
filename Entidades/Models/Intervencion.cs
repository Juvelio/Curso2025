using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Models
{
    public class Intervencion
    {
        [Key]
        public int IntervencionId { get; set; }

        public DateTime Fecha { get; set; }

        public string Detalle { get; set; }

        // FK a Incidente
        [ForeignKey(nameof(Incidente))]
        public int IncidenteId { get; set; }
        public Incidente Incidente { get; set; }

        // FK a PoliciaPNP
        [ForeignKey(nameof(Policia))]
        public int CIP { get; set; }
        public Policia Policia { get; set; }
    }
}
