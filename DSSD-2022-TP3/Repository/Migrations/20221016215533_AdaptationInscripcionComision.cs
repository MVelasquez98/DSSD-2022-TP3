using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    public partial class AdaptationInscripcionComision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fechaCierre",
                table: "inscripciones",
                newName: "fechaInicio");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "inscripciones",
                newName: "fechaFin");

            migrationBuilder.AddColumn<string>(
                name: "fecha",
                table: "comisiones",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha",
                table: "comisiones");

            migrationBuilder.RenameColumn(
                name: "fechaInicio",
                table: "inscripciones",
                newName: "fechaCierre");

            migrationBuilder.RenameColumn(
                name: "fechaFin",
                table: "inscripciones",
                newName: "fecha");
        }
    }
}
