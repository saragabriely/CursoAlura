using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13_ForEncadeado_Atividade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando atividade com FOR encadeado");

            for (int linha = 0; linha < 5; linha++)
            {
                for (int coluna = 0; coluna < 5; coluna++)
                {
                    if (coluna > linha)
                    {
                        break;
                    }
                    Console.Write(coluna+1);
                }

                Console.WriteLine();
            }

            // Resultado
            /*
                 1
                 12
                 123
                 1234
                 12345
            */


            Console.ReadLine();
        }
    }
}
