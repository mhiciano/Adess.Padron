using Adess.Padron.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adess.Padron.Persistance.Configuration
{
    public class PadronElectoralConfiguration : IEntityTypeConfiguration<PadronElectoral>
    {
        public void Configure(EntityTypeBuilder<PadronElectoral> builder)
        {
            builder.ToTable("MS_PADRON_ELECTORAL");

            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).HasColumnName("CEDULA");
            builder.Property(x=> x.MunCed).HasColumnName("MUN_CED");
            builder.Property(x=> x.SeqCed).HasColumnName("SEQ_CED");
            builder.Property(x=> x.VerCed).HasColumnName("VER_CED");
            builder.Property(x=> x.Nombres).HasColumnName("NOMBRES");
            builder.Property(x=> x.Apellido1).HasColumnName("APELLIDO1");
            builder.Property(x=> x.Apellido2).HasColumnName("APELLIDO2");
            builder.Property(x=> x.FechaNacimiento).HasColumnName("FECHA_NAC");
            builder.Property(x=> x.LugarNacimiento).HasColumnName("LUGAR_NAC");
            builder.Property(x=> x.CedNum).HasColumnName("CED_A_NUM");
            builder.Property(x=> x.CedSeri).HasColumnName("CED_A_SERI");
            builder.Property(x=> x.CedSexo).HasColumnName("CED_A_SEXO");
            builder.Property(x=> x.CodNacionalidad).HasColumnName("COD_NACION");
            builder.Property(x=> x.EstadoCivil).HasColumnName("EST_CIVIL");
            builder.Property(x=> x.FechaExpiracion).HasColumnName("FECHA_EXPE");
            builder.Property(x=> x.Categoria).HasColumnName("CATEGORIA");
            builder.Property(x=> x.Estatus).HasColumnName("ESTATUS");
        }
    }
}
