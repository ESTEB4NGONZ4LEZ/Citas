

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("medico");

            builder.Property(a => a.Med_nroMatriculaProsional)
            .ValueGeneratedNever()
            .IsRequired();

            builder.Property(a => a.Med_nombreCompleto)
            .HasMaxLength(120)
            .IsRequired();

            builder.HasOne(a => a.Consultorio)
            .WithMany(e => e.Medicos)
            .HasForeignKey(i => i.Med_consultorio)
            .IsRequired();

            builder.HasOne(a => a.Especialidad)
            .WithMany(e => e.Medicos)
            .HasForeignKey(i => i.Med_especialidad)
            .IsRequired();

        }
    }
}