using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Strings : IAulaItem
    {
        public void Executar()
        {
            string a = "bom dia";
            string b = "b";

            // fazer com que as duas strings sejam iguais, adicionando caracteres

            // Adiciona ao conteudo de "b"
            b += "om dia";

            // Comparação

            Console.WriteLine($"a == b: {a == b}"); // TRUE
            Console.WriteLine();

            // STRING É UM TIPO DE REFERÊNCIA! E NÃO DE VALOR!!

            // Caso você copie a string, e altere o valor da original,
            //  a copia não será alterada!! Os valores serão independentes.
            // Pois, string é diferente das outras variaveis.

            // Verificar se as strings se referem ao mesmo objeto/intancia na memória
            Console.WriteLine($"(object)a == (object)b: {(object)a == (object)b}");
            Console.WriteLine();        // false!

            // as duas variaveis contem o mesmo valor, porem estão apontando para
            // objetos diferentes na memória

            // Neste caso, as variaveis foram convertidas para 'OBJECT'
            // Logo, com isso, queremos saber a comparação entre os objetos
            // e não dos valores

            string bomDia = "bom dia";

            Console.WriteLine($"bomDia[4]: {bomDia[4]}"); // para acessar o caracter 'D'
            Console.WriteLine();

            var caractere = bomDia[4];

            Console.WriteLine($"caractere.GetType(): {caractere.GetType()}");
            // System.Char




        }
    }
}
