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
        static void Main(string[] args) 
        {
            // CriarArquivo();

            // CriarArquivoComWriter();
            // Console.WriteLine("Aplicação finalizada");

            // TestaEscrita();

            /*
            // Teste das sobrecargas do WriteLine
            using(var fs = new FileStream("testaTipos.txt", FileMode.Create))
            {
                using (var escritor = new StreamWriter(fs))
                {
                    // Representação textual
                    escritor.WriteLine(true); // bool
                    escritor.WriteLine(false);
                    escritor.WriteLine(56565656);
                }
            } 
            Console.WriteLine("Aplicação finalizada");   */

            // EscritaBinaria();

            //LeituraBinaria();

            UsarStreamDeEntrada();


            //---------------------------------------------------
            Console.ReadLine();
        }
        
    }
} 
 