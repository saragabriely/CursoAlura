using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    /*
     Delegate seria algo como 'representante' ou 'delegado' - representa um método
     qualquer.   
     
     ** Delegates são como ponteiros para métodos. Eles são usados geralmente 
     * para implementar eventos e métodos de call-back.
     * Delegates podem ser armazenados como variáveis de referência, que 
     * representam e apontam para um determinado método, e são muito usados em 
     * combinação com eventos.
     */

    class Delegates : IAulaItem
    {
        public void Executar()
        {
            Calculadora.Executar();
        }

        // delegate  assinatura do método (podendo ser usado para o 'duplicar' e o 
        // triplicar) - o que é importante mesmo é o retorno (neste caso é o double)
        delegate double MetodoMultiplicacao(double input);

        class Calculadora
        {
            static double Duplicar(double input)
            {
                return input * 2;
            }

            static double Triplicar(double input)
            {
                return input * 3;
            }

            public static void Executar()
            {
                // Executa diretamente o método
                Console.WriteLine($"Duplicar(7.5): {Duplicar(7.5)}");

                // Executa diretamente o método
                Console.WriteLine($"Triplicar(7.5): {Triplicar(7.5)}");
                Console.WriteLine();

                // o 'MetodoMultiplicacao' recebe o metodo que será utilizado
                MetodoMultiplicacao metodoMultiplicacao = Duplicar;
                Console.WriteLine($"Duplicar:  {metodoMultiplicacao(7.5)}"); // duplicação
                Console.WriteLine();

                // É possível trocar o método quando necessário

                metodoMultiplicacao = Triplicar;
                Console.WriteLine($"Triplicar: {metodoMultiplicacao(7.5)}"); // triplicacao
                Console.WriteLine();

                // é possível colocar/instanciar o delegate com um método anonimo

                // metodoExemplo = delegate (retorno) e corpo do método anonimo
                MetodoMultiplicacao metodoQuadrado = delegate (double input)
                {
                    return input * input;
                };

                double quadrado = metodoQuadrado(5);

                Console.WriteLine($"Quadrado: {quadrado}");
                Console.WriteLine();

                // é possível utilizat um delegate com uma expressão lambda
                // entrada (input); após o '=>' terá a expressão que será retornada
                MetodoMultiplicacao metodoCubo = input => input * input * input;

                double cubo = metodoCubo(4.375);

                Console.WriteLine($"Cubo: {cubo}");
                Console.WriteLine();
                               
            }
        }
    }
}
