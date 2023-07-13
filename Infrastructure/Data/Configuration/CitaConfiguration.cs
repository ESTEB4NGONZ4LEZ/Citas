

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class CitaConfiguration : IEntityTypeConfiguration<Cita>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("cita");

            builder.Property(a => a.Cit_codigo)
            .IsRequired();

            builder.Property(a => a.Cit_fecha)
            .HasColumnType("Date")
            .IsRequired();

            builder.HasOne(a => a.EstadoCita)
            .WithMany(e => e.Citas)
            .HasForeignKey(i => i.Cit_estadoCita)
            .IsRequired();

            builder.HasOne(a => a.Medico)
            .WithMany(e => e.Citas)
            .HasForeignKey(i => i.Cit_medico)
            .IsRequired();

            builder.HasOne(a => a.Usuario)
            .WithMany(e => e.Citas)
            .HasForeignKey(i => i.Cit_datosUsuario)
            .IsRequired();
        }
    }
}