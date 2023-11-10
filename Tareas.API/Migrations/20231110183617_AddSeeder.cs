using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tareas.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RubrosEncargados_Empleados_EmpleadoId",
                table: "RubrosEncargados");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "RubrosEncargados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RubrosEncargados_Empleados_EmpleadoId",
                table: "RubrosEncargados",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RubrosEncargados_Empleados_EmpleadoId",
                table: "RubrosEncargados");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "RubrosEncargados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RubrosEncargados_Empleados_EmpleadoId",
                table: "RubrosEncargados",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id");
        }
    }
}
