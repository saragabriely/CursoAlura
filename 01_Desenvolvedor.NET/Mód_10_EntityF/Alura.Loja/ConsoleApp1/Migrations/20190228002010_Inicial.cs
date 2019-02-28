using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id          = table.Column<int>(nullable: false)
                                    .Annotation("SqlServer:ValueGenerationStrategy",
                                    SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome        = table.Column<string>(nullable: true),
                    Categoria   = table.Column<string>(nullable: true),
                    Preco       = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            // O código deste método foi comentado para executar corretamente o 
            // comando Update-Database. E dessa forma,  são criados registros
            // na tabela de controle de versões.

            // Após isso, ao rodar o comando Update-Database, será rodada 
            // apenas a migração Unidade, pq a Inicial já está registrada.
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
