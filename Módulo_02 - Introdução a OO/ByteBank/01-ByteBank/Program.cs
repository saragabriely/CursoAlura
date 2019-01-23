using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string titular        = "Gabriela";
            int    numemroAgencia = 863;
            int    numero         =  863146;
            double saldo          = 100.0;

            string titular2        = "Gabriela";
            int    numemroAgencia2 = 864;
            int    numero2         =  863147;
            double saldo2          = 100.0;
            */

            // Criando o objeto na memória do computador
            //new ContaCorrente();

            ContaCorrente contaDaGabriela = new ContaCorrente();

            contaDaGabriela.titular = "Gabriela";
            contaDaGabriela.agencia = 863;
            contaDaGabriela.numero  = 863146;
            contaDaGabriela.saldo   = 100.0;

            Console.WriteLine("Titular: " + contaDaGabriela.titular);
            Console.WriteLine("Agencia: " + contaDaGabriela.agencia);
            Console.WriteLine("Conta: "   + contaDaGabriela.numero);
            Console.WriteLine("Saldo: "   + contaDaGabriela.saldo);

            Console.ReadLine();
        }
    }
}
