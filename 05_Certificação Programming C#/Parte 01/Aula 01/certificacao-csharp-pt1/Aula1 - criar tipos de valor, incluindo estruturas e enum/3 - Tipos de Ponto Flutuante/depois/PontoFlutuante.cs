using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro.antes
{
    class PontoFlutuante : IAulaItem
    {
        public void Executar()
        {
            float idade = 15;

            idade = 15.5f;
            // é necessário colocar o 'f' para mostrar que 15.5 é flutuante/float

            //int massa = 6_000000_000000_000000_000000;
            //long massa = 6_000000_000000_000000_000000; // OU
            //long massa = 6e24;
            
            Console.WriteLine($"long.MinValue: {long.MinValue}");
            Console.WriteLine($"long.MaxValue: {long.MaxValue}");


        }
    }
}
