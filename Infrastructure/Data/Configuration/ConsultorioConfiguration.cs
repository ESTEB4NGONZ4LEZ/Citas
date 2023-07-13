

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ConsultorioConfiguration : IEntityTypeConfiguration<Consultorio>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Consultorio> builder)
        {
            builder.ToTable("consultorio");

            builder.Property(a => a.cons_codigo)
            .IsRequired();

            builder.Property(a => a.cons_nombre)
            .HasMaxLength(50)
            .IsRequired();
        }
    }
}