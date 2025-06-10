using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.denuncia.Models;

namespace api.denuncia.Data
{
    public class apidenunciaContext : DbContext
    {
        public apidenunciaContext (DbContextOptions<apidenunciaContext> options)
            : base(options)
        {
        }

        public DbSet<api.denuncia.Models.TipoIncidente> TiposIncidente { get; set; } = default!;
        public DbSet<api.denuncia.Models.Ciudadano> Ciudadanos { get; set; }
        public DbSet<api.denuncia.Models.Policia> Policias { get; set; }
        public DbSet<api.denuncia.Models.Grado> Grados { get; set; }
        public DbSet<api.denuncia.Models.Incidente> Incidentes { get; set; }
        public DbSet<api.denuncia.Models.Intervencion> Intervenciones { get; set; }
    }
}
