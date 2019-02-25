using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaAgencia
{
    class Program
    {
        // Módulo 06 - Strings, expressões regulares e classe object

        static void Main(string[] args)
        {
            #region Comentários - Sobrecargas do WriteLine
            /*
             Console.WriteLine("Olá, mundo!")

            Olá mundo - É uma string;
            WRITELINE - É um método público;
            CONSOLE   - É uma classe pública. 
            
             public static void WriteLine(string argumento)
             {
                 // Implementação
             }

             public static void WriteLine(int argumento)
             {
                 // Implementação
             }

             public static void WriteLine(double argumento)
             {
                 // Implementação
             }

             public static void WriteLine(bool argumento)
             {
                 // Implementação
             }
             */
            #endregion

            Console.WriteLine("Olá, mundo!");   // String
            Console.WriteLine(123);             // Int
            Console.WriteLine(10.5);            // Double
            Console.WriteLine(true);            // Bool

            // Object é um tipo criado no .NET, que é o 'pai' de todos os objetos/classes
            // Todas as classes derivam do tipo 'OBJECT'

            ContaCorrente conta  = new ContaCorrente(1236, 5653256);
            object        conta1 = new ContaCorrente(1236, 5653256);

            string contaToString = conta1.ToString();

            // ToString = Permite ser sobrescrito

            Console.WriteLine("Conta Corrente: " + conta);
            Console.WriteLine("Conta ToString: " + contaToString);

            // ----------------------------------------------------------
            // Teste

            Cliente carlos_1 = new Cliente();

            carlos_1.Nome      = "Carlos";
            carlos_1.CPF       = "458.236.123-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();

            carlos_2.Nome      = "Carlos";
            carlos_2.CPF       = "458.236.123-03";
            carlos_2.Profissao = "Designer";

            ContaCorrente conta_2 = new ContaCorrente(456, 87654);

            // Nunca será igual, pois são objetos diferentes - armazenados em
            // diferentes endereços na memória (sem levar em consideração 
            // o conteúdo de cada objeto)
            // if (carlos_1 == carlos_2)  ou if (carlos_1.Equals(carlos_2))   

            Console.WriteLine(); // Pula linha 

            if (carlos_1.Equals(carlos_2))    
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Sao diferentes!");
            }

            Console.ReadLine();
        }

        static void TestaString()
        {
            #region Regex - e trabalhando com texto livre (sem padrão)

            // Olá, meu nome é Tal e você pode entrar em contato comigo 
            // através do número 8457-4456!

            // Meu nome é tal, me ligue em 4784-4546.

            // Padrao - representa a sequencia dos numeros 
            // string padrao =  "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // ou
            // string padrao =  "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"; // 0-9 -> Intervalo
            // ou
            // string padrao =  "[0-9]{4,5}[-]{0,1}[0-9]{4}"; // {4} - padrão se repete 4 vezes
            // {4,5} - espera de 4 a 5 digitos/padroes

            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            // {} - Quantificador! Mostra quantos caracteres serão esperados

            // 45654-5464 ou  456545464
            
            string textoDeTeste = "Meu nome é tal, me ligue em 4784-4546";

            // Recupera expressões regulares - REGEX
            // Não tem ligação com indices! Segue apenas o padrão definido.

            //Console.WriteLine(Regex.IsMatch(textoDeTeste, padrao)); // Retorna um bool
            // Retorno inicial: true! O padrão foi encontrado na string de teste

            Match resultado = Regex.Match(textoDeTeste, padrao);
            // Retorna um objeto que respeita o padrão definido

            Console.WriteLine(resultado.Value);

            Console.ReadLine();

            #endregion

            // ------------------------------------------------------------

            #region Teste - StartsWith, EndsWith e Contains

            // string urlTeste = "https://google.com/?q=https://www.bytebank.com/cambio";

            string urlTeste = "https://www.bytebank.com/cambio";
            string teste3 = "https://www.bytebank.com";

            int indiceByteBank = urlTeste.IndexOf(teste3);

            // Console.WriteLine(indiceByteBank == 0);

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com")); // Retorna um booleano
            Console.WriteLine(urlTeste.EndsWith("cambio")); // Retorna um booleano

            Console.WriteLine(urlTeste.Contains("bytebank")); // booleano // case sensitive

            Console.ReadLine();

            #endregion

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

            //-------------------------------------

            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            ExtratorValorDeArgumentosURL extratorDeValores =
                new ExtratorValorDeArgumentosURL(urlParametros);

            string valorDestino = extratorDeValores.GetValor("moedaDestino");
            string valorOrigem = extratorDeValores.GetValor("moedaOrigem");

            Console.WriteLine("Valor de moeda Origem: " + valorOrigem);

            Console.WriteLine("Valor de moeda Destino: " + valorDestino);

            Console.WriteLine(extratorDeValores.GetValor("valor"));

            //  Console.WriteLine(extratorDeValores.GetValor("Valor")); // resultado diferente

            Console.ReadLine();

            //-------------------------------------

            // Teste - ToLower e ToUpper

            string mensagemOrigem = "PALAVRA";
            string termoBusca = "ra";

            Console.WriteLine(mensagemOrigem.ToUpper());

            Console.WriteLine(mensagemOrigem.ToLower());

            // Testando 'Replace'
            termoBusca = termoBusca.Replace('r', 'R');

            Console.WriteLine("Termo busca = " + termoBusca);

            termoBusca = termoBusca.Replace('a', 'A');

            Console.WriteLine("Termo busca = " + termoBusca);

            Console.WriteLine(mensagemOrigem.IndexOf(termoBusca));
        
            Console.ReadLine();

            //------------

            // Teste - Remoção

            string testeRemocao = "primeiraParte&parteParaRemover";

            int indiceEComercial = testeRemocao.IndexOf('&');

            // Remove - Remove parte da string a partir de um indice
            Console.WriteLine("Teste remoção: " + testeRemocao.Remove(indiceEComercial));

            Console.ReadLine();


            //-------------------------------------
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
        }

    }
}
