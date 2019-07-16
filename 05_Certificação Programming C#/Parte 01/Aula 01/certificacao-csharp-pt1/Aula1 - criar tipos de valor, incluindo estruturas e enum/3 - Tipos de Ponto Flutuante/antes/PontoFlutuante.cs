using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
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

            //---------------------------------------------------------

            float massaDaTerra = 5.973e24f; // System.Single
                                            // 5.973 * 10 elevado a 24 

            Console.WriteLine($"massaDaTerra: {massaDaTerra}");

            //---------------------------------------------------------

            float numeroPI = 3.14159f; // System.Single

            Console.WriteLine($"numeroPI: {numeroPI}");

            //---------------------------------------------------------

            //float numeroMuitoMaior = 6e100f;

            double numeroMuitoMaior = 6e100; // variavel de dupla precisão

            Console.WriteLine();
            Console.WriteLine("Operação com INT, FLOAT e SHORT");

            //---------------------------------------------------------

            int x = 3; 
            short y = 5;

            var resultado1 = x * y;

            Console.WriteLine($"x * y = {resultado1}");
            Console.WriteLine($"O resultado1 é do tipo: {resultado1.GetType()}");
            Console.WriteLine();
            // Tipo de resultado: SYSTEM.INT32
            // O tipo INT tem maior capacidade. Logo, ao fazer operações com 
            // tipos diferentes, o resultado terá o tipo que tiver maior capacidade
            // entre eles.

            //---------------------------------------------------------
            
            float z = 4.5f;

            var resultado2 = (x * y) / z;

            Console.WriteLine($"(x * y) / z = {resultado2}");
            Console.WriteLine($"O resultado2 é do tipo: {resultado2.GetType()}");
            Console.WriteLine();

            // O tipo do resultado2 é SYSTEM.SINGLE! 
            // o float tem capacidade maior que o inteiro e o short,
            // logo, o resultado assumiu o tipo do float.

            //---------------------------------------------------------

            //C#     .NET           Faixa de Valores        Precisão
            //================================================================
            //float  System.Singe  +-1.Se-45  to +-3.4e38   7       digitos
            //double System.Double +-S.0e-324 to +-1.7e08   15-16   digitos
        }
    }
}
