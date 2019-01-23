using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Referência
            ContaCorrente contaDaGabriela = new ContaCorrente();

            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.agencia = 863;
            contaDaGabriela.numero  = 863452;

            // Referência - variavel que apon
            ContaCorrente contaDaGabrielaCosta = new ContaCorrente();

            contaDaGabrielaCosta.titular = "Gabriela";
            contaDaGabrielaCosta.agencia = 863;
            contaDaGabrielaCosta.numero  = 863452;

            // Verifica se o objeto é igual ao outro
            // Um objeto NUNCA será igual ao outro
            Console.WriteLine("Igualdade de referência: " + (contaDaGabriela == contaDaGabrielaCosta)); // false

            int idade           = 27;
            int idadeMaisUmaVez = 27;

            Console.WriteLine("Igualdade de tipo de valor: " + (idade == idadeMaisUmaVez)); // true

            // 'contaDaGabrielaCosta' passa a apontar para o mesmo objeto de 'contaDaGabriela'
            contaDaGabrielaCosta = contaDaGabriela;

            contaDaGabriela.saldo = 300;
            Console.WriteLine("Gabriela       - Saldo: " + contaDaGabriela.saldo);
            Console.WriteLine("Gabriela Costa - Saldo: " + contaDaGabrielaCosta.saldo);

            // Resultado: os saldos são os mesmos, pois as referencias apontam para o mesmo objeto instanciado na memória

            // SAQUE -----------------------------------------------

            if (contaDaGabriela.saldo >= 100)
            {
                contaDaGabriela.saldo -= 100;
            }


            // Fim
            Console.ReadLine();
        }
    }
}
