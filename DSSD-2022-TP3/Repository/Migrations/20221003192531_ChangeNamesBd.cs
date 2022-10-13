using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    public partial class ChangeNamesBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                newName: "estudiantes");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "estudiantes",
                newName: "usuario");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "estudiantes",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "estudiantes",
                newName: "mail");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "estudiantes",
                newName: "dni");

            migrationBuilder.RenameColumn(
                name: "Clave",
                table: "estudiantes",
                newName: "clave");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "estudiantes",
                newName: "celular");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "estudiantes",
                newName: "apellido");

            migrationBuilder.RenameColumn(
                name: "IdEstudiante",
                table: "estudiantes",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estudiantes",
                table: "estudiantes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_estudiantes",
                table: "estudiantes");

            migrationBuilder.RenameTable(
                name: "estudiantes",
                newName: "Estudiantes");

            migrationBuilder.RenameColumn(
                name: "usuario",
                table: "Estudiantes",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Estudiantes",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "mail",
                table: "Estudiantes",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "Estudiantes",
                newName: "Dni");

            migrationBuilder.RenameColumn(
                name: "clave",
                table: "Estudiantes",
                newName: "Clave");

            migrationBuilder.RenameColumn(
                name: "celular",
                table: "Estudiantes",
                newName: "Celular");

            migrationBuilder.RenameColumn(
                name: "apellido",
                table: "Estudiantes",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Estudiantes",
                newName: "IdEstudiante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "IdEstudiante");
        }
    }
}
