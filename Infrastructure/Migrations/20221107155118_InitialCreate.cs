using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CAT");

            migrationBuilder.EnsureSchema(
                name: "GEN");

            migrationBuilder.CreateTable(
                name: "Colas",
                schema: "CAT",
                columns: table => new
                {
                    IdCola = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    TiempoAtencion = table.Column<long>(type: "bigint", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colas", x => x.IdCola);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                schema: "CAT",
                columns: table => new
                {
                    IdPersona = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "CAT",
                columns: table => new
                {
                    IdCliente = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrasena = table.Column<string>(type: "varchar(350)", maxLength: 350, nullable: true),
                    PersonaId = table.Column<long>(type: "bigint", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalSchema: "CAT",
                        principalTable: "Personas",
                        principalColumn: "IdPersona",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "GEN",
                columns: table => new
                {
                    IdTicket = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Serie = table.Column<long>(type: "bigint", nullable: false),
                    ColaId = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<long>(type: "bigint", nullable: false),
                    FechaTicket = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoTickets = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioRegistro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioAnulacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Tickets_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "CAT",
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Colas_ColaId",
                        column: x => x.ColaId,
                        principalSchema: "CAT",
                        principalTable: "Colas",
                        principalColumn: "IdCola",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PersonaId",
                schema: "CAT",
                table: "Clientes",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClienteId",
                schema: "GEN",
                table: "Tickets",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ColaId",
                schema: "GEN",
                table: "Tickets",
                column: "ColaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "GEN");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Colas",
                schema: "CAT");

            migrationBuilder.DropTable(
                name: "Personas",
                schema: "CAT");
        }
    }
}
