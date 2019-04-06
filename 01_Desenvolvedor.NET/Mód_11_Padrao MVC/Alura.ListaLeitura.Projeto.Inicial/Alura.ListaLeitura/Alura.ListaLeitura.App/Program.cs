using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Alura.ListaLeitura.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var _repo = new LivroRepositorioCSV();

            // Para transformar a nossa aplicação em um servidor HTTP, 
            // usando o ASP NET Core, é preciso hospedar os pedidos.

            // Objeto que irá hospedar chamadas WEB - IWebHost
            // Para que a interface seja reconhecida, é necessário colocar o pacote
            // do ASP.NET Core. (Nuget)

           IWebHost host = new WebHostBuilder()
                .UseKestrel() // servidor que implementa o servidor HTTP
                .UseStartup<Startup>() // Classe para inicializar o Host
                .Build();
            //classe responsavel por construir um hospedeiro web
            // Build - Cria uma implementação dessa interface;

            

            // subir o hospedeiro
            host.Run();

            // ImprimeLista(_repo.ParaLer);
            // ImprimeLista(_repo.Lendo);
            // ImprimeLista(_repo.Lidos);
        }

        static void ImprimeLista(ListaDeLeitura lista)
        {
            Console.WriteLine(lista);
        }
    }
}
