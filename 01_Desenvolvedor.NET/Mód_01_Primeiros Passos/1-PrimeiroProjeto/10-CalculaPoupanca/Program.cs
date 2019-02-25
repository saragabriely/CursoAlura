using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _P10_CalculaPoupanca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando Projeto 10 - Calcula Poupança");

            // Variáveis
            int    contadorMes    = 1;
            double valorInvestido = 1000.0;

            Console.WriteLine("Valor investido: R$ " + valorInvestido);

            /*
            // 0.36% = 0.0036
            valorInvestido = valorInvestido + valorInvestido * 0.0036;

            // 1 mês
            Console.WriteLine("Após um mês, você terá: R$" + valorInvestido);

            valorInvestido = valorInvestido + valorInvestido * 0.0036;

            // 2 mês
            Console.WriteLine("Após dois meses, você terá: R$" + valorInvestido);
            */

            while(contadorMes <= 12)
            {
                valorInvestido = valorInvestido + valorInvestido * 0.0036;

                Console.WriteLine("Após " + contadorMes +
                                   " mês/meses, você terá: R$ " + valorInvestido);

                contadorMes++;  // contadorMes += 1;
            }


            // Final
            Console.ReadLine();
        }
    }
}
