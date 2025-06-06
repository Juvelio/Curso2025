using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace Servicio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Persona> Personas { get; set; }
        public DbSet<Ciudadano> Ciudadanos { get; set; }
        public DbSet<Policia> Policias { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<TipoIncidente> TiposIncidente { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<Intervencion> Intervenciones { get; set; }
    }
}
