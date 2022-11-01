using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    public partial class NullFieldComision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "fecha",
                table: "comisiones",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "comisiones",
                keyColumn: "fecha",
                keyValue: null,
                column: "fecha",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "fecha",
                table: "comisiones",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
