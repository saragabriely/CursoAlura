using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        /*
         DbContext é uma classe do namespace Microsoft.EntityFrameworkCore. Uma
         instância DbContext representa uma sessão com o banco de dados e pode 
         ser usada para consultar e salvar instâncias das suas entidades. 
         O DbContext é uma combinação dos padrões Unit Of Work e Repository.
        */

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Quando for criar o modelo, esse método será acessado para 
            // criar o mapeamento.

            base.OnModelCreating(modelBuilder);

            // vai registrar uma classe do modelo para mapeamento
            modelBuilder.Entity<Produto>().HasKey(t => t.Id);
            // HasKey: mostra que terá chave primária e diz qual é

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);

            // Relacionamento Pedido e Item pedido -> 1 para muitos
            modelBuilder.Entity<Pedido>()
                .HasMany(l => l.Itens)   // Relacionamento de ida: muitos
                .WithOne(t => t.Pedido); // relacionamento de volta: 1 (um para muitos)

            modelBuilder.Entity<Pedido>()
                .HasOne(t => t.Cadastro)    // Relacionamento Um para Um
                .WithOne(t => t.Pedido)
                .IsRequired();              // Atributo obrigatorio

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido);
        }
    }
}
