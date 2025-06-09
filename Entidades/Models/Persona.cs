using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    //public class Persona
    // {
    //     [Key]
    //     public int Id { get; set; }
    //     [Required, StringLength(50)]
    //     public string Nombres { get; set; }
    //     [Required, StringLength(50)]
    //     public string Paterno { get; set; }
    //     [Required, StringLength(50)]
    //     public string Materno { get; set; }
    // }


  

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

    public class Ciudadano : Persona
    {
        [Key, Required, MaxLength(8)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Direccion { get; set; }

        public ICollection<Incidente> Incidentes { get; set; }
    }

    public class Policia : Persona
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CIP { get; set; }

        [Required, MaxLength(100)]
        public string Comisaria { get; set; }

        public ICollection<Intervencion> Intervenciones { get; set; }

        [ForeignKey(nameof(Grado))]
        public int GradoId { get; set; }
        public Grado Grado { get; set; }
    }

    public class Grado
    {
        [Key]
        public int Id { get; set; }        
        [Required, MaxLength(10)]
        public string Abreviatura { get; set; }
        [Required, MaxLength(50)]
        public string Descripcion { get; set; }
    }


    public class TipoIncidente
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Descripcion { get; set; }

        public ICollection<Incidente> Incidentes { get; set; }
    }

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
