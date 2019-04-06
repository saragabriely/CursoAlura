using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // Será configurada a sequencia: chegou tal método, a resposta será tal
            // Isso é feito através do Request Pipeline - fluxo de requisição
            // resposta! E fica em um tipo do ASP.NET Core: IApplicationBuilder

            // será executado o método. ´é necessário colocar um request delegate
            // dentro do run = método que tem como retorno o tipo Task!
            app.Run(Hoteamento); // (LivrosPraLer)

        }

        // Antes de criar o método Hoteamento, qualquer endereço que fosse colocado
        // no navegador (localhost:5000/ler ou /lidos ou /contatos) retornaria
        // o mesmo resultado!

        // E para mudar isso, para mudar a resposta de acordo com a requisição ...
        // A classe que faz a configuração do pipeline de requisição: 
        // classe Startup, mais especificamente o método Configure!

        public Task Hoteamento(HttpContext context)
        {
            // Para ver qual é o endereço de uma requisição, o context tem 
            // todas as informações necessárias da requisição/endereço!

            // E o context possui uma propriedade para request

            var _repo = new LivroRepositorioCSV();

            var caminhosAtendidos = new Dictionary<string, string> // chave, valor
            {
                { "/Livros/ParaLer", _repo.ParaLer.ToString() },
                { "/Livros/Lendo",   _repo.Lendo.ToString() },
                { "/Livros/Lidos",   _repo.Lidos.ToString() }
            };
            // Caminhos que serão adotados:
            // Livros/ParaLer
            // Livros/Lendo
            // Livros/Lidos

            // Se o caminho estuver dentro do dicionário como chave
            if(caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                return context.Response.WriteAsync(
                                        caminhosAtendidos[context.Request.Path]);
            }

            context.Response.StatusCode = 404; // Recurso não encontrado.
            return context.Response.WriteAsync("Caminho inexistente.");

            // .Path pega apenas a parte do dominio, sem o localhost:5000 ...
           // return context.Response.WriteAsync(context.Request.Path);
        }

        public Task LivrosPraLer(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();

            return  contexto.Response.WriteAsync(_repo.ParaLer.ToString());

            // Aqui ainda não tem nada referente ao servidor web!
            // É preciso colocar essa lista na resposta (response).

            // Como colocar isos na resposta de uma requisição?
            // tudo o que estiver encapsulada em uma requisição especifica,
            // fica armazenada em um objeto de HttpContext!

            // O context tem uma propriedade que representa a resposta que será dada
            // Método para escrever: .Response.WriteAsync()

        }

    }
}