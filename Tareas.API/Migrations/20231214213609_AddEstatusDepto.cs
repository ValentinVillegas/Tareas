using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tareas.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEstatusDepto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estatus",
                table: "Departamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Departamentos");
        }
    }
}
