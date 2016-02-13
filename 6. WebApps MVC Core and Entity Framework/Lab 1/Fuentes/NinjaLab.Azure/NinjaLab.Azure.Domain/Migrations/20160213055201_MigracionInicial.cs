using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace NinjaLab.Azure.Domain.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apodo = table.Column<string>(nullable: true),
                    Entrenador = table.Column<string>(nullable: true),
                    Estadio = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    Presidente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.IdEquipo);
                });
            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    IdJugador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apodo = table.Column<string>(nullable: true),
                    Estatura = table.Column<decimal>(nullable: false),
                    IdEquipo = table.Column<int>(nullable: false),
                    Nacionalidad = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    Posicion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.IdJugador);
                    table.ForeignKey(
                        name: "FK_Jugador_Equipo_IdEquipo",
                        column: x => x.IdEquipo,
                        principalTable: "Equipo",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Jugador");
            migrationBuilder.DropTable("Equipo");
        }
    }
}
