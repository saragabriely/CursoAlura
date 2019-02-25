using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDoBruno = new ContaCorrente();

            contaDoBruno.titular = "Bruno";

            Console.WriteLine("Saldo Anterior:  " + contaDoBruno.saldo);

            // Acessando a função - SACAR
            // contaDoBruno.Sacar(50.0);

            bool resultadoSaque = contaDoBruno.Sacar(500); 

            Console.WriteLine("Saldo Final:     " + contaDoBruno.saldo);
            Console.WriteLine("Resultado Saque: " + resultadoSaque);

            // Acessando a função - DEPOSITAR
            contaDoBruno.Depositar(500);

            Console.WriteLine();
            Console.WriteLine("Saldo Atual: " + contaDoBruno.saldo);


            ContaCorrente contaDaGabriela = new ContaCorrente();

            contaDaGabriela.titular = "Gabriela";

            // Função - TRANSFERIR

            Console.WriteLine();
            Console.WriteLine("Saldo Anterior - Bruno: " + contaDoBruno.saldo);

            // Função - TRANSFERIR
            bool resultadoTransferencia = contaDoBruno.Transferir(200, contaDaGabriela);

            Console.WriteLine("Saldo Atual - Bruno:    " + contaDoBruno.saldo);
            Console.WriteLine("Saldo Atual - Gabriela: " + contaDaGabriela.saldo);
            Console.WriteLine("Resultado da Transferência: " + resultadoTransferencia);


            contaDaGabriela.Transferir(100, contaDoBruno);

            Console.WriteLine();
            Console.WriteLine("Saldo Atual - Bruno:    " + contaDoBruno.saldo);
            Console.WriteLine("Saldo Atual - Gabriela: " + contaDaGabriela.saldo);


            Console.ReadLine();
        }
    }
}
