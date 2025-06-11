using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

            //foreach (IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}
        }

        public DbSet<Genero> Genero { get; set; }
        public DbSet<TipoIncidente> TiposIncidente { get; set; } = default!;
        public DbSet<Ciudadano> Ciudadanos { get; set; }
        public DbSet<Policia> Policias { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<Intervencion> Intervenciones { get; set; }
    }
}
