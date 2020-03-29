using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Alura.WebAPI.WebApp.Formatters
{
    public class LivroCsvFormatter : TextOutputFormatter
    {
        public LivroCsvFormatter()
        {
            // MediaTypeHeaderValue - usado para informar o valor do cabeçalho
            // para Media type
            var textCsvMediaType = MediaTypeHeaderValue.Parse("text/csv");
            var appCsvMediaType = MediaTypeHeaderValue.Parse("application/csv");
            this.SupportedMediaTypes.Add(appCsvMediaType);
            SupportedMediaTypes.Add(appCsvMediaType);
        }


        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, 
                                                    Encoding selectedEncoding)
        {
            // escrever o livro no formato .CSV

            var livroEmCsv = "";

            // livro será pego e transformado em CSV
            if(context.Object is LivroApi) // o objeto é do tipo 'LivroApi'
            {
                var livro = context.Object as LivroApi;

                livroEmCsv = $"{livro.Titulo};{livro.Subtitulo};{livro.Autor};" +
                             $"{livro.Lista}";
            }

            using (var escritor = context
                                    .WriterFactory(context.HttpContext.Response.Body, selectedEncoding))
            {
                return escritor.WriteAsync(livroEmCsv);
            } 
            //escritor.Dispose(); -- com o USING, esse método é chamado automaticamente
        }
    }
}
