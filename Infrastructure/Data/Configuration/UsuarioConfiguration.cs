

using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.Property(a => a.Usu_id)
            .IsRequired();

            builder.Property(a => a.usu_nombre)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(a => a.Usu_segdo_nombre)
            .HasMaxLength(45)
            .IsRequired();

            builder.Property(a => a.Usu_primer_apellido_usuar)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(a => a.Usu_segdo_apellido_usuar)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(a => a.Usu_telefono)
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(a => a.Usu_direccion)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(a => a.Usu_email)
            .HasMaxLength(100)
            .IsRequired();

            builder.HasOne(a => a.Tipo_documento)
            .WithMany(e => e.Usuarios)
            .HasForeignKey(i => i.usu_tipodoc)
            .IsRequired();

            builder.HasOne(a => a.Genero)
            .WithMany(e => e.Usuarios)
            .HasForeignKey(i => i.usu_genero)
            .IsRequired();

            builder.HasOne(a => a.Acudiente)
            .WithMany(e => e.Usuarios)
            .HasForeignKey(i => i.usu_acudiente)
            .IsRequired();
        }
    }
}