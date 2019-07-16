using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Dinamicos : IAulaItem
    {
        public void Executar()
        {
            // object comporta qualquer outro tipo do C#
            object objeto = 1;

            //objeto = objeto + 3; // não compila! pois como está sendo utilizado o 
            // object, nele não é encontrado o operador '+' para realizar a soma
            // do objeto mais 3.


            dynamic dinamico = 1;
            dinamico = dinamico + 3; // compila! recebe o resultado de uma soma!

            Console.WriteLine($"Dinamico: {dinamico}");

            /* O tipo 'dynamic' tem um funcionamento diferente em relação ao object
             * durente o tempo de compilação, porém após a compilação, irá se 
             * comportar exatamente igual ao objeto.
             * 
             * Não é preciso fazer a verificação durante o tempo de compilação.
             */

            //dinamico.teste(); // aparecerá o erro 'int não contem uma definição
            // para teste'.

            // temos que tomar cuidado com o dynamic para não tomar erros em 
            // tempo de execução.

            // durante o desenvolvimento, não é verificado quais métodos aceita
            // e em tempo de execução ainda não foi verificado qual é o tipo 
            // da variavel dynamic

            /*
             * A existência dos membros de um objeto dynamic são verificados 
             * somente em tempo de execução.
             * 
             * Operações que contêm expressões dynamic não são resolvidas ou 
             * verificadas pelo compilador.
             * O tipo dynamic existe somente em tempo de compilação e não em tempo
             * de execução.
             */

        }
    }
}
