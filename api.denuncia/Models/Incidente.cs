using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.denuncia.Models
{
    public class Incidente
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public double Latitud { get; set; }
        public double Longitud { get; set; }

        // FK a Ciudadano
        [ForeignKey(nameof(Ciudadano))]
        public int CiudadanoId { get; set; }
        public Ciudadano Ciudadano { get; set; }

        // FK a TipoIncidente
        [ForeignKey(nameof(TipoIncidente))]
        public int TipoIncidenteId { get; set; }
        public TipoIncidente TipoIncidente { get; set; }

        public ICollection<Intervencion> Intervenciones { get; set; }
    }
}
