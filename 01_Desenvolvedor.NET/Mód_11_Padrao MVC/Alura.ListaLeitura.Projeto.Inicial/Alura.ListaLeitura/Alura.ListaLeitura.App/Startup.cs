using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public partial class Startup
    {
        // Para o ASP.NET Core, cada rota tem que ser encapsulada em um objeto!

        // Criar uma coleção de objetos que representem rotas.

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddMvc();
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

            #region Método inicial
            /*
             // RouteBuilder - classe responsável por construir as rotas
            // e recebe como argumento de entrada a aplicação que estamos configurando
            var builder = new RouteBuilder(app);

            // recebe os mesmos argumentos do dicionário
            builder.MapRoute("Livros/ParaLer",     LivrosLogica.LivrosParaLer);
            builder.MapRoute("Livros/Lendo",       LivrosLogica.LivrosLendo);
            builder.MapRoute("Livros/Lidos",       LivrosLogica.LivrosLidos);
            builder.MapRoute("Livros/Detalhes/{id:int}",          LivrosLogica.ExibirDetalhes);
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);
                        
            // rota sem template
            builder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibirFormulario);
            builder.MapRoute("Cadastro/Incluir",   CadastroLogica.ProcessaFormulario);

            // construir as rotas (construção de métod complexos - Build)
            var rotas = builder.Build();

            app.UseRouter(rotas); // app.Run(Roteamento); // (LivrosPraLer)*/
            #endregion

            #region Método inicial - 02
            /*
             // RouteBuilder - classe responsável por construir as rotas
            // e recebe como argumento de entrada a aplicação que estamos configurando
            var builder = new RouteBuilder(app);

            builder.MapRoute("[controller]/[action]", RoteamentoPadrao.TratamentoPadrao);
            
            // construir as rotas (construção de métod complexos - Build)
            var rotas = builder.Build();

            app.UseRouter(rotas); // app.Run(Roteamento); // (LivrosPraLer)
             */
            #endregion


            // Funcionalidade que mostra o porque o erro está ocorrendo,
            // e pode mostrar informações sensíveis! Por isso deve ser habilitado
            // apenas em servidores/aplicações de teste e não de produção.
            app.UseDeveloperExceptionPage();

            app.UseMvcWithDefaultRoute(); 
            // Essa linha substiui todo o código anterior
        }
    }
}