using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
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


        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();

            GravarUsandoEntity();
        }

        private static void GravarUsandoEntity()
        {
            // Entity - Criar uma classe que permitira a persistencia de todas as demais
            // classes.

            Produto p   = new Produto();
            p.Nome      = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco     = 19.89;

            using (var contexto = new LojaContext())
            {
                repo.Adicionar(p);
            }
        }

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
    }
}
