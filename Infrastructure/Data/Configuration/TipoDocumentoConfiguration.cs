

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.ToTable("tipo_documento");

            builder.Property(a => a.Tipdoc_id)
            .IsRequired();

            builder.Property(a => a.Tipdoc_nombre)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(a => a.Tipdoc_abreviatura)
            .HasMaxLength(20)
            .IsRequired();
        }
    }
}