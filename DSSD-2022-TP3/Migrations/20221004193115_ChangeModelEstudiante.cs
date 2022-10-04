using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    public partial class ChangeModelEstudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mail",
                table: "estudiantes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "estudiantes",
                newName: "idEstudiante");

            migrationBuilder.AlterColumn<string>(
                name: "usuario",
                table: "estudiantes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "estudiantes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "dni",
                table: "estudiantes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "estudiantes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "celular",
                table: "estudiantes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "apellido",
                table: "estudiantes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "baja",
                table: "estudiantes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "correo",
                table: "estudiantes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "forzarClave",
                table: "estudiantes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "baja",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "correo",
                table: "estudiantes");

            migrationBuilder.DropColumn(
                name: "forzarClave",
                table: "estudiantes");

            migrationBuilder.RenameColumn(
                name: "idEstudiante",
                table: "estudiantes",
                newName: "id");

            migrationBuilder.UpdateData(
                table: "estudiantes",
                keyColumn: "usuario",
                keyValue: null,
                column: "usuario",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "usuario",
                table: "estudiantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "estudiantes",
                keyColumn: "nombre",
                keyValue: null,
                column: "nombre",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "estudiantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "estudiantes",
                keyColumn: "dni",
                keyValue: null,
                column: "dni",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "dni",
                table: "estudiantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "estudiantes",
                keyColumn: "clave",
                keyValue: null,
                column: "clave",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "estudiantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "estudiantes",
                keyColumn: "celular",
                keyValue: null,
                column: "celular",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "celular",
                table: "estudiantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "estudiantes",
                keyColumn: "apellido",
                keyValue: null,
                column: "apellido",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "apellido",
                table: "estudiantes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "mail",
                table: "estudiantes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
