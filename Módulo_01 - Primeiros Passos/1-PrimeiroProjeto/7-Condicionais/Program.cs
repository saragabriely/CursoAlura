using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 7 - Condicionais");

            int idadeJoao         = 16;
            int quantidadePessoas = 2;

            if(idadeJoao >= 18)             // Maior de 18 anos
            {
                Console.WriteLine("João possui mais de 18 anos. Pode entrar!");
            }
            else                            // Menor de 18 anos
            {
                if (quantidadePessoas >= 2)
                {
                    Console.WriteLine("João não possui mais de 18 anos, porém está acompanhado. Pode entrar!");
                }
                else
                {
                    Console.WriteLine("João tem menos de 18 anos. NÃO pode entrar!");
                }
            }

            
            Console.WriteLine("Execução terminada. Selecione ENTER para finalizar ...");
            Console.ReadLine();

        }
    }
}
