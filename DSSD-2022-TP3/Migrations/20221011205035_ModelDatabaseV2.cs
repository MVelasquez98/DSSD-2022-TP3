using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSSD_2022_TP3.Migrations
{
    public partial class ModelDatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "turnos",
                newName: "turno");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "tipos_de_usuario",
                newName: "tipoUsuario");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "materias",
                newName: "materia");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "carreras",
                newName: "carrera");

            migrationBuilder.UpdateData(
                table: "usuarios",
                keyColumn: "correo",
                keyValue: null,
                column: "correo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "correo",
                table: "usuarios",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dias",
                columns: table => new
                {
                    idDia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dias", x => x.idDia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "instancias",
                columns: table => new
                {
                    idInstancia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    instancia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instancias", x => x.idInstancia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipos_nota",
                columns: table => new
                {
                    idTipoNota = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoNota = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_nota", x => x.idTipoNota);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inscripciones",
                columns: table => new
                {
                    idInscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idInstancia = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    desde = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hasta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fecha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fechaCierre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    anio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscripciones", x => x.idInscripcion);
                    table.ForeignKey(
                        name: "FK_inscripciones_instancias_idInstancia",
                        column: x => x.idInstancia,
                        principalTable: "instancias",
                        principalColumn: "idInstancia",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "notas_comision",
                columns: table => new
                {
                    idComision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idTipoNota = table.Column<int>(type: "int", nullable: false),
                    nota = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas_comision", x => x.idComision);
                    table.ForeignKey(
                        name: "FK_notas_comision_tipos_nota_idTipoNota",
                        column: x => x.idTipoNota,
                        principalTable: "tipos_nota",
                        principalColumn: "idTipoNota",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notas_comision_usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comisiones",
                columns: table => new
                {
                    idComision = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idInscripcion = table.Column<int>(type: "int", nullable: false),
                    idTurno = table.Column<int>(type: "int", nullable: false),
                    idMateria = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idDia = table.Column<int>(type: "int", nullable: false),
                    rangoHorario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comision = table.Column<int>(type: "int", nullable: false),
                    anio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comisiones", x => x.idComision);
                    table.ForeignKey(
                        name: "FK_comisiones_dias_idDia",
                        column: x => x.idDia,
                        principalTable: "dias",
                        principalColumn: "idDia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comisiones_inscripciones_idInscripcion",
                        column: x => x.idInscripcion,
                        principalTable: "inscripciones",
                        principalColumn: "idInscripcion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comisiones_materias_idMateria",
                        column: x => x.idMateria,
                        principalTable: "materias",
                        principalColumn: "idMateria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comisiones_turnos_idTurno",
                        column: x => x.idTurno,
                        principalTable: "turnos",
                        principalColumn: "idTurno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comisiones_usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalle_inscripcion",
                columns: table => new
                {
                    idDetalleInscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idInscripcion = table.Column<int>(type: "int", nullable: false),
                    idComision = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fechaInscripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    baja = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_inscripcion", x => x.idDetalleInscripcion);
                    table.ForeignKey(
                        name: "FK_detalle_inscripcion_comisiones_idComision",
                        column: x => x.idComision,
                        principalTable: "comisiones",
                        principalColumn: "idComision",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_inscripcion_inscripciones_idInscripcion",
                        column: x => x.idInscripcion,
                        principalTable: "inscripciones",
                        principalColumn: "idInscripcion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_inscripcion_usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "historial_academico",
                columns: table => new
                {
                    idHistorialAcademico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idComsion = table.Column<int>(type: "int", nullable: false),
                    nota = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_academico", x => x.idHistorialAcademico);
                    table.ForeignKey(
                        name: "FK_historial_academico_comisiones_idComsion",
                        column: x => x.idComsion,
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
                name: "IX_comisiones_idDia",
                table: "comisiones",
                column: "idDia");

            migrationBuilder.CreateIndex(
                name: "IX_comisiones_idInscripcion",
                table: "comisiones",
                column: "idInscripcion");

            migrationBuilder.CreateIndex(
                name: "IX_comisiones_idMateria",
                table: "comisiones",
                column: "idMateria");

            migrationBuilder.CreateIndex(
                name: "IX_comisiones_idTurno",
                table: "comisiones",
                column: "idTurno");

            migrationBuilder.CreateIndex(
                name: "IX_comisiones_idUsuario",
                table: "comisiones",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_inscripcion_idComision",
                table: "detalle_inscripcion",
                column: "idComision");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_inscripcion_idInscripcion",
                table: "detalle_inscripcion",
                column: "idInscripcion");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_inscripcion_idUsuario",
                table: "detalle_inscripcion",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_historial_academico_idComsion",
                table: "historial_academico",
                column: "idComsion");

            migrationBuilder.CreateIndex(
                name: "IX_historial_academico_idUsuario",
                table: "historial_academico",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_inscripciones_idInstancia",
                table: "inscripciones",
                column: "idInstancia");

            migrationBuilder.CreateIndex(
                name: "IX_notas_comision_idTipoNota",
                table: "notas_comision",
                column: "idTipoNota");

            migrationBuilder.CreateIndex(
                name: "IX_notas_comision_idUsuario",
                table: "notas_comision",
                column: "idUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_inscripcion");

            migrationBuilder.DropTable(
                name: "historial_academico");

            migrationBuilder.DropTable(
                name: "notas_comision");

            migrationBuilder.DropTable(
                name: "comisiones");

            migrationBuilder.DropTable(
                name: "tipos_nota");

            migrationBuilder.DropTable(
                name: "dias");

            migrationBuilder.DropTable(
                name: "inscripciones");

            migrationBuilder.DropTable(
                name: "instancias");

            migrationBuilder.RenameColumn(
                name: "turno",
                table: "turnos",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "tipoUsuario",
                table: "tipos_de_usuario",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "materia",
                table: "materias",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "carrera",
                table: "carreras",
                newName: "nombre");

            migrationBuilder.AlterColumn<string>(
                name: "correo",
                table: "usuarios",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
