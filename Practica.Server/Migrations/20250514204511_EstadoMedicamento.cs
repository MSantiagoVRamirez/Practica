using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica.Server.Migrations
{
    /// <inheritdoc />
    public partial class EstadoMedicamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Medicamento",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Medicamento");
        }
    }
}
