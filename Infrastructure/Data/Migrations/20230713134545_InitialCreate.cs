using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "acudiente",
                columns: table => new
                {
                    Acu_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Acu_nombreCompleto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Acu_telefono = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Acu_direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acudiente", x => x.Acu_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "consultorio",
                columns: table => new
                {
                    cons_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cons_nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultorio", x => x.cons_codigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "especialidad",
                columns: table => new
                {
                    Esp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Esp_nombre = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especialidad", x => x.Esp_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado_cita",
                columns: table => new
                {
                    Estcita_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Estcita_nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_cita", x => x.Estcita_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "genero",
                columns: table => new
                {
                    Gen_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Gen_nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gen_abreviatura = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genero", x => x.Gen_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    Tipdoc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipdoc_nombre = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipdoc_abreviatura = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento", x => x.Tipdoc_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medico",
                columns: table => new
                {
                    Med_nroMatriculaProsional = table.Column<int>(type: "int", nullable: false),
                    Med_nombreCompleto = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Med_consultorio = table.Column<int>(type: "int", nullable: false),
                    Med_especialidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medico", x => x.Med_nroMatriculaProsional);
                    table.ForeignKey(
                        name: "FK_medico_consultorio_Med_consultorio",
                        column: x => x.Med_consultorio,
                        principalTable: "consultorio",
                        principalColumn: "cons_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medico_especialidad_Med_especialidad",
                        column: x => x.Med_especialidad,
                        principalTable: "especialidad",
                        principalColumn: "Esp_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Usu_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    usu_nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usu_segdo_nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usu_primer_apellido_usuar = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usu_segdo_apellido_usuar = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usu_telefono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usu_direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Usu_email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    usu_tipodoc = table.Column<int>(type: "int", nullable: false),
                    usu_genero = table.Column<int>(type: "int", nullable: false),
                    usu_acudiente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Usu_id);
                    table.ForeignKey(
                        name: "FK_usuario_acudiente_usu_acudiente",
                        column: x => x.usu_acudiente,
                        principalTable: "acudiente",
                        principalColumn: "Acu_codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_genero_usu_genero",
                        column: x => x.usu_genero,
                        principalTable: "genero",
                        principalColumn: "Gen_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_tipo_documento_usu_tipodoc",
                        column: x => x.usu_tipodoc,
                        principalTable: "tipo_documento",
                        principalColumn: "Tipdoc_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cita",
                columns: table => new
                {
                    Cit_codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cit_fecha = table.Column<DateTime>(type: "Date", nullable: false),
                    Cit_estadoCita = table.Column<int>(type: "int", nullable: false),
                    Cit_medico = table.Column<int>(type: "int", nullable: false),
                    Cit_datosUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cita", x => x.Cit_codigo);
                    table.ForeignKey(
                        name: "FK_cita_estado_cita_Cit_estadoCita",
                        column: x => x.Cit_estadoCita,
                        principalTable: "estado_cita",
                        principalColumn: "Estcita_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cita_medico_Cit_medico",
                        column: x => x.Cit_medico,
                        principalTable: "medico",
                        principalColumn: "Med_nroMatriculaProsional",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cita_usuario_Cit_datosUsuario",
                        column: x => x.Cit_datosUsuario,
                        principalTable: "usuario",
                        principalColumn: "Usu_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cita_Cit_datosUsuario",
                table: "cita",
                column: "Cit_datosUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_cita_Cit_estadoCita",
                table: "cita",
                column: "Cit_estadoCita");

            migrationBuilder.CreateIndex(
                name: "IX_cita_Cit_medico",
                table: "cita",
                column: "Cit_medico");

            migrationBuilder.CreateIndex(
                name: "IX_medico_Med_consultorio",
                table: "medico",
                column: "Med_consultorio");

            migrationBuilder.CreateIndex(
                name: "IX_medico_Med_especialidad",
                table: "medico",
                column: "Med_especialidad");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_usu_acudiente",
                table: "usuario",
                column: "usu_acudiente");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_usu_genero",
                table: "usuario",
                column: "usu_genero");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_usu_tipodoc",
                table: "usuario",
                column: "usu_tipodoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cita");

            migrationBuilder.DropTable(
                name: "estado_cita");

            migrationBuilder.DropTable(
                name: "medico");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "consultorio");

            migrationBuilder.DropTable(
                name: "especialidad");

            migrationBuilder.DropTable(
                name: "acudiente");

            migrationBuilder.DropTable(
                name: "genero");

            migrationBuilder.DropTable(
                name: "tipo_documento");
        }
    }
}
