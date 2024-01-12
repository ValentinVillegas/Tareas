using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tareas.API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionesEquiposUnidadesNegocioYRubros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnidadesNegocio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cancelo = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesNegocio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CveEquipo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cancelo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Estatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    UnidadNegocioId = table.Column<int>(type: "int", nullable: false),
                    RubroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipos_Rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipos_UnidadesNegocio_UnidadNegocioId",
                        column: x => x.UnidadNegocioId,
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_RubroId",
                table: "Equipos",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_UnidadNegocioId",
                table: "Equipos",
                column: "UnidadNegocioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "UnidadesNegocio");
        }
    }
}
