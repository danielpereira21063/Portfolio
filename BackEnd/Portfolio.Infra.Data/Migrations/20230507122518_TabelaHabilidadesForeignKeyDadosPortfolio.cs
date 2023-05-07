using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Infra.Data.Migrations
{
    public partial class TabelaHabilidadesForeignKeyDadosPortfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_DadosPortfolioId",
                table: "Habilidades",
                column: "DadosPortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_DadosPortfolios_DadosPortfolioId",
                table: "Habilidades",
                column: "DadosPortfolioId",
                principalTable: "DadosPortfolios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_DadosPortfolios_DadosPortfolioId",
                table: "Habilidades");

            migrationBuilder.DropIndex(
                name: "IX_Habilidades_DadosPortfolioId",
                table: "Habilidades");
        }
    }
}
