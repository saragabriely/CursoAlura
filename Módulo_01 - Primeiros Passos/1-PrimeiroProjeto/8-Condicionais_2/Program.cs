using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Condicionais_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando condicionais");

            int idade             = 20;
            int quantidadePessoas = 3;

            bool acompanhado = quantidadePessoas >= 2;

            // if (idade >= 18 && quantidadePessoas >= 2)
            // if (idade >= 18 && acompanhado == true)
            if (idade >= 18 && acompanhado)
            {
                Console.WriteLine("Pode entrar.");
            }
            else
            {
                Console.WriteLine("Não pode entrar.");
            }

            Console.ReadLine();
        }
    }
}
