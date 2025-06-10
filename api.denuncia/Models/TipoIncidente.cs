using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.denuncia.Models
{
    public class TipoIncidente
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Descripcion { get; set; }

        public ICollection<Incidente> Incidentes { get; set; }
    }

}
