using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class GradoDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Abreviatura { get; set; }
        [Required, MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
