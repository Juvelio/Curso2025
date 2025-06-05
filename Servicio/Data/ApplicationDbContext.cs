using Entidades.Models;
using Microsoft.EntityFrameworkCore;

namespace Servicio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
