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
        static void UsarStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                // Quando tem dois usings alinhados, é possível tirar os {} do 
                // primeiro USING

                // O StreamReader usa recursos do sistema operacional.
                // O mesmo deriva da classe TextReader, que por sua vez,
                // deriva da interface IDisposable, e dessa forma, é necessário
                // utilizar outro using (abaixo)

                // Para mudar o Enconding utilizado, é necessário utilizar uma outra 
                // sobrecarga do stream - StreamReader(fluxoDeArquivo, Enconding.UTF-32)
                using (var leitor = new StreamReader(fluxoDeArquivo))
                {
                    // EndOfStream - Verifica se chegou no fim do stream
                    // Logo, o while irá funcionar enquanto não chegar no final do stream
                    while (!leitor.EndOfStream)
                    {
                        var linha = leitor.ReadLine();

                        var contaCorrente = ConverterStringParaContaCorrente(linha);

                        var mensagem =
                            $"Conta número: {contaCorrente.Numero}, " +
                            $" Agencia: {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}, " +
                            $"Titular. {contaCorrente.Titular.Nome}";

                        Console.WriteLine(mensagem);
                    }

                    // Read()      - Retorna um INT - lê o primeiro byte
                    // ReadLine()  - Mostra uma linha (no caso a primeira) (retorna uma string)
                    // ReadToEnd() - Mostra todas as linhas do arquivo (retorna uma string grande)
                }
            }
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            // Pegar a linha recebida e quebrá-la de acordo com os espaços

            // Split - Quebra uma string através do caracter escolhidog
            var campos = linha.Split(','); // virgula  // (' '); // espaço
            // Campos será um array de string

            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace('.', ',');
            var nomeTitular = campos[3];

            var agenciaComoInt = int.Parse(agencia);
            var numeroComoInt = int.Parse(numero);
            var saldoComoDouble = double.Parse(saldo);

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agenciaComoInt, numeroComoInt);

            resultado.Depositar(saldoComoDouble);

            resultado.Titular = titular;

            // Retorno - Array de String
            return resultado;
        }
    }
}