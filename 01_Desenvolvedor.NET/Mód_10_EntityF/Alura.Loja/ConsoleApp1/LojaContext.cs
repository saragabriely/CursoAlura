using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleApp1
{
    public class LojaContext : DbContext
    {
         // Essa classe deve permitir a utilização da API do Entity, e para isso 
        // a classe deve herdar de DbContext

        public DbSet<Produto> Produtos { get; set; }

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