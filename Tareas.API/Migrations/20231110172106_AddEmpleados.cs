using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tareas.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEmpleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Departamento_DepartamentoId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_RubrosEncargados_Empleado_EmpleadoId",
                table: "RubrosEncargados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento");

            migrationBuilder.RenameTable(
                name: "Empleado",
                newName: "Empleados");

            migrationBuilder.RenameTable(
                name: "Departamento",
                newName: "Departamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Empleado_DepartamentoId",
                table: "Empleados",
                newName: "IX_Empleados_DepartamentoId");

            migrationBuilder.AddColumn<string>(
                name: "CveEmpleado",
                table: "Empleados",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Nombre",
                table: "Empleados",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Nombre",
                table: "Departamentos",
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoId",
                table: "Empleados",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RubrosEncargados_Empleados_EmpleadoId",
                table: "RubrosEncargados",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Departamentos_DepartamentoId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_RubrosEncargados_Empleados_EmpleadoId",
                table: "RubrosEncargados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_Nombre",
                table: "Empleados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departamentos",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_Nombre",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "CveEmpleado",
                table: "Empleados");

            migrationBuilder.RenameTable(
                name: "Empleados",
                newName: "Empleado");

            migrationBuilder.RenameTable(
                name: "Departamentos",
                newName: "Departamento");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_DepartamentoId",
                table: "Empleado",
                newName: "IX_Empleado_DepartamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleado",
                table: "Empleado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departamento",
                table: "Departamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Departamento_DepartamentoId",
                table: "Empleado",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RubrosEncargados_Empleado_EmpleadoId",
                table: "RubrosEncargados",
                column: "EmpleadoId",
                principalTable: "Empleado",
                principalColumn: "Id");
        }
    }
}
