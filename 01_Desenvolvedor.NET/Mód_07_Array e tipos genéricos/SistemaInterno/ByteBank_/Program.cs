using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank_
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
