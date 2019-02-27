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
    class Program
    {
        #region Comentários
        // Criando o Banco de Dados através do Visual Studio:
        // Exibir -> Pesquisador de Objetos do SQL Server 
        //            ou SQl Server Object Explorer
        // Selecionar (ao lado) Sql Server -> Databases -> Add new Database

        // Criar tabela
        // Tables -> Botão direito -> Adicionar nova tabela
        // Colar o script da tabela -> Selecionar 'UPDATE' (canto superior esquerdo)
        // E depois 'Update Database'

        // Como a aplicação está sendo usada sem o Entity
        // Ela utiliza o padrão de arquitetura Data Acess Object.
        #endregion

        static void Main(string[] args)
        {
            using(var contexto = new LojaContext())
            {
                // Provedor de serviços
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();

                // Serviço especifico - Irá criar loggers
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

                loggerFactory.AddProvider(SqlLoggerProvider.Create());


                var produtos = contexto.Produtos.ToList();

                // Mostra as entidades que estão dentro do contexto
                ExibirEntries(contexto.ChangeTracker.Entries());

                Console.WriteLine("----------------------");

                // var p1  = produtos.Last();
                // p1.Nome = "007 - O Espião Que Me Amava";   // Alteração

                // Adicionando
                //AdicionandoProduto(contexto);

                // Deletar um produto qualquer que vier no contexto
                var p1 = produtos.First();

                contexto.Produtos.Remove(p1);
                
                // Mostra as entidades que estão dentro do contexto
                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();     // Salva as alterações

                ExibirEntries(contexto.ChangeTracker.Entries());
            }


            Console.ReadLine();
        }

        static void AdicionandoProduto(LojaContext contexto)
        {
            var novoProduto = new Produto()
            {
                Nome = "Desinfetante",
                Categoria = "Limpeza",
                Preco = 2.99
            };

            contexto.Produtos.Add(novoProduto);
        }

        // Selecionando um código e clicando 'Ctrl + Ponto' - É possível criar um
        // método com o código selecionado.

        private static void ExibirEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("----------------------");

            foreach (var e in entries)
            {
                //Console.WriteLine(e.State); 

                // O Entry tem uma referencia para o objeto que foi adicionado
                // no contexto. A referencia fica na propriedade Entity

                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }

        #region ChangeTracker - 02
        static void ChangeTracker02()
        {
            using (var contexto = new LojaContext())
            {

                // O código abaixo irá mostrar o SQL que está sendo gerado e a 
                // relação com o estado de cada objeto.

                // Logando no SQL (necessário  configurar dois objetos)

                // Provedor de serviços
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();

                // Serviço especifico - Irá criar loggers
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

                // esse loggerFactory irá solicitar um logger especifico para pegar 
                // o SQL do Entity e colocar no logger do programa 
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                #region Resultado - SQL gerado pelo Entity (sem o SaveChanges)
                /* Resultado - SQL gerado pelo Entity (com o SaveChanges comentado)

                Executed DbCommand (30ms) [Parameters=[], CommandType='Text', 
                    CommandTimeout='30']
                
                SELECT [p].[Id], [p].[Categoria], [p].[Nome], [p].[Preco]
                FROM [Produtos] AS [p]
                 */
                #endregion

                var produtos = contexto.Produtos.ToList();

                foreach (var p in produtos)
                {
                    Console.WriteLine(p);

                    #region Método ToString()
                    // O  console irá chamar o método ToString(), e caso esse método
                    // não tenha sido implementado na classe de origem,
                    // o resultado será: 
                    // ConsoleApp1.Produto
                    // ConsoleApp1.Produto
                    #endregion
                }
                Console.WriteLine("----------------------");

                // ChangeTracker - Rastreia todas as mudanças que acontecem na 
                // instancia do contexto. E eem uma lista de todas as entidades
                // gerenciadas no momento - que é recuperada através do Entries()

                // O 'Entries' possui uma propriedade Estado (State)!
                // Caso a mudança de estado ocorra, o SaveChanges irá agir.
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    // Console.WriteLine(e);
                    Console.WriteLine(e.State); // Unchanged or Modified
                    // É mostrado o estado de cada registro retornado do BD.
                }

                Console.WriteLine("----------------------");

                var p1 = produtos.Last();
                p1.Nome = "007 - O Espião Que Me Amava";   // Alteração

                // contexto.SaveChanges();     // Salva as alterações

                Console.WriteLine("----------------------");

                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                /*
                Console.WriteLine("----------------------");

                var produtos_ = contexto.Produtos.ToList();
                foreach (var p in produtos_)
                {
                    Console.WriteLine(p);
                } */
                
            }
        }
        #endregion

        #region ChangeTracker - Estados Unchanged e Modified

        static void ChangeTrackerTeste()
        {
            // O ChangeTracker e os estados Unchanged e Modified

            using (var contexto = new LojaContext())
            {
                var produtos = contexto.Produtos.ToList();

                foreach (var p in produtos)
                {
                    Console.WriteLine(p);

                    #region Método ToString()
                    // O  console irá chamar o método ToString(), e caso esse método
                    // não tenha sido implementado na classe de origem,
                    // o resultado será: 
                    // ConsoleApp1.Produto
                    // ConsoleApp1.Produto
                    #endregion
                }
                Console.WriteLine("----------------------");

                // ChangeTracker - Rastreia todas as mudanças que acontecem na 
                // instancia do contexto. E eem uma lista de todas as entidades
                // gerenciadas no momento - que é recuperada através do Entries()

                // O 'Entries' possui uma propriedade Estado (State)!
                // Caso a mudança de estado ocorra, o SaveChanges irá agir.
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    // Console.WriteLine(e);
                    Console.WriteLine(e.State); // Unchanged or Modified
                    // É mostrado o estado de cada registro retornado do BD.
                }

                Console.WriteLine("----------------------");

                var p1 = produtos.Last();
                p1.Nome = "007 - O Espião Que Me Amava";   // Alteração

                // contexto.SaveChanges();     // Salva as alterações

                Console.WriteLine("----------------------");

                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                /*
                Console.WriteLine("----------------------");

                var produtos_ = contexto.Produtos.ToList();
                foreach (var p in produtos_)
                {
                    Console.WriteLine(p);
                } */
            }

        }
            #endregion

        #region Testes Iniciais
            /*
             // GravarUsandoAdoNet(); 
                // GravarUsandoEntity(); 
                // RecuperarProdutos(); 
                // ExcluirProdutos(); 
                // RecuperarProdutos(); 
                AtualizarProduto();

                Console.WriteLine(); // Pula linha
                Console.WriteLine("Aplicação finalizada ... ");
                 */

            #region AtualizarProduto()
            private static void AtualizarProduto()
        {
            // Incluir produto (tabela vazia)
            GravarUsandoEntity();
            RecuperarProdutos();

            // Atualiza
            using(var repo = new ProdutoDAOEntity()) // LojaContext
            {
                Produto primeiro = repo.Produtos().First(); // Pega o primeiro produto
                // repo.Produtos.First();

                primeiro.Nome = "Cassino Royale - Editado";

                repo.Atualizar(primeiro);

                // Esses métodos são utilizados caso o COntext (LojaContext)
                // esteja no 'using'
                // repo.Produtos.Update(primeiro);
                // repo.SaveChanges();
            }

            RecuperarProdutos();
        }
        #endregion

        #region ExcluirProdutos()
        private static void ExcluirProdutos()
        {
            using(var repo = new ProdutoDAOEntity())  // LojaContext
            {
                IList<Produto> produtos = repo.Produtos(); // repo.Produtos.ToList();

                foreach (var item in produtos)
                {
                    repo.Remover(item); // repo.Produtos.Remove(item);
                }
                // repo.SaveChanges(); // Salva as mudanças
                // Não é necessário Salvar, caso seja usada a classe ProdutoDAOEntity()
                // O salvar ficará dentro dessa classe
            }
        }
        #endregion

        #region RecuperarProdutos()
        private static void RecuperarProdutos()
        {
            using(var repo = new ProdutoDAOEntity()) // LojaContext
            {
                IList<Produto> produtos =  repo.Produtos(); // repo.Produtos.ToList();
                                                                   // converte a propriedade Produtos em uma lista

                if (produtos.Count == 0)
                {
                    Console.WriteLine("A tabela está vazia.");
                }

                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
                Console.WriteLine($"Foram encontrados {produtos.Count}");
            }
        }
        #endregion

        #region GravarUsandoEntity()
        private static void GravarUsandoEntity()
        {
            // Entity - Criar uma classe que permitira a persistencia de todas as demais
            // classes.

            Produto p   = new Produto();
            p.Nome      = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco     = 19.89;

            using (var contexto = new ProdutoDAOEntity()) // LojaContext
            {
                contexto.Adicionar(p);

                //contexto.Produtos.Add(p);   // Criando produto no EF
                //contexto.SaveChanges();     // Salvando as mudanças
            }
        }
        #endregion

        #region GravarUsandoAdoNet()
        private static void GravarUsandoAdoNet()
        {
            // O objetivo do ADO.NET era criar uma classe que representasse o 
            // DataAcessObject da classe que seria persistida.

            Produto p   = new Produto();
            p.Nome      = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco     = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
        #endregion

        #endregion

    }
}
