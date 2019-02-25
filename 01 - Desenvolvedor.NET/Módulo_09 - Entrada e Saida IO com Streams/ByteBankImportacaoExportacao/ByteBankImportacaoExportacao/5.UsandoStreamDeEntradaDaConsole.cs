using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // IO = Input e Output

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void UsarStreamDeEntrada()
        {
            // Acessar a console e capturar o stream já criado pelo console
            // OpenStandardInput - Retorna um stream - recupera o stream de entrada
            using (var fluxoDeEntrada = Console.OpenStandardInput())
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                    fs.Write(buffer, 0, bytesLidos);

                    fs.Flush();

                    Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
                }

            }
        }
    }
}