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

            //-------------------------------------------------

            // FILE - Classe estática

            // File.ReadAllText // Retorna uma string com todo o conteúdo

            // FILE.WriteAllText - Cria um arquivo e grava informações dele.
            // Ideal para escrever pequenas coisas
            // Argumentos: Nome do arquivo, conteúdo do arquivo
            File.WriteAllText(
                    "escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

            Console.WriteLine("Arquivo escrevendoComAClasseFile.txt criado!");

            var bytesArquivo = File.ReadAllBytes("contas.txt");  // retorna um array de bytes

            Console.WriteLine($"Arquivo contas.txt possui: {bytesArquivo.Length} bytes");

            // FILE.ReadAllLines - Lê todas as linhas de um texto e fecha
            var linhas = File.ReadAllLines("contas.txt"); // devolve um array de string

            Console.WriteLine(linhas.Length);

            foreach (var linha in linhas)
            {
                Console.WriteLine(linha);
            } 


            Console.ReadLine();

            //-------------------------------------------------

            Console.WriteLine("Digite o seu nome: ");

            var nome = Console.ReadLine(); // retorna uma string
            // O ReadLine espera que o ENTER seja pressionado, então fará o encoding 
            // do que foi escrito (cadeira de bytes) e devolve como uma string

            Console.WriteLine(nome);

            // ------------------------------------------------

            UsarStreamDeEntrada();
            Console.WriteLine("Aplicação finalizada ... ");

            //---------------------------------------------------
            Console.ReadLine();
        }
        
    }
} 
 