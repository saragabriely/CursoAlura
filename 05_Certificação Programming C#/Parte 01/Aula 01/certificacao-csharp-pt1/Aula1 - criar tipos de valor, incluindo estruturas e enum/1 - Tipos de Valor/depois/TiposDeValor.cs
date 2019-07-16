using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            int idade;

            idade = 30;

            //Console.WriteLine(idade);

            int copiaIdade = idade;

            Console.WriteLine($"idade:      {idade}");      // valor impresso: 30
            Console.WriteLine($"CopiaIdade: {copiaIdade}"); // valor impresso: 30

            idade = 23;

            Console.WriteLine($"idade:      {idade}");      // valor impresso: 23 
            Console.WriteLine($"CopiaIdade: {copiaIdade}"); // valor impresso: 30
            // o novo valor não foi atribuido para a copia
            // pois é uma nova variavel - logo, são independentes

            /*
             Depois que o valor de idade é copiado para a variável copiaIdade, 
             as duas variáveis continuam independentes, logo a alteração em 
             idade não afeta o valor da variável copiaIdade
             */

            // idade = null; - não é possível transformar um inteiro em nulo. 

            // inteiro anulável
            int? idade2 = null; // ou
            System.Nullable<int> idade3 = null;

            /*
             O int é uma struct do .NET. Poderia ser INT ou System.Int32.
             */
        }
    }
}
