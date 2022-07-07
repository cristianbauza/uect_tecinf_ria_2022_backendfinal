using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class IdEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_PreviaId",
                table: "Previaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_UnidadCurricularId",
                table: "Previaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadesCurriculares_Materias_MateriasId",
                table: "UnidadesCurriculares");

            migrationBuilder.RenameColumn(
                name: "MateriasId",
                table: "UnidadesCurriculares",
                newName: "MateriasId_Materia");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UnidadesCurriculares",
                newName: "Id_UnidadCurricular");

            migrationBuilder.RenameIndex(
                name: "IX_UnidadesCurriculares_MateriasId",
                table: "UnidadesCurriculares",
                newName: "IX_UnidadesCurriculares_MateriasId_Materia");

            migrationBuilder.RenameColumn(
                name: "UnidadCurricularId",
                table: "Previaturas",
                newName: "UnidadCurricularId_UnidadCurricular");

            migrationBuilder.RenameColumn(
                name: "PreviaId",
                table: "Previaturas",
                newName: "PreviaId_UnidadCurricular");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Previaturas",
                newName: "Id_Previatura");

            migrationBuilder.RenameIndex(
                name: "IX_Previaturas_UnidadCurricularId",
                table: "Previaturas",
                newName: "IX_Previaturas_UnidadCurricularId_UnidadCurricular");

            migrationBuilder.RenameIndex(
                name: "IX_Previaturas_PreviaId",
                table: "Previaturas",
                newName: "IX_Previaturas_PreviaId_UnidadCurricular");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Materias",
                newName: "Id_Materia");

            migrationBuilder.AddForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_PreviaId_UnidadCurricular",
                table: "Previaturas",
                column: "PreviaId_UnidadCurricular",
                principalTable: "UnidadesCurriculares",
                principalColumn: "Id_UnidadCurricular",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_UnidadCurricularId_UnidadCu~",
                table: "Previaturas",
                column: "UnidadCurricularId_UnidadCurricular",
                principalTable: "UnidadesCurriculares",
                principalColumn: "Id_UnidadCurricular",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadesCurriculares_Materias_MateriasId_Materia",
                table: "UnidadesCurriculares",
                column: "MateriasId_Materia",
                principalTable: "Materias",
                principalColumn: "Id_Materia",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_PreviaId_UnidadCurricular",
                table: "Previaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_UnidadCurricularId_UnidadCu~",
                table: "Previaturas");

            migrationBuilder.DropForeignKey(
                name: "FK_UnidadesCurriculares_Materias_MateriasId_Materia",
                table: "UnidadesCurriculares");

            migrationBuilder.RenameColumn(
                name: "MateriasId_Materia",
                table: "UnidadesCurriculares",
                newName: "MateriasId");

            migrationBuilder.RenameColumn(
                name: "Id_UnidadCurricular",
                table: "UnidadesCurriculares",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UnidadesCurriculares_MateriasId_Materia",
                table: "UnidadesCurriculares",
                newName: "IX_UnidadesCurriculares_MateriasId");

            migrationBuilder.RenameColumn(
                name: "UnidadCurricularId_UnidadCurricular",
                table: "Previaturas",
                newName: "UnidadCurricularId");

            migrationBuilder.RenameColumn(
                name: "PreviaId_UnidadCurricular",
                table: "Previaturas",
                newName: "PreviaId");

            migrationBuilder.RenameColumn(
                name: "Id_Previatura",
                table: "Previaturas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Previaturas_UnidadCurricularId_UnidadCurricular",
                table: "Previaturas",
                newName: "IX_Previaturas_UnidadCurricularId");

            migrationBuilder.RenameIndex(
                name: "IX_Previaturas_PreviaId_UnidadCurricular",
                table: "Previaturas",
                newName: "IX_Previaturas_PreviaId");

            migrationBuilder.RenameColumn(
                name: "Id_Materia",
                table: "Materias",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_PreviaId",
                table: "Previaturas",
                column: "PreviaId",
                principalTable: "UnidadesCurriculares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Previaturas_UnidadesCurriculares_UnidadCurricularId",
                table: "Previaturas",
                column: "UnidadCurricularId",
                principalTable: "UnidadesCurriculares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnidadesCurriculares_Materias_MateriasId",
                table: "UnidadesCurriculares",
                column: "MateriasId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
