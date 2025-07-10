using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actividad4LegnProg3.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCampoPeriodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_EstudianteId",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_EstudianteId",
                table: "Calificaciones");

            migrationBuilder.AlterColumn<int>(
                name: "EstudianteId",
                table: "Calificaciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)");

            migrationBuilder.AddColumn<string>(
                name: "EstudianteMatricula",
                table: "Calificaciones",
                type: "nvarchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Periodo",
                table: "Calificaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_EstudianteMatricula",
                table: "Calificaciones",
                column: "EstudianteMatricula");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Estudiantes_EstudianteMatricula",
                table: "Calificaciones",
                column: "EstudianteMatricula",
                principalTable: "Estudiantes",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Estudiantes_EstudianteMatricula",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_EstudianteMatricula",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "EstudianteMatricula",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "Calificaciones");

            migrationBuilder.AlterColumn<string>(
                name: "EstudianteId",
                table: "Calificaciones",
                type: "nvarchar(15)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_EstudianteId",
                table: "Calificaciones",
                column: "EstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Estudiantes_EstudianteId",
                table: "Calificaciones",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
