using Microsoft.EntityFrameworkCore.Migrations;

namespace GftImoveis.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bairros_Municipios_MunicipioId",
                table: "Bairros");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Bairros_BairroId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Municipios_MunicipioID",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Negocios_NegocioId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Quartos_QuartoId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Enderecos_EnderecoId",
                table: "Municipios");

            migrationBuilder.AddForeignKey(
                name: "FK_Bairros_Municipios_MunicipioId",
                table: "Bairros",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Bairros_BairroId",
                table: "Imoveis",
                column: "BairroId",
                principalTable: "Bairros",
                principalColumn: "BairroId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Municipios_MunicipioID",
                table: "Imoveis",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Negocios_NegocioId",
                table: "Imoveis",
                column: "NegocioId",
                principalTable: "Negocios",
                principalColumn: "NegocioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Quartos_QuartoId",
                table: "Imoveis",
                column: "QuartoId",
                principalTable: "Quartos",
                principalColumn: "QuartoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Enderecos_EnderecoId",
                table: "Municipios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bairros_Municipios_MunicipioId",
                table: "Bairros");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Bairros_BairroId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Municipios_MunicipioID",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Negocios_NegocioId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Quartos_QuartoId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Enderecos_EnderecoId",
                table: "Municipios");

            migrationBuilder.AddForeignKey(
                name: "FK_Bairros_Municipios_MunicipioId",
                table: "Bairros",
                column: "MunicipioId",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Bairros_BairroId",
                table: "Imoveis",
                column: "BairroId",
                principalTable: "Bairros",
                principalColumn: "BairroId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Enderecos_EnderecoId",
                table: "Imoveis",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Municipios_MunicipioID",
                table: "Imoveis",
                column: "MunicipioID",
                principalTable: "Municipios",
                principalColumn: "MunicipioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Negocios_NegocioId",
                table: "Imoveis",
                column: "NegocioId",
                principalTable: "Negocios",
                principalColumn: "NegocioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Quartos_QuartoId",
                table: "Imoveis",
                column: "QuartoId",
                principalTable: "Quartos",
                principalColumn: "QuartoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Enderecos_EnderecoId",
                table: "Municipios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
