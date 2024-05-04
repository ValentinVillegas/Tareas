using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tareas.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCanceloColumnFromEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estatus",
                table: "Empleados",
                newName: "Cancelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cancelo",
                table: "Empleados",
                newName: "Estatus");
        }
    }
}
