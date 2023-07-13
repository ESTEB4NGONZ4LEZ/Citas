
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("genero");

            builder.Property(a => a.Gen_id)
            .IsRequired();

            builder.Property(a => a.Gen_nombre)
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(a => a.Gen_abreviatura)
            .HasMaxLength(20)
            .IsRequired();
        }
    }
}