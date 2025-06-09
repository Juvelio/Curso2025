using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class IntervencionDTO
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Detalle { get; set; }
    }
}
