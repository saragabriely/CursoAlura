using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    partial class Program
    {
        static Queue<string> pedagio = new Queue<string>();

        static void Main(string[] args)
        {
            // FILA - PRIMEIRO QUE ENTRA, É O PRIMEIRO QUE SAI

            // Entrou: Van
            Enfileirar("van");

            // Entrou: Kombi
            Enfileirar("kombi");

            // Entrou: Guincho
            Enfileirar("guincho");

            // Entrou: pickup
            Enfileirar("pickup");

            // Liberação dos carros ------------------------
            Desinfileirar(); 

            Desinfileirar();

            Desinfileirar();

            Desinfileirar();

            Desinfileirar();

            


            //--------------------------------------------
            Console.ReadLine();
        }

        private static void Desinfileirar()
        {
            if (pedagio.Any()) // Verifica se a fila está vazia
            {
                if (pedagio.Peek() == "guincho")
                {
                    Console.WriteLine("Guincho está fazendo o pagamento");
                }

                string veiculo = pedagio.Dequeue();

                Console.WriteLine($"\nSaiu da fila: {veiculo}");

                ImprimirFila();
            }

        }

        private static void Enfileirar(string veiculo)
        {
            Console.WriteLine($"Entrou na fila: {veiculo}");

            pedagio.Enqueue(veiculo); // Variavel de enfileiramento = ENQUEUE

            ImprimirFila();
        }

        private static void ImprimirFila()
        {
            Console.WriteLine("\nFILA: ");

            foreach (var v in pedagio)
            {
                Console.WriteLine(v);
            }
        }
    }

    
}
