using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CriandoVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 2: Criando Variáveis");

            int idade;

            idade = 32;
            Console.WriteLine("Idade: " + idade.ToString());

            idade = 10;
            Console.WriteLine("Idade: " + idade.ToString());

            idade = 10 + 5 * 2;
            Console.WriteLine("Idade: " + idade.ToString());

            idade = (10 + 5) * 2; // o C# dá preferencia para o que estiver dentro do parenteses
            Console.WriteLine("Idade: " + idade.ToString());
            
            Console.WriteLine("Execução finalizada. Tecle ENTER para sair ... ");
            Console.ReadLine();

        }
    }
}
