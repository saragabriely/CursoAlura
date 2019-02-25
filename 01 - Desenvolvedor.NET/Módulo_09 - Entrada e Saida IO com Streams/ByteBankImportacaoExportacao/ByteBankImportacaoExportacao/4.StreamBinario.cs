using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // IO = Input e Output

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {   // BinaryWriter - Representação binária do Stream

                escritor.Write(145);    // Numero da agencia
                escritor.Write(454545); // Numero da conta
                escritor.Write(4000.50); // Saldo
                escritor.Write("Gustavo Braga");
            }

            // Ao escrever de forma binária em um arquivo, nem todos os editores 
            // poderão ler os caracteres binários. E para utilizar/ler esses caracteres
            // através da aplicação, é necessário criar um método para essa leitura
        }
        
        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var conta   = leitor.ReadInt32();
                var saldo   = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{agencia}/{conta} {titular} {saldo}");

            }
        }
    }
}