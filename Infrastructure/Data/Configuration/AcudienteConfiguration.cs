

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class AcudienteConfiguration : IEntityTypeConfiguration<Acudiente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Acudiente> builder)
        {
            builder.ToTable("acudiente");

            builder.Property(a => a.Acu_codigo)
            .IsRequired();

            builder.Property(a => a.Acu_nombreCompleto)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(a => a.Acu_telefono)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(a => a.Acu_direccion)
            .HasMaxLength(100)
            .IsRequired();
        }
    }
}