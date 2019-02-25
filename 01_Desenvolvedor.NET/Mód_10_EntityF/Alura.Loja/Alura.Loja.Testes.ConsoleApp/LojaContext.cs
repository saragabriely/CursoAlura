using System;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Alura.Loja.Testes.ConsoleApp
{
    //  :IDisposable
    public class LojaContext : DbContext 
    {
        // Essa classe deve permitir a utilização da API do Entity, e para isso 
        // a classe deve herdar de DbContext

        public DbSet<Produto> Produtos { get; set; }

        // Método de configuração do LojaContext
        protected override void OnConfiguring(DbContextOptionBuilder optionBuilder)
        {
            
        }
    }
}