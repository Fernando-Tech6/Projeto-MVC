using Microsoft.EntityFrameworkCore.Migrations;

namespace GftImoveis.Migrations
{
    public partial class PrecoAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Imoveis",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Imoveis");
        }
    }
}
