using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgencia
{
    class Program
    {
        // Módulo 06 - Strings, expressões regulares e classe object

        static void Main(string[] args)
        {
            // www.bytebank.com.br/cambio**?`valor=1500`&`moedaOrigem=real`&`moedaDestino=dolar`**

            // Teste - Pegar uma parte da string (a partir/depois da interrogação)

            // pagina?argumentos
            // 012345678

            #region Teste - IsNullOrEmpty
            // string textoVazio = "";
            // Console.WriteLine(string.IsNullOrEmpty(textoVazio));

            // string - palavra reservada da linguagem
            // String (classe) ou string (palavra reservada) - é a mesma coisa
            #endregion

            string palavra = "moedaOrigem=real&moedaDestino=dolar";
            string nomeArgumento = "moedaDestino";

            int indice = palavra.IndexOf(nomeArgumento);

            Console.WriteLine(indice);
            
            // Resposta: 12
            Console.WriteLine("Tamanho da string (nomeArgumento): " + nomeArgumento.Length);

            // Resposta: moedaOrigem=real&moedaDestino=dolar
            Console.WriteLine(palavra);

            // Resposta: moedaDestino=dolar
            Console.WriteLine(palavra.Substring(indice));

            // Resposta: dolar
            Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length + 1));

            Console.ReadLine();

            // --------------------------

            ExtratorValorDeArgumentosURL extrator = 
                    new ExtratorValorDeArgumentosURL("teste");

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indiceInterrogacao = url.IndexOf("?"); // Descobre o indice do "?"

            Console.WriteLine(url); // Antes

            string argumentos = url.Substring(indiceInterrogacao + 1); // url.Substring(7);

            Console.WriteLine("Indice interrogacao: " + indiceInterrogacao); // Depois

            Console.WriteLine(argumentos); // Depois

            

            /*
             string temporaria = url + "sufixo";

            url = temporaria;

            ou url += "Sufixo";
             */

            Console.ReadLine();
        }



    }
}
