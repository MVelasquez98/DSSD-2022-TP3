using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    public partial class RenameIdComision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historial_academico_comisiones_idComsion",
                table: "historial_academico");

            migrationBuilder.RenameColumn(
                name: "idComsion",
                table: "historial_academico",
                newName: "idComision");

            migrationBuilder.RenameIndex(
                name: "IX_historial_academico_idComsion",
                table: "historial_academico",
                newName: "IX_historial_academico_idComision");

            migrationBuilder.AddForeignKey(
                name: "FK_historial_academico_comisiones_idComision",
                table: "historial_academico",
                column: "idComision",
                principalTable: "comisiones",
                principalColumn: "idComision",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historial_academico_comisiones_idComision",
                table: "historial_academico");

            migrationBuilder.RenameColumn(
                name: "idComision",
                table: "historial_academico",
                newName: "idComsion");

            migrationBuilder.RenameIndex(
                name: "IX_historial_academico_idComision",
                table: "historial_academico",
                newName: "IX_historial_academico_idComsion");

            migrationBuilder.AddForeignKey(
                name: "FK_historial_academico_comisiones_idComsion",
                table: "historial_academico",
                column: "idComsion",
                principalTable: "comisiones",
                principalColumn: "idComision",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
