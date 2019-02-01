using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank;
using ByteBank.Funcionarios;
using Modelos;

namespace SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(3765, 323663);

            FuncionarioAutenticavel carlos = null;

            // AutenticaHelper autentica; // essa classe é de uso interno da biblioteca
            // Logo, não pode ser acessada diretamente fora da biblioteca

            Console.WriteLine("Conta: " + conta.Numero);
            


            Console.ReadLine();
        }
    }
}
