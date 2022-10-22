using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    public partial class NotaComisionRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comisiones_dias_idDia",
                table: "comisiones");

            migrationBuilder.DropForeignKey(
                name: "FK_comisiones_turnos_idTurno",
                table: "comisiones");

            migrationBuilder.DropTable(
                name: "historial_academico");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notas_comision",
                table: "notas_comision");

            migrationBuilder.AlterColumn<int>(
                name: "idComision",
                table: "notas_comision",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "idNotaComision",
                table: "notas_comision",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "fecha",
                table: "notas_comision",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "idTurno",
                table: "comisiones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "idDia",
                table: "comisiones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notas_comision",
                table: "notas_comision",
                column: "idNotaComision");

            migrationBuilder.CreateIndex(
                name: "IX_notas_comision_idComision",
                table: "notas_comision",
                column: "idComision");

            migrationBuilder.AddForeignKey(
                name: "FK_comisiones_dias_idDia",
                table: "comisiones",
                column: "idDia",
                principalTable: "dias",
                principalColumn: "idDia");

            migrationBuilder.AddForeignKey(
                name: "FK_comisiones_turnos_idTurno",
                table: "comisiones",
                column: "idTurno",
                principalTable: "turnos",
                principalColumn: "idTurno");

            migrationBuilder.AddForeignKey(
                name: "FK_notas_comision_comisiones_idComision",
                table: "notas_comision",
                column: "idComision",
                principalTable: "comisiones",
                principalColumn: "idComision",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comisiones_dias_idDia",
                table: "comisiones");

            migrationBuilder.DropForeignKey(
                name: "FK_comisiones_turnos_idTurno",
                table: "comisiones");

            migrationBuilder.DropForeignKey(
                name: "FK_notas_comision_comisiones_idComision",
                table: "notas_comision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notas_comision",
                table: "notas_comision");

            migrationBuilder.DropIndex(
                name: "IX_notas_comision_idComision",
                table: "notas_comision");

            migrationBuilder.DropColumn(
                name: "idNotaComision",
                table: "notas_comision");

            migrationBuilder.DropColumn(
                name: "fecha",
                table: "notas_comision");

            migrationBuilder.AlterColumn<int>(
                name: "idComision",
                table: "notas_comision",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "idTurno",
                table: "comisiones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idDia",
                table: "comisiones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_notas_comision",
                table: "notas_comision",
                column: "idComision");

            migrationBuilder.CreateTable(
                name: "historial_academico",
                columns: table => new
                {
                    idHistorialAcademico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idComision = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_academico", x => x.idHistorialAcademico);
                    table.ForeignKey(
                        name: "FK_historial_academico_comisiones_idComision",
                        column: x => x.idComision,
                        principalTable: "comisiones",
                        principalColumn: "idComision",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_historial_academico_usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_historial_academico_idComision",
                table: "historial_academico",
                column: "idComision");

            migrationBuilder.CreateIndex(
                name: "IX_historial_academico_idUsuario",
                table: "historial_academico",
                column: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_comisiones_dias_idDia",
                table: "comisiones",
                column: "idDia",
                principalTable: "dias",
                principalColumn: "idDia",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comisiones_turnos_idTurno",
                table: "comisiones",
                column: "idTurno",
                principalTable: "turnos",
                principalColumn: "idTurno",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
