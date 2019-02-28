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

        #region Comentários 02

        /*
         . Com o método ToList(), foi feito um SELECT no banco e trouxe todos os 
         produtos cadastrados,
             
        . Recapitularemos o que fizemos durante a aula. Quando usamos o método 
        Produtos.ToList(), fizemos um comando SQL SELECT no banco e recebemos os 
        produtos com o estado Unchanged

        . Após pegarmos o objeto Unchanged e alterarmos algum atributo, ele passa
        para o estado Modified.

        . Depois de usarmos o método SaveChanges(), é executado um comando SQL 
        UPDATE, modificado o estado do produto para Unchanged.
        
        . Quando criamos um produto e adicionamos ao contexto do Entity com o 
        método Produtos.Add(), o estado do produto fica Added.

        . Depois de usarmos novamente o método SaveChanges(), é executado um 
        comando SQL INSERT alterando o estado do produto para Unchaged.

        . Quando usamos o Produtos.Remove() em um objeto, ele passa para o 
        estado Deleted.

        . Quando salvamos as alterações ele passa a ser Detached, que representa 
        um objeto que não é mais rastreado pelo Entity. E claro, o produto também
        é removido do banco de dados.

        . Quando adicionamos um produto e ele é removido sem ter sido salvo com
        o SaveChanges(), ele passa de Added para Detached.

        */

        #endregion

        #region Resumo - Estados

        /*
         Added
	    . O objeto é novo, foi adicionado ao contexto, e o método SaveChanges ainda 
	    não foi executado. Depois que as mudanças são feitas, o estado do objeto muda 
	    para Unchanged. Objetos no estado Added não têm seus valores rastreados em 
	    sua instância de EntityEntry.

	    Deleted
	    . O objeto foi excluído do contexto. Depois que as mudanças foram salvas, seu
	    estado muda para Detached.

	    Detached
	    . O objeto existe, mas não está sendo monitorado. Uma entidade fica nesse 
	    estado imediatamente após ter sido criada e antes de ser adicionada ao 
	    contexto. Ela também fica nesse estado depois que foi removida do contexto 
	    através do método Detach ou se é carregada por um método com opção NoTracking.
	    Não existem instâncias de EntityEntry associadas a objetos com esse estado.

	    Modified
	    . Uma das propriedades escalares do objeto foi modificada e o método SaveChanges
	    ainda não foi executado. Quando o monitoramento automático de mudanças está 
	    desligado, o estado é alterado para Modified apenas quando o método 
	    DetectChanges é chamado. Quando as mudanças são salvas, o estado do objeto 
	    muda para Unchanged.

	    Unchanged
	    . O objeto não foi modificado desde que foi anexado ao contexto ou desde a 
	    última vez que o método SaveChanges foi chamado.
                 */

        #endregion

        static void Main(string[] args)
        {
            



            Console.ReadLine();
        }


        #region VerificandoEstados()
        /*
        static void VerificandoEstados()
        {
            using (var contexto = new LojaContext())
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

                var novoProduto = new Produto()
                {
                    Nome = "Sabão em pó",
                    Categoria = "Limpeza",
                    PrecoUnitario = 4.99
                };

                // Ao adicionar e deletar um produto em seguida, 
                // o produto não aparecerá no ChangeTracker e não emitirá nenhum SQL
                contexto.Produtos.Add(novoProduto);

                ExibirEntries(contexto.ChangeTracker.Entries());

                contexto.Produtos.Remove(novoProduto);

                // Deletar um produto qualquer que vier no contexto
                var p1 = produtos.First();

                // contexto.Produtos.Remove(p1);

                // Mostra as entidades que estão dentro do contexto
                ExibirEntries(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();     // Salva as alterações

                // Buscar o estado do objeto deletado
                var entry = contexto.Entry(novoProduto);
                // Entry é uma instancia do EntityEntry

                Console.WriteLine("\n\n" + entry.Entity.ToString() + " - " + entry.State);

                // Estado DETACHED - Desconectado (não está sendo mais monitorado).

                ExibirEntries(contexto.ChangeTracker.Entries());
            }
        }*/
        #endregion

        #region AdicionandoProduto(LojaContext contexto)
        /*
        static void AdicionandoProduto(LojaContext contexto)
        {
            var novoProduto = new Produto()
            {
                Nome = "Desinfetante",
                Categoria = "Limpeza",
                PrecoUnitario = 2.99
            };

            contexto.Produtos.Add(novoProduto);
        } */
        #endregion

        // Selecionando um código e clicando 'Ctrl + Ponto' - É possível criar um
        // método com o código selecionado.

        #region ExibirEntries(IEnumerable<EntityEntry> entries)
            /*
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
        } */
        #endregion

        #region ChangeTracker - 02
            /*
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
                 * /
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
                
                
            }
        } */
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
            /*
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
        } */
        #endregion

        #region ExcluirProdutos()
            /*
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
        } */
        #endregion

        #region RecuperarProdutos()
            /*
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
        } */
        #endregion

        #region GravarUsandoEntity()
        /*
        private static void GravarUsandoEntity()
        {
            // Entity - Criar uma classe que permitira a persistencia de todas as demais
            // classes.

            Produto p   = new Produto();
            p.Nome      = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var contexto = new ProdutoDAOEntity()) // LojaContext
            {
                contexto.Adicionar(p);

                //contexto.Produtos.Add(p);   // Criando produto no EF
                //contexto.SaveChanges();     // Salvando as mudanças
            }
        } */
        #endregion

        #region GravarUsandoAdoNet()
            /*
        private static void GravarUsandoAdoNet()
        {
            // O objetivo do ADO.NET era criar uma classe que representasse o 
            // DataAcessObject da classe que seria persistida.

            Produto p   = new Produto();
            p.Nome      = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        } */
        #endregion

        #endregion

    }
}
