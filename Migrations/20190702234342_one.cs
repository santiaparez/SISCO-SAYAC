using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISCO_SAYACv3._5.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contratistas",
                columns: table => new
                {
                    ContratistasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tipo_documento = table.Column<string>(nullable: false),
                    numero_identificacion = table.Column<int>(nullable: false),
                    primer_nombre = table.Column<string>(maxLength: 60, nullable: false),
                    segundo_nombre = table.Column<string>(maxLength: 60, nullable: true),
                    primer_apellido = table.Column<string>(maxLength: 60, nullable: false),
                    segundo_apellido = table.Column<string>(maxLength: 60, nullable: true),
                    telefono = table.Column<string>(maxLength: 60, nullable: false),
                    direccion = table.Column<string>(maxLength: 60, nullable: false),
                    correo_electronico = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratistas", x => x.ContratistasId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuariosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    usuario = table.Column<string>(nullable: false),
                    contrasena = table.Column<string>(nullable: false),
                    correo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuariosId);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    ContratosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fecha_inicio = table.Column<DateTime>(nullable: false),
                    fecha_fin = table.Column<DateTime>(nullable: false),
                    valor_contrato = table.Column<double>(nullable: false),
                    tiempo_desfase = table.Column<double>(nullable: false),
                    porcentaje_multa = table.Column<double>(nullable: false),
                    porcentaje_adicional = table.Column<double>(nullable: false),
                    observaciones = table.Column<string>(maxLength: 200, nullable: true),
                    estado = table.Column<string>(nullable: false),
                    ContratistasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.ContratosId);
                    table.ForeignKey(
                        name: "FK_Contratos_Contratistas_ContratistasId",
                        column: x => x.ContratistasId,
                        principalTable: "Contratistas",
                        principalColumn: "ContratistasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                columns: table => new
                {
                    AuditoriasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_Inicio = table.Column<DateTime>(nullable: false),
                    Fecha_Final = table.Column<DateTime>(nullable: false),
                    UsuariosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.AuditoriasId);
                    table.ForeignKey(
                        name: "FK_Auditorias_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    ObrasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_obra = table.Column<string>(maxLength: 60, nullable: false),
                    tipo_obra = table.Column<string>(nullable: false),
                    direccion_obra = table.Column<string>(maxLength: 60, nullable: false),
                    ContratistasId = table.Column<int>(nullable: false),
                    ContratosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.ObrasId);
                    table.ForeignKey(
                        name: "ForeignKey_Obras_Contratistas",
                        column: x => x.ContratistasId,
                        principalTable: "Contratistas",
                        principalColumn: "ContratistasId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obras_Contratos_ContratosId",
                        column: x => x.ContratosId,
                        principalTable: "Contratos",
                        principalColumn: "ContratosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    ReportesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre_reportes = table.Column<string>(nullable: false),
                    fecha_reportes = table.Column<DateTime>(nullable: false),
                    observacion = table.Column<string>(maxLength: 200, nullable: true),
                    ContratosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.ReportesId);
                    table.ForeignKey(
                        name: "FK_Reportes_Contratos_ContratosId",
                        column: x => x.ContratosId,
                        principalTable: "Contratos",
                        principalColumn: "ContratosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_UsuariosId",
                table: "Auditorias",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ContratistasId",
                table: "Contratos",
                column: "ContratistasId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ContratistasId",
                table: "Obras",
                column: "ContratistasId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ContratosId",
                table: "Obras",
                column: "ContratosId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_ContratosId",
                table: "Reportes",
                column: "ContratosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditorias");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Contratistas");
        }
    }
}
