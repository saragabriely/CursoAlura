using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.HTML;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController : Controller
    {
        public IEnumerable<Livro> livros { get; set; }


        // static Task
        public string Detalhes(HttpContext context)
        {
            #region Colocando valor que não é inteiro - Tratamento
            /* Caso seja colocado um valor que não é inteiro ..
             * 
             * Atraves da RouteConstraints é possível colocar restrições para 
             * as rotas. 
             * 
             * Uma das restrições possiveis, é: aceitar apenas IDs inteiros!
             * 
             * Constraint: {id:int} -> mostra o tipo do parametro
             * 
             * builder.MapRoute("Livros/Detalhes/{id:int}", ExibirDetalhes);
             * 
             * . Antes dessa restrição, aparecia o erro com StatusCode 500,
             * e com a restrição aparece o 404!
             */
            #endregion

            // converte o valor passado para inteiro 
            int id = Convert.ToInt32(context.GetRouteValue("id"));

            // Repositorio
            var repo = new LivroRepositorioCSV();

            // Busca pelo ID
            var livro = repo.Todos.First(l => l.Id == id);

            // retorna os detalhes via Response
            return livro.Detalhes(); // context.Response.WriteAsync(livro.Detalhes())
        }

        #region Razor - Motor de views (Views enginee)
        /*
         * Na lógica inicial do CarregaLista, era percorrida a lista de livros
         * cadastrados, e "#NOVO-ITEM#" era substituido por um novo livro.
         * 
         * Agora, o Framework delega a responsabilidade de criar o HTML para o
         * "View Enginee" (motor de views!) - Que se encarrega de juntar as 
         * informações/objetos que estão no controller com o HTML, e irá gerar  
         * um HTML de resposta.  E cada motor de view, tem a sua regra. E o motor
         * padrão que vem é o RAZOR!
         * 
         * O Razor possui algumas regras, e uma delas é: a extensão do arquivo html
         * deverá ser "cshtml" (cs - csharp - é possível colocar C# dentro do 
         * arquivo que contêm o HTML).
         * 
         * O FOREACH do método "CarregaLista" será colocado no arquivo .cshtml
         * e então retirado do método!
             */
        #endregion

        #region CarregaLista
        public static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");
            
            return conteudoArquivo.Replace("#NOVO-ITEM#", "");
        }

        #region OLD
        /*
         public static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");

            // Os livros serão adicionados no HTML dinamicamente!
            // o "#NOVO-ITEM#" será substituido pelo Titulo e Autor dos livros,
            // e cada item receberá um <li></li> (item da lista)
            foreach (var livro in livros)
            {
                conteudoArquivo =
                    conteudoArquivo.Replace("#NOVO-ITEM#",
                    $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }

            return conteudoArquivo.Replace("#NOVO-ITEM#", "");
        }*/
        #endregion
        #endregion
            
        // Isolando o código de cada request -----------------------------
        // Dessa forma é possível adicionar código/regras de negócio de acordo com 
        // cada Request, sem afetar os demais.

        // o método deve ser estático para que possa ser feita referencia a ele

        #region Action ParaLer
        public IActionResult ParaLer() // HttpContext context
        {
            var _repo = new LivroRepositorioCSV();

            ViewBag.Livros = _repo.ParaLer.Livros; // Passa as informações  para a tela (html)

            //var html = CarregaLista(_repo.ParaLer.Livros);
            //var html = new ViewResult { ViewName = "Lista" };

            return View("Lista");// html; // context.Response.WriteAsync(html);
        }
        #region OLD
        /*
         public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            var html = CarregaLista(_repo.ParaLer.Livros);

            return context.Response.WriteAsync(html);
        }
             */
        #endregion
        #endregion


        #region Lendo
        public IActionResult Lendo() // HttpContext contexto
        {
            var _repo = new LivroRepositorioCSV();

            //var html = CarregaLista(_repo.Lendo.Livros);
            ViewBag.Livros = _repo.Lendo.Livros;
            return View("Lista"); // contexto.Response.WriteAsync(html);
        }
        #region Old
        /*
         public static Task Lendo(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();

            return contexto.Response.WriteAsync(_repo.Lendo.ToString());
        }*/
        #endregion
        #endregion

        #region Lidos
        public IActionResult Lidos() // HttpContext contexto
        {
            var _repo = new LivroRepositorioCSV();

            //var html = CarregaLista(_repo.Lidos.Livros);
            ViewBag.Livros = _repo.Lidos.Livros;

            return View("Lista"); // contexto.Response.WriteAsync(html);
        }

        #region Old
        /*
         public static Task Lidos(HttpContext contexto)
        {
            var html = CarregaLista(_repo.Lidos.Livros);

            return contexto.Response.WriteAsync(html);
        }*/
        #endregion
        #endregion


        // TESTE
        //public static Task Teste(HttpContext context)
        //{
        //    return context.Response.WriteAsync("nova funcionalidade implementada!");
        //}

        public string Teste() // HttpContext context
        {
            return "nova funcionalidade implementada!";
        }

    }
}
