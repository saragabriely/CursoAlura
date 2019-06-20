using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CasaDoCodigo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Adição de serviços: SQL Server, log, e etc.

            services.AddMvc();

            string connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            // INGEÇÃO DE DEPENDENCIA!
            // Instancia temporária!
            // Método que adiciona uma instancia que exista somente enquanto
            // os objetos que utilizarem essa instancia estiverem ativos
            services.AddTransient<IDataService, DataService>();

            services.AddTransient<IProdutoRepository,    ProdutoRepository>();
            services.AddTransient<IPedidoRepository,     PedidoRepository>();
            services.AddTransient<ICadastroRepository,   CadastroRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            IServiceProvider serviceProvider)
        {
            // os serviços adicionados acima serão consumidos nesse método
            // ou CONFIGURAÇÃO DE PIPELINE!

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Pedido}/{action=Carrossel}/{codigo?}");

                /*routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");*/
            });

            // gera uma nova instancia do ApplicationContext
            // serviceProvider.GetService<ApplicationContext>()
            //     .Database.Migrate(); //EnsureCreated(); // garante que ele gere o banco de dados
            //                                // caso ainda não exista

            serviceProvider.GetService<IDataService>().InicializaDB();

            #region Método EnsureCreated X Método Migrate
            /*
             * EnsureCreated **
               Ao excluir as tabelas do banco de dados, ao rodar o 'update-database'
               todo o banco é recriado!
               E para não precisar utilizar esse comando, a linha de código acima
               recria/cria o banco de dados caso ele não exista (faz o mesmo papel
               do 'update-database -verbose'. 
               * Ele não utiliza migrações! Ele verifica se banco ainda não foi criado
               * , caso ainda não exista, irá buscar o modelo para gerar o banco.
               * 
               * O problema é que ao utiliza-lo a primeira vez, não será possível aplicar
               * migrações no sistema!!
               * 
               * O EnsureCreated é recomendado para aplicações de teste!.

                * O recomendado é utilizar o 'Migrate' que utiliza migrações!
                * E ele permite que você adicione outras migrações, caso seja
                * necessário.
             */
            #endregion

        }
    }
}
