using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro.antes
{
    class Decimal : IAulaItem
    {
        public void Executar()
        {
            double valorProduto1 = 10;
            double valorProduto2 = 20;
            double subTotal      = 30;

            Console.WriteLine("Descobrindo se 10 + 20 = 30");
            Console.WriteLine((valorProduto1 + valorProduto2) == subTotal);
            Console.WriteLine();
            


        }
    }
}
