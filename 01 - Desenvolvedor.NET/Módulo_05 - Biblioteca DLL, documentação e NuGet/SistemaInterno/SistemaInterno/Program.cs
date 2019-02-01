using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInterno
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(458, 455789);
            
            Console.WriteLine("Saldo: R$ " + conta.Saldo);

            conta.Sacar(-10);

            string nome = "Guilherme";




            Console.ReadLine();
        }
    }
}
