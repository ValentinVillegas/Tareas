using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tareas.API.Migrations
{
    /// <inheritdoc />
    public partial class EstatusEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Empleados_Nombre",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Empleados");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Nombre",
                table: "Empleados",
                column: "Nombre",
                unique: true);
        }
    }
}
