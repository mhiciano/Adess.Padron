using Adess.Padron.Domain.Models;
using Adess.Padron.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Adess.Padron.Persistance
{
    public class PadronDbContext : DbContext
    {
        public PadronDbContext(DbContextOptions<PadronDbContext> options) : base(options)
        {
        }

        public DbSet<PadronElectoral> PadronElectoral { get; set; }
        public DbSet<CedulasProcesar> CedulasProcesar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.ApplyConfiguration(new PadronElectoralConfiguration());
          modelBuilder.ApplyConfiguration(new CedulasProcesarConfiguration());
        }
    }
}