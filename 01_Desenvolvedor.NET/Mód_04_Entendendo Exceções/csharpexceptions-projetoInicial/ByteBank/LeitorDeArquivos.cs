using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    // IDIsposable - Interface necessária para a classe ser utilizada no using do 
    // arquivo 'Program.cs';

    public class LeitorDeArquivos : IDisposable
    {
        public string Arquivo { get; set; }

        public LeitorDeArquivos(string arquivo)
        {
            Arquivo = arquivo;

         //   throw new FileNotFoundException(); // Arquivo não encontrado

            Console.WriteLine("Abrindo arquivo: " + arquivo);
            Console.WriteLine(); // Pula linha
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha ... ");

            // Verifica se tem alguma linha corrompida
            throw new IOException();


            return "Linha do arquivo";
        }

        /*
        public void Fechar()
        {
            Console.WriteLine(); // Pula linha

            Console.WriteLine("Fechando arquivo ... ");
        }   */

        // O Dispose irá liberar os recursos no using
        public void Dispose()
        {
            // Substitue o Fechar()

            Console.WriteLine(); // Pula linha

            Console.WriteLine("Fechando arquivo ... ");
        }
    }
}
