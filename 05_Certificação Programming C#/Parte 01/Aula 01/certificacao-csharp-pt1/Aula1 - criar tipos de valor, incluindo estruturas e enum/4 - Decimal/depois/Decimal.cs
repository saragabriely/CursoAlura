using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Decimal : IAulaItem
    {
        public void Executar()
        {
            double valorProduto1 = 10;
            double valorProduto2 = 20;
            double subTotal = 30;

            Console.WriteLine("Descobrindo se 10 + 20 = 30");
            Console.WriteLine((valorProduto1 + valorProduto2) == subTotal); // TRUE
            Console.WriteLine();

            valorProduto1 = 10.10;
            valorProduto2 = 20.20;
            subTotal      = 30.30;

            Console.WriteLine("Descobrindo se 10.10 + 20.20 = 30.30");
            Console.WriteLine((valorProduto1 + valorProduto2) == subTotal); // FALSE
            Console.WriteLine(valorProduto1 + valorProduto2);
            Console.WriteLine();

            // A soma real daria: 30,2999999997;
            // Mas ao imprimir a soma dos dois, na tela aparece '30,3' - pois
            // é o valor é arredondado, internamente a soma não é '30,3'.

            // Isso é um problema ao se trabalhar com pontos flutuantes (double/float)

            Console.WriteLine("Descobrindo se 10.10 + 20.20 = 30.299999999999997");
            Console.WriteLine((valorProduto1 + valorProduto2) == 30.299999999999997);
            // TRUE
            Console.WriteLine();

            // Esses números perdem a precisão quando trabalhamos com decimais.
            // Nesses casos, devemos usar o tipo DECIMAL, e internamente, ele
            // é representado como um número decimal, e não binário como os outros.

            // 10.1             - double - dupla precisão
            // 10.1f            - float 
            // 10.1m ou 10.1M   - decimal

            decimal materiaPrima = 10.1m;
            decimal maoDeObra    = 20.2m;
            decimal custoTotal   = 30.3m;

            Console.WriteLine("Descobrindo se 10.1m + 20.2m = 30.3m");
            Console.WriteLine((materiaPrima + maoDeObra) == custoTotal); // TRUE
            Console.WriteLine();

            /*
             Sempre que for trabalhar com valores monetários, valores que envolvam
             precisão de um decimal (salário, produto, valor de serviço ...),
             deve SEMPRE utilizar DECIMAL!!

            Internamente o Decimal também é um ponto flutuante, porém a precisão
            é MUITO maior.
             
             Tipo C#    : decimal
             Tipo .NET  : System.Decimal
             Precisão   : (-7.9 X 10^28 a 7.9 x 10^28) 
                          28 -29 digitos             
             */
             
            /*
            ** O tipo double cobre uma faixa de valores maior do que float e decimal
            * O tipo double tem a maior faixa de cobertura entre os tipos de
            * valor do .NET.
            
             O tipo decimal também é um tipo de ponto flutuante
             
             * O tipo decimal é um tipo de ponto flutuante, mas sua 
             * representação é decimal, enquanto nos tipos float e double a 
             * representação é binária.
             
            ** O tipo float é um tipo de ponto flutuante de simples precisão
            * O tipo float é um tipo de ponto flutuante, mas sua precisão é 
            * menor que a do double.

            ** O tipo decimal tem precisão maior do que float e double
            *  Um tipo decimal tem a maior entre os tipos de valor do .NET.
             */
        }
    }
}
