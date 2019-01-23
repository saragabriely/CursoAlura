using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P11_CalculaPoupanca2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando Projeto 11 - Calcula Poupança 2");

            // Variáveis
            double valorInvestido = 1000.0;
            
            // Laço
            for(int contadorMes = 1; contadorMes <= 12; contadorMes++)
            {
                //valorInvestido = valorInvestido + valorInvestido * 0.0036;
                // valorInvestido = valorInvestido * 1.0036;

                valorInvestido *= 1.0036;

                Console.WriteLine("Após " + contadorMes
                                  + " meses, você terá: R$ " + valorInvestido);
            }

            Console.ReadLine();
        }
    }
}
