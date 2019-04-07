using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        // Para o ASP.NET Core, cada rota tem que ser encapsulada em um objeto!

        // Criar uma coleção de objetos que representem rotas.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            #region Comentários iniciais
            // Será configurada a sequencia: chegou tal método, a resposta será tal
            // Isso é feito através do Request Pipeline - fluxo de requisição
            // resposta! E fica em um tipo do ASP.NET Core: IApplicationBuilder

            // será executado o método. ´é necessário colocar um request delegate
            // dentro do run = método que tem como retorno o tipo Task!
            #endregion

            // RouteBuilder - classe responsável por construir as rotas
            // e recebe como argumento de entrada a aplicação que estamos configurando
            var builder = new RouteBuilder(app);

            // recebe os mesmos argumentos do dicionário
            builder.MapRoute("Livros/ParaLer", LivrosPraLer);
            builder.MapRoute("Livros/Lendo",  LivrosLendo);
            builder.MapRoute("Livros/Lidos",   LivrosLidos);

            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);

            // construir as rotas (construção de métod complexos - Build)
            var rotas = builder.Build();

            app.UseRouter(rotas);

            // app.Run(Roteamento); // (LivrosPraLer)
        }

        // Request delegate
        public Task NovoLivroParaLer(HttpContext context)
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

        #region 03 - Aula 03 - Rotas com template 
        /*
         * Rotas com templates: rotas com {} e valor, como:
         * /Cadastro/NovoLivro/{nome}/{autor}.
         * 
         * Ao criar uma rota com template, está criando uma rota que irá se 
         *  adequar a vários endereços diferentes.
        */
        #endregion

        #region 02 - Aula 01 - Roteamento - Criação
        // Antes de criar o método Hoteamento, qualquer endereço que fosse colocado
        // no navegador (localhost:5000/ler ou /lidos ou /contatos) retornaria
        // o mesmo resultado!

        // E para mudar isso, para mudar a resposta de acordo com a requisição ...
        // A classe que faz a configuração do pipeline de requisição: 
        // classe Startup, mais especificamente o método Configure!
        #endregion

        #region 02 - Aula 03 - Melhorando a lógica de tratamento de requisições
        // Caso seja necessário o acesso a banco de dados, ou utilizar um recurso,
        // ou repositório .. Logo, o direcionamento para as páginas nãó pode
        // ficar aqui!
        // 
        // A estrutura de dicionário limita neste caso! O codigo de tratamento de 
        // requisição deve ficar em um local isolado.

        // O método Run() recebe como argumento de entrada um método que é um
        // Delegate. Logo, ao invés de usar o valor do dicionário como uma string,
        // o tipo será um Request Delegate


        #endregion

        #region Roteamento(HttpContext context) - Primeiro roteamento
        public Task Roteamento(HttpContext context)
        {
            // Para ver qual é o endereço de uma requisição, o context tem 
            // todas as informações necessárias da requisição/endereço!

            // E o context possui uma propriedade para request
            var _repo = new LivroRepositorioCSV();

            // chave(string), valor (string) - antes
            var caminhosAtendidos = new Dictionary<string, RequestDelegate> 
            {
                { "/Livros/ParaLer", LivrosPraLer },  // _repo.ParaLer.ToString() 
                { "/Livros/Lendo",   LivrosLendo },   // _repo.Lendo.ToString()
                { "/Livros/Lidos",   LivrosLidos }    // _repo.Lidos.ToString()
            };
            // Caminhos que serão adotados:
            // Livros/ParaLer
            // Livros/Lendo
            // Livros/Lidos

            // Se o caminho estuver dentro do dicionário como chave
            if(caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                // chamar método referente
                var metodo = caminhosAtendidos[context.Request.Path];

                return metodo.Invoke(context);
            }

            context.Response.StatusCode = 404; // Recurso não encontrado.
            return context.Response.WriteAsync("Caminho inexistente.");

            // .Path pega apenas a parte do dominio, sem o localhost:5000 ...
           // return context.Response.WriteAsync(context.Request.Path);
        }
        #endregion

        // Isolando o código de cada request -----------------------------

        // Dessa forma é possível adicionar código/regras de negócio de acordo com 
        // cada Request, sem afetar os demais.

        public Task LivrosPraLer(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();

            return  contexto.Response.WriteAsync(_repo.ParaLer.ToString());

            #region Comentários iniciais
            // Aqui ainda não tem nada referente ao servidor web!
            // É preciso colocar essa lista na resposta (response).

            // Como colocar isos na resposta de uma requisição?
            // tudo o que estiver encapsulada em uma requisição especifica,
            // fica armazenada em um objeto de HttpContext!

            // O context tem uma propriedade que representa a resposta que será dada
            // Método para escrever: .Response.WriteAsync()
            #endregion
        }

        public Task LivrosLendo(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();

            return contexto.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();

            return contexto.Response.WriteAsync(_repo.Lidos.ToString());
        }
    }
}