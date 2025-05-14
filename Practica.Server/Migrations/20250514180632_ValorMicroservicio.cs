using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica.Server.Migrations
{
    /// <inheritdoc />
    public partial class ValorMicroservicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Categoria_categoriaId",
                table: "Medicamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamentos_Presentacion_presentacionId",
                table: "Medicamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicamentos",
                table: "Medicamentos");

            migrationBuilder.RenameTable(
                name: "Medicamentos",
                newName: "Medicamento");

            migrationBuilder.RenameIndex(
                name: "IX_Medicamentos_presentacionId",
                table: "Medicamento",
                newName: "IX_Medicamento_presentacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicamentos_categoriaId",
                table: "Medicamento",
                newName: "IX_Medicamento_categoriaId");

            migrationBuilder.AddColumn<decimal>(
                name: "valorTotal",
                table: "Presentacion",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "valor",
                table: "Medicamento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicamento",
                table: "Medicamento",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamento_Categoria_categoriaId",
                table: "Medicamento",
                column: "categoriaId",
                principalTable: "Categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamento_Presentacion_presentacionId",
                table: "Medicamento",
                column: "presentacionId",
                principalTable: "Presentacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicamento_Categoria_categoriaId",
                table: "Medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicamento_Presentacion_presentacionId",
                table: "Medicamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicamento",
                table: "Medicamento");

            migrationBuilder.DropColumn(
                name: "valorTotal",
                table: "Presentacion");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Medicamento");

            migrationBuilder.RenameTable(
                name: "Medicamento",
                newName: "Medicamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Medicamento_presentacionId",
                table: "Medicamentos",
                newName: "IX_Medicamentos_presentacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Medicamento_categoriaId",
                table: "Medicamentos",
                newName: "IX_Medicamentos_categoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicamentos",
                table: "Medicamentos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Categoria_categoriaId",
                table: "Medicamentos",
                column: "categoriaId",
                principalTable: "Categoria",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicamentos_Presentacion_presentacionId",
                table: "Medicamentos",
                column: "presentacionId",
                principalTable: "Presentacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
