using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P13_ForEncadeado_Atividade_LacoRepeticaoFor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Escreva um for encadeado que imprima a tabuada de cada número,
            // nosso código ficará assim:

            for (int multiplicador = 1; multiplicador <= 10; multiplicador++)
            {
                for (int contador = 0; contador <= 10; contador++)
                {
                    Console.Write(multiplicador + " * " + contador + " = " 
                                + multiplicador * contador);

                    Console.WriteLine();
                }

                Console.WriteLine();
            }


            Console.ReadLine();
        }
    }
}
