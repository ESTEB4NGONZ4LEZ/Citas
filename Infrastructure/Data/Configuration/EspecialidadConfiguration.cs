

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Especialidad> builder)
        {
            builder.ToTable("especialidad");

            builder.Property(a => a.Esp_id)
            .IsRequired();

            builder.Property(a => a.Esp_nombre)
            .HasMaxLength(20)
            .IsRequired();
        }
    }
}