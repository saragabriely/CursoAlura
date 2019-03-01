using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp1
{
    // DbContext é a classe base de toda a API do Entity Framework

    public class LojaContext : DbContext
    {
         // Essa classe deve permitir a utilização da API do Entity, e para isso 
        // a classe deve herdar de DbContext

        // Quando o entity começa a mapear as classes através das propriedades,
        // ele também navega pelas propriedades, e chegando na propriedade
        // EnderecoDeEntrega, ela será mapeada pelo Entity

        public DbSet<Produto>  Produtos   { get; set; }
        public DbSet<Compra>   Compras    { get; set; }
        public DbSet<Promocao> Promocoes  { get; set; }
        public DbSet<Cliente>  Clientes   { get; set; }
        // public DbSet<Endereco> Enderecos  { get; set; } -> caso queira
        // manipular manualmente essa classe.
        // Neste caso, não será criada uma propriedade DbSet para endereço,
        // pois tudo o que for feito nessa classe, estará relacionado com o Cliente

        // O nome atribuido no DbSet é o nome que será dado a tabela
        // Para mudar o nome de uma tabela que não está no DbSet, deverá ser 
        // feito através do OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // A entidade PromocaoProduto tem como chave primaria composta
            // PromocaoId e ProdutoId

            modelBuilder.Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            // Altera o nome da tabela Endereço
            modelBuilder.Entity<Endereco>().ToTable("Enderecos");

            modelBuilder.Entity<Endereco>().Property<int>("ClienteId");
            // é criada uma coluna na tabela Endereço que não será mapeada.
            // Shadow Property - Propriedade escondida (fica só no banco de dados),
            // não é possível instanciá-la ... 

            // Chave primária
            modelBuilder.Entity<Endereco>().HasKey("ClienteId");
        }

        // Método de configuração do LojaContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }

    /*
     Estava dando problema de acessibilidade na linha :

    " public DbSet<Produto> Produtos { get; set; } "

    Pois, a classe foi alterada de Internal para publica, porém a
    classe Produto também estava como internal, e deveria 
    ser alterada para public!   
     */

}