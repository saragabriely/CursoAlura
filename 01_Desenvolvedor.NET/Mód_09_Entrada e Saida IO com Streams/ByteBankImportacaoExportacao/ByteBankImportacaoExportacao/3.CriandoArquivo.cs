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
        static void CriarArquivo()
        {
            // Ao utilizar o Stream, não faz diferença o tipo de arquivo que será utilizado
            // Podendo ser txt, csv, etc.

            var caminhoNovoArquivo = "contasExportadas.csv";

            using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456, 78945, 7845.45, Gustavo Santos";

                // Transformar strings em uma cadeia de bytes
                var encoding = Encoding.UTF8;

                // Obter os bytes a partir da string
                var bytes = encoding.GetBytes(contaComoString);

                // Método para escrever no arquivo
                // Write: oferece os mesmos parametros/argumentos que o Read
                // (Cadeia de bytes, a escrita começa pelo indice 0, escrever todos os
                // bytes do array)
                 fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }

        }

        static void CriarArquivoComWriter()
        {
            // Código para criar arquivo sem a necessidade de mexer com os bytes

            var caminhoDONovoArquivo = "contasExportadas.csv";

            // FileMode.Create - Caso encontre, no local de origem, um arquivo com
            // o mesmo nome, este arquivo será reescrito.

            // FileMode.CreateNew - Casp tenha um arquivo com o mesmo nome no destino,
            // será lançada uma exceção.

            using(var fluxoDeArquivo = new FileStream(caminhoDONovoArquivo, FileMode.Create))
            {
                //var escritor = new StreamWriter(fluxoDeArquivo);

                // O StreamWriter deriva de TextWriter, que implementa a interface
                // IDisposable, logo a criação (var escritor = new StreamWriter(fluxoDeArquivo);)
                // deve ficar dentro de um bloco USING

                // É possível criar um arquivo e explicitar o encoding utilizado
                // using(var escritor = new StreamWriter(fluxoDeArquivo, Encoding.UTF8))

                using (var escritor = new StreamWriter(fluxoDeArquivo))
                {
                    escritor.Write("456, 45454, 1254.00, Pedro");
                }

            }
        }

        static void TestaEscrita()
        {
            var caminhoDoArquivo = "teste.txt";

            using(var fluxoDeArquivo = new FileStream(caminhoDoArquivo, FileMode.Create))
            {
                // PAra não lidar com bytes
                using (var escritor = new StreamWriter(fluxoDeArquivo))
                {
                    for (int i = 0; i < 10000000; i++)
                    {
                        escritor.WriteLine($"Linha {i}");
                        // Ao chamar o WriteLine, a informação é enviada ao buffer,
                        // e enquanto o buffer não é preenchido, as informações
                        // não são enviadas ao Stream e não grava no arquivo

                        // O WriteLine tem sobrecarga para bool, char, long e outros

                        escritor.Flush(); // despeja o buffer para o stream!
                        // Dessa forma, toda a informaçao é imediatamente 
                        // gravada no arquivo.

                        Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle ENTER para adicionar mais uma ...");

                        Console.ReadLine();
                    }
                }
            }
        }

    }
}
