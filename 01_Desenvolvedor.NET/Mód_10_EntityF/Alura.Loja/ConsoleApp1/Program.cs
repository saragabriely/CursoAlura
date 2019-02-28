using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Veremos como o Entity trata o relacionamento entre compra e produto

            // Compra de 6 pães francês

            var paoFrances = new Produto();

            paoFrances.Nome          = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade       = "Unidade";
            paoFrances.Categoria     = "Padaria";

            var compra = new Compra();

            compra.Quantidade = 6;
            compra.Produto    = paoFrances;
            compra.Preco      = paoFrances.PrecoUnitario * compra.Quantidade;

            using(var contexto = new LojaContext())
            {
                // Código para logar o SQL no Console
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory   = serviceProvider.GetService<ILoggerFactory>();

                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Compras.Add(compra);   // Adicionando o objeto Compra

                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();         // Salva alterações

                ExibirEntries(contexto.ChangeTracker.Entries());
            }
            
            Console.ReadLine();
        }



    }
}
