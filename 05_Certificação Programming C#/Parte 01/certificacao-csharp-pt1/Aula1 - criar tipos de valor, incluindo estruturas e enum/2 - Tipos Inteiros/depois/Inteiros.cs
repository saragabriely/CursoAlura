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

            uint estoque = 1500; // System.UInt32

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


        }
    }
}
