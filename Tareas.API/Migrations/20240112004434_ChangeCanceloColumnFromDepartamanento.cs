using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tareas.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCanceloColumnFromDepartamanento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estatus",
                table: "Departamentos",
                newName: "Cancelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cancelo",
                table: "Departamentos",
                newName: "Estatus");
        }
    }
}
