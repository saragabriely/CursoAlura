using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Condicional_Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testando condicionais");

            int idade = 20;
            int quantidadePessoas = 3;

            if(idade >= 18)
            {
                Console.WriteLine("Você tem mais de 18 anos.");
                Console.WriteLine("Seja bem-bindo!");
            }
            else
            {
                if(quantidadePessoas >= 2)
                {
                    Console.WriteLine("Você não tem 18 anos. Porém está acompanhado. Pode entrar!");
                }
                else
                {
                    Console.WriteLine("Infelizmente você possui menos de 18 anos. Não pode entrar.");
                }
            }

            Console.ReadLine();
        }
    }
}
