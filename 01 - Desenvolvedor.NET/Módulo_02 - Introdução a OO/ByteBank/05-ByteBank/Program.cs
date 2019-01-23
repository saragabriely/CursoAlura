using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Gabriela - variavel do tipo referencia que aponta para o objeto alocado na memória
          //  Cliente gabriela = new Cliente();

          //  gabriela.nome      = "Gabriela";
          //  gabriela.profissao = "Desenvolvedora C#";
          //  gabriela.cpf       = "434.562.878-20";

            // Conta
            ContaCorrente conta = new ContaCorrente();

            // conta.titular   = gabriela;

            conta.titular           = new Cliente();
            conta.titular.nome      = "Gabriela Costa"; // altera os dois campos
            conta.titular.cpf       = "434.562.878 - 20";
            conta.titular.profissao = "Desenvolvedora C#";

            conta.saldo     = 500;
            conta.agencia   = 563;
            conta.numero    = 563427;

           

           // Console.WriteLine("Nome:    " + gabriela.nome);
            Console.WriteLine("Titular: " + conta.titular.nome);



            Console.ReadLine();
        }
    }
}
