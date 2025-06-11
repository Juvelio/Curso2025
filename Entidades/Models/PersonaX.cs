using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
   public class PersonaX
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Nombres { get; set; }
        [Required, StringLength(50)]
        public string Paterno { get; set; }
        [Required, StringLength(50)]
        public string Materno { get; set; }


        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        [Column("CORREO_ELECTRONICO")]
        public string Email { get; set; }




        [ForeignKey(nameof(Genero))]
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
