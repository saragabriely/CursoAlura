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
    public class CadastroController
    {
        #region ExibirFormulario()
        public IActionResult ExibirFormulario() // string // HttpContext context
        {
            // Irá retornar o resultado de uma Action (IActionResult)

            //var html = HtmlUtils.CarregaArquivoHTML("formulario");

            var html = new ViewResult { ViewName = "formulario" }; // formulario.html
                                                                   // representa o tipo de resultado HTML
            return html; // context.Response.WriteAsync(html)
        }
        #region OLD
        /*
         public static Task ExibirFormulario(HttpContext context)
        {
            var html = HtmlUtils.CarregaArquivoHTML("formulario");

            return context.Response.WriteAsync(html);
        }
             */
        #endregion
        #endregion

        

        #region  Incluir(HttpContext context)
        public string Incluir(Livro livro) // public static Task Incluir(HttpContext context)
        {
            #region Old
            /* var livro = new Livro()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor  = context.Request.Form["autor"].First()
            }; */
            #endregion

            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);

            return "Um livro foi adicionado com sucesso!";
            //return context.Response.WriteAsync("Um livro foi adicionado com sucesso!");
        }
        #endregion

        #region NovoLivro - Old
        /*
         * public static Task NovoLivro(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor  = context.GetRouteValue("autor").ToString()
            };

            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);

            return context.Response.WriteAsync("Um livro foi adicionado com sucesso!");
        }
         */
        #endregion

    }
}
