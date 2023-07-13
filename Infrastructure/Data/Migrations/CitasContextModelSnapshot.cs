﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(CitasContext))]
    partial class CitasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Acudiente", b =>
                {
                    b.Property<int>("Acu_codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Acu_direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Acu_nombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Acu_telefono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Acu_codigo");

                    b.ToTable("acudiente", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.Property<int>("Cit_codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cit_datosUsuario")
                        .HasColumnType("int");

                    b.Property<int>("Cit_estadoCita")
                        .HasColumnType("int");

                    b.Property<DateTime>("Cit_fecha")
                        .HasColumnType("Date");

                    b.Property<int>("Cit_medico")
                        .HasColumnType("int");

                    b.HasKey("Cit_codigo");

                    b.HasIndex("Cit_datosUsuario");

                    b.HasIndex("Cit_estadoCita");

                    b.HasIndex("Cit_medico");

                    b.ToTable("cita", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Consultorio", b =>
                {
                    b.Property<int>("cons_codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("cons_nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("cons_codigo");

                    b.ToTable("consultorio", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Especialidad", b =>
                {
                    b.Property<int>("Esp_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Esp_nombre")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.HasKey("Esp_id");

                    b.ToTable("especialidad", (string)null);
                });

            modelBuilder.Entity("Core.Entities.EstadoCita", b =>
                {
                    b.Property<int>("Estcita_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Estcita_nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Estcita_id");

                    b.ToTable("estado_cita", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Property<int>("Gen_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Gen_abreviatura")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Gen_nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Gen_id");

                    b.ToTable("genero", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Medico", b =>
                {
                    b.Property<int>("Med_nroMatriculaProsional")
                        .HasColumnType("int");

                    b.Property<int?>("Med_consultorio")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Med_especialidad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Med_nombreCompleto")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.HasKey("Med_nroMatriculaProsional");

                    b.HasIndex("Med_consultorio");

                    b.HasIndex("Med_especialidad");

                    b.ToTable("medico", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("Tipdoc_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Tipdoc_abreviatura")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tipdoc_nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Tipdoc_id");

                    b.ToTable("tipo_documento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Property<int>("Usu_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Usu_direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Usu_email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Usu_primer_apellido_usuar")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Usu_segdo_apellido_usuar")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Usu_segdo_nombre")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Usu_telefono")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("usu_acudiente")
                        .HasColumnType("int");

                    b.Property<int>("usu_genero")
                        .HasColumnType("int");

                    b.Property<string>("usu_nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("usu_tipodoc")
                        .HasColumnType("int");

                    b.HasKey("Usu_id");

                    b.HasIndex("usu_acudiente");

                    b.HasIndex("usu_genero");

                    b.HasIndex("usu_tipodoc");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cita", b =>
                {
                    b.HasOne("Core.Entities.Usuario", "Usuario")
                        .WithMany("Citas")
                        .HasForeignKey("Cit_datosUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.EstadoCita", "EstadoCita")
                        .WithMany("Citas")
                        .HasForeignKey("Cit_estadoCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Medico", "Medico")
                        .WithMany("Citas")
                        .HasForeignKey("Cit_medico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoCita");

                    b.Navigation("Medico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entities.Medico", b =>
                {
                    b.HasOne("Core.Entities.Consultorio", "Consultorio")
                        .WithMany("Medicos")
                        .HasForeignKey("Med_consultorio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Especialidad", "Especialidad")
                        .WithMany("Medicos")
                        .HasForeignKey("Med_especialidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultorio");

                    b.Navigation("Especialidad");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.HasOne("Core.Entities.Acudiente", "Acudiente")
                        .WithMany("Usuarios")
                        .HasForeignKey("usu_acudiente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Genero", "Genero")
                        .WithMany("Usuarios")
                        .HasForeignKey("usu_genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoDocumento", "Tipo_documento")
                        .WithMany("Usuarios")
                        .HasForeignKey("usu_tipodoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acudiente");

                    b.Navigation("Genero");

                    b.Navigation("Tipo_documento");
                });

            modelBuilder.Entity("Core.Entities.Acudiente", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.Consultorio", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("Core.Entities.Especialidad", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("Core.Entities.EstadoCita", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.Medico", b =>
                {
                    b.Navigation("Citas");
                });

            modelBuilder.Entity("Core.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}
