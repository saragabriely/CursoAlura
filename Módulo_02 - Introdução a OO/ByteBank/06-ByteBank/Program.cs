using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta   = new ContaCorrente();
            Cliente       cliente = new Cliente();

            cliente.nome      = "Guilherme";
            cliente.cpf       = "434.564.879-20";
            cliente.profissao = "Desenvolvedor";

            
            conta.Saldo   = -10;
            conta.Titular = cliente;


            // ObterSaldo: método que retorna o valor do campo privado da classe
            Console.WriteLine("Saldo: " + conta.Saldo);



            // Fim
            Console.ReadLine();
        }
    }
}
