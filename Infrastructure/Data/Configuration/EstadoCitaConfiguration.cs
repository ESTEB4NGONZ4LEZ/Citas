

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class EstadoCitaConfiguration : IEntityTypeConfiguration<EstadoCita>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EstadoCita> builder)
        {
            builder.ToTable("estado_cita");

            builder.Property(a => a.Estcita_id)
            .IsRequired();

            builder.Property(a => a.Estcita_nombre)
            .HasMaxLength(20)
            .IsRequired();
        }
    }
}