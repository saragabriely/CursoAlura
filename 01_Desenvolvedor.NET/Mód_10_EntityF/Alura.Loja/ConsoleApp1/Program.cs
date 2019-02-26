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
                var produtos = contexto.Produtos.ToList();


            }




            Console.ReadLine();
        }

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
