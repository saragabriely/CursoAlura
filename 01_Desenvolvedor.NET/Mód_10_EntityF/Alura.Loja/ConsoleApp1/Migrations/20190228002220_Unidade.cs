using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class Unidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Coluna renomeada
            migrationBuilder.RenameColumn(
                name:  "Preco",
                table: "Produtos",
                newName: "PrecoUnitario");

            // Nova coluna
            migrationBuilder.AddColumn<string>(
                name: "Unidade",
                table: "Produtos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Para voltar a versão, caso necessite: será retirada a coluna Unidade
            // E a coluna PrecoUnitario será renomeada novamente
            migrationBuilder.DropColumn(
                name: "Unidade",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "Produtos",
                newName: "Preco");
        }
    }
}
