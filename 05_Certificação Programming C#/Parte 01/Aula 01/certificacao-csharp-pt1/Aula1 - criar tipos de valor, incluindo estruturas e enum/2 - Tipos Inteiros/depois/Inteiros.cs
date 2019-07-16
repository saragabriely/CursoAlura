using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class TiposInteiros : IAulaItem
    {
        public void Executar()
        {
            int idade = 15;

            //idade = 15.5;

            char resposta = 'S'; // System.Char
            /*
             O CHAR é um tipo integral - internamente ele armazena números.
             */

            byte nivelDeAzul = 0xFF; // = 255 em decimal
            // representação hexadecimal do número 255

            // atribuindo valor negativo:
            //nivelDeAzul = -3;
            // o tipo byte não permite número negativos

            short passageirosVoo = 238; // System.Int16
            // inteiro curto - tem apenas 2 bytes
            // é equivalente a System.Int16 (16 bites)

            passageirosVoo = -7; // permite negativos

            int populacao = 1500; // System.Int32 - 32 bits

            populacao = -2300; // permite negativos

            long populacaoDoBrasil = 207_660_929; // +/- 207 milhões
            // inteiro longo  - System.Int64 


            sbyte nivelDeBrilho = -127; // System.Sbyte
            // aceita negativo

            ushort passageirosNavio = 230; // System.UInt16
                                           // não tem sinal! (unsigned) - não é possível atribuir valor negativo

            // unsigned int: um inteiro sem sinal e, portanto,
            // não aceita valores negativos
            uint estoque = 1500; // System.UInt32
            // não aceita negativo

            ulong populacaoDoMundo = 7_000_000_000; // 7 bilhões - System.UInt64


            Console.WriteLine($"Resposta:           {resposta}");
            Console.WriteLine($"nivelDeAzul:        {nivelDeAzul}");
            Console.WriteLine($"passageirosVoo:     {passageirosVoo}");
            Console.WriteLine($"populacao:          {populacao}");
            Console.WriteLine($"populacaoDoBrasil:  {populacaoDoBrasil}");
            Console.WriteLine($"nivelDeBrilho:      {nivelDeBrilho}");
            Console.WriteLine($"passageirosNavio:   {passageirosNavio}");
            Console.WriteLine($"estoque:            {estoque}");
            Console.WriteLine($"populacaoDoMundo:   {populacaoDoMundo}");

            //nivelDeAzul = 0xFFF;                  // = 65535 em decimal
            //passageirosVoo = 230000;              // System.Int16
            //populacao = 15000000000;              // System.Int32
            //passageirosNavio = -15;               // System.UInt16
            //estoque = -2300;                      // System.UInt32
            //populacaoDoBrasil = 207_660_924.345; // não pode casas decimais

            #region Identificando tipos de valor
            /*
             Quais dos tipos C# abaixo são tipos de valor?

            ** Alternativa incorreta: 
            string: Ops... Um tipo string armazena uma referência, e não um tipo de valor.

            
            object = Ops... Um tipo object armazena uma referência, e não um tipo de valor.

            Alternativa correta
            decimal = Isso mesmo. Um tipo decimal armazena um tipo de valor, e não uma referência.

            Alternativa correta
            int = Isso mesmo. Um tipo int armazena um tipo de valor, e não uma referência.

            Alternativa correta
            bool = Isso mesmo. Um tipo bool armazena um tipo de valor, e não uma referência.

            Alternativa correta
            float = Isso mesmo. Um tipo float armazena um tipo de valor, e não uma referência.

            Alternativa incorreta
            interface = Ops... Um tipo interface armazena uma referência, e não um tipo de valor.
            
            Alternativa incorreta
            delegate = Ops... Um tipo delegate armazena uma referência, e não um tipo de valor.
             */
            #endregion

        }
    }
}
