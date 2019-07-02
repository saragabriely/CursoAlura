using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro.antes
{
    class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            int idade;

            idade = 30;

            Console.WriteLine(idade);
        }

        /*
         Dentro do .NET, nós temos 2 formas de armazenar dados: Tipo de Valor e Tipo
         de Referência.
         */
    }
}
