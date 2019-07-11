using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class Enumeracoes : IAulaItem
    {
        public void Executar()
        {
            // const = constantes do C#
            const int Seg = 0;
            const int Ter = 1;
            const int Qua = 2;
            // para evitar que constantes do mesmo tipo fiquem soltas pelo código,
            // seria melhor agrupá-las em uma mesma entidade. neste caso é 'enum'

            DiasDaSemana primeiroDia = DiasDaSemana.Seg;

            DiasDeTrabalho diasDeTrabalho = 
                DiasDeTrabalho.Ter | DiasDeTrabalho.Qui | DiasDeTrabalho.Sex;
            // Caso o funcionário trabalhe também na quinta e na sexta ..
            // deveremos ligar / acender esses bits para cada dia de trabalho
            // Podemos fazer isso colocando um operador binário que irá fazer a soma
            // dos bits de cada numero -> operador pipe "|"

            Console.WriteLine(diasDeTrabalho);
        }
    }

    // Trabalhar com enumerações como se elas fossem representações de bits
    // Quando você acende um bit, você terá uma potencia de 2 para aquele número
    
    // o valor default é '0'
    enum DiasDaSemana { Seg = 3, Ter = 10, Qua = 15, Qui, Sex, Sab, Dom }


    // Sem a flag, é mostrado apenas o bit/numero - 13 (soma)
    // com a flag, é mostrado o dia da semana     - ter, qui, sex
    [Flags] // será possíve exibir os resultados de maneira mais 'visivel'
    enum DiasDeTrabalho { Seg = 0, Ter = 1, Qua = 2, Qui = 4,
                          Sex = 8, Sab = 16, Dom = 32 }

}
