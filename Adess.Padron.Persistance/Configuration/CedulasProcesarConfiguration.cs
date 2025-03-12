using Adess.Padron.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adess.Padron.Persistance.Configuration
{
    public class CedulasProcesarConfiguration : IEntityTypeConfiguration<CedulasProcesar>
    {
        public void Configure(EntityTypeBuilder<CedulasProcesar> builder)
        {
            builder.ToTable("TBL_CEDULAS_PROCESAR");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("CEDULA");
            builder.Property(x => x.Estatus).HasColumnName("Estatus");

        }
    }
}
