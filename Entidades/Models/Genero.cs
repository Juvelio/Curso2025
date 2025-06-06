using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //public ICollection<Persona> Personas { get; set; }

    }
}
