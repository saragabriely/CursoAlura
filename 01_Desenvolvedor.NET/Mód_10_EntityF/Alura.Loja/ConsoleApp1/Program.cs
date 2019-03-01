using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            
            using(var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory   = serviceProvider.GetService<ILoggerFactory>();

                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                // Relacionamento Um para Um
                var cliente = contexto.Clientes
                                      .Include(c => c.EnderecoDeEntrega)
                                      .FirstOrDefault();

                Console.
                    WriteLine($"Endereço de Entrega: " +
                              $"{cliente.EnderecoDeEntrega.Logradouro}");

                /*
                 var produto = contexto.Produtos
                                      .Include(p => p.Compras)
                                      .Where(p => p.Id == 2002 )
                                      .FirstOrDefault();
                 */

                // Filtrar compras acima de R$10
                var produto = contexto.Produtos
                                      //.Include(p => p.Compras)
                                      .Where(p => p.Id == 2002 )
                                      .FirstOrDefault();

                // Filtrar compras acima de R$10
                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    // Aqui é possível usar também: Count, Sum e outros.
                    .Load(); // Carrega

                // Carregamento explicito (código acima)
                // Usar o contexto - Para a Entry que está na referência Produto,
                // pegaremos a coleção representada na propriedade de navegação
                // Compras, e iremos fazer uma Query nela, onde será aplicada a 
                // condição - compras com preço maior que 10. E essa query
                // será carregada para a referencia Produto.
                
                //---------------------------------------------
                Console
                    .WriteLine($"\n Mostrando as compras do Produto {produto.Nome} \n");

                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item.Quantidade);
                }
            }
            
            Console.ReadLine();
        }

        private static void ExibeProdutosDaPromocao()
        {
            // 8 - Aula 03

            using (var contexto2 = new LojaContext())
            {
                // Recupera apenas a tabela Promoces
                //var promocao = contexto2.Promocoes.FirstOrDefault(); 

                // JOIN
                var promocao = contexto2.Promocoes
                                        // p.PRodutos - Entidade que está em Promocao
                                        // Relacionamento N pra N
                                        .Include(p => p.Produtos)
                                        .ThenInclude(pp => pp.Produto)
                                        .FirstOrDefault();

                Console.WriteLine("\n Mostrando os produtos \n");

                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var promocao = new Promocao();

                promocao.Descricao = "Queima Total Janeiro 2017";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataFinal = new DateTime(2017, 1, 31);

                var produtos = contexto.Produtos
                                       .Where(p => p.Categoria == "Bebidas")
                                       .ToList();

                // Adicionar os produtos
                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocoes.Add(promocao);

                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }
        }

        #region UmParaUm
        private static void UmParaUm()
        {
            var fulano = new Cliente();

            fulano.Nome = "Fulaninho de Tal";

            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Inválidos",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                // Código para logar o SQL no Console
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(fulano);

                contexto.SaveChanges();
            }
        }
        #endregion

        #region MuitosParaMuitos

        private static void MuitosParaMuitos()
        {
            // PRODUTOS
            var p1 = new Produto()
            {
                Nome = "Suco de Laranja",
                Categoria = "Bebidas",
                PrecoUnitario = 8.79,
                Unidade = "Litros"
            };

            var p2 = new Produto()
            {
                Nome = "Café",
                Categoria = "Bebidas",
                PrecoUnitario = 12.45,
                Unidade = "Gramas"
            };

            var p3 = new Produto()
            {
                Nome = "Macarrao",
                Categoria = "Alimentos",
                PrecoUnitario = 4.23,
                Unidade = "Gramas"
            };



            // PROMOÇÃO
            var promocaoDePascoa = new Promocao();

            promocaoDePascoa.Descricao = "Pascoa Feliz!";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataFinal = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            //promocaoDePascoa.Produtos.Add(new PromocaoProduto());
            //promocaoDePascoa.Produtos.Add(new Produto());
            //promocaoDePascoa.Produtos.Add(new Produto());


            using (var contexto = new LojaContext())
            {
                // Código para logar o SQL no Console
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                //contexto.Promocoes.Add(promocaoDePascoa);

                // ExibirEntries(contexto.ChangeTracker.Entries());

                // Excluir a promoção
                var promocao = contexto.Promocoes.Find(1);

                contexto.Promocoes.Remove(promocao);

                ExibirEntries(contexto.ChangeTracker.Entries());



                contexto.SaveChanges();

            }
        }

        #endregion

        #region Relacionamento_01
        /* // Final da aula 05 - Mód. 10 - Entity
        static void Relacionamento_01()
        {
            // Veremos como o Entity trata o relacionamento entre compra e produto

            // Compra de 6 pães francês

            var paoFrances = new Produto();

            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();

            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                // Código para logar o SQL no Console
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Compras.Add(compra);   // Adicionando o objeto Compra

                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();         // Salva alterações

                ExibirEntries(contexto.ChangeTracker.Entries());
            }
        } */
        #endregion




    }
}
