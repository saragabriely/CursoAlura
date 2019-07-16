using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Booleanos : IAulaItem
    {
        public void Executar()
        {
            // Booleano armazena TRUE ou FALSE! Nada mais.

            bool possuiSaldo = true;

            Console.WriteLine($"possuiSaldo: {possuiSaldo}");
            
            int dias = DateTime.Now.Day;
            Console.WriteLine($"dias: {dias}");

            // Atribui a diasPar o valor de uma expressão boleana
            bool diasPar = (dias % 2 == 0);  // Resultado: Par - o numero é par

            if(diasPar) // diasPar == true
            {
                Console.WriteLine("dias é um número par");
            }
            else
            {
                Console.WriteLine("dias é um número ímpar");
            }
            

        }
    }
}
