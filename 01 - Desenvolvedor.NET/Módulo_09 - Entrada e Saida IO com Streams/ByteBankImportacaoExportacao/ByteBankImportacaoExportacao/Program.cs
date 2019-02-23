using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // IO = Input e Output

namespace ByteBankImportacaoExportacao 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        {
            





            //---------------------------------------------------
            Console.ReadLine();
        }

        #region Lidando com FileStream diretamente
        static void LidandoComFileStreamDiretamente()
        {
            #region Comentários - 01
            // \n - QUEBRA DE LINHA 
            //var textoComQuebraDeLinha = "Minha primeira linha \n minha segunda linha";
            //Console.WriteLine(textoComQuebraDeLinha);
            //Console.ReadLine();

            // Leitura de arquivos
            // Os players, por exemplo, não carregam o arquivo / video inteiro 
            // na memória do computador, para mostrar ao usuário! Uma parte é 
            // carregada, processada e liberada, e assim por diante.

            // Colocando apenas o nome do arquivo ("contas.txt"), o arquivo será 
            // buscado no diretório que tem o arquivo executável (exe) da 
            // aplicação. Ou seja, ao compilar a aplicação ao menos uma vez,
            // selecionando, dentro da pasta da aplicação, o diretório 
            // bin -> Debug, será gerado o arquivo executável e é nessa pasta que 
            // será buscado o arquivo desejado.
            // Dessa forma, não será necessário se preocupar em ter o mesmo diretório
            // na máquina, como por exemplo: c:/ByteBank/contas.txt.
            #endregion

            //FileStream(endereço do arquivo, e o que será feito (atividade))
            // FileMode.Open - Um arquivo será aberto

            var enderecoDoArquivo = "contas.txt"; // endereço relativo

            // Criar o fluxo de bytes para acessar o arquivo e que percorra ele.

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                // Array a ser utilizado no Read abaixo(e serve para guardar informações 
                // temporárias)
                var buffer = new byte[1024]; // 1024 bytes = 1kb

                var numeroDeBytesLidos = -1; // O Read retorna apenas um número positivo,
                                             // ou zero, para informar que chegou ao fim do
                                             // arquivo

                // Read(byte[] array (onde será gravada as informações), 
                //      int offset  (indice que será usado para começar a preencher o array),
                //      int count   (quantos bytes serão lidos e colocados no array))

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    // O método Read pode escrever mais bytes do que o solicitado (1024)

                    // Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                    // É reescrito na tela dados antigos, pois é escrito os 1024 bytes
                    // e como o arquivo não tem tantos bytes, a leitura é repetida

                    if (numeroDeBytesLidos != 0)
                    {
                        EscreverBuffer(buffer, numeroDeBytesLidos);
                        // foi adicionado o numeroDeBytesLidos para processar apenas 
                        // o que o stream leu, e dessa forma, não é repetida a leitura
                    }
                }

                #region Comentários - Enconding
                // 'ENCONDING' !
                // Codificar os bytes para caracteres (ASCII TABLE) - Não pode ser utilizada
                // neste caso, pois não se sabe quantos bytes são utilizados por caracter

                // O melhor seria ter uma tabela de caracteres 

                // Codigo UNICODE! 
                // Cada caractere do Unicode é um Code Point.
                // O código será transformado para armazenar no HD ...
                // O formato de transformação Unicode - Unicode Transformation Code (UTF)
                // UTF-1/7/8/16/32
                // Se preocupar como os bytes representam o code point na tabela Unicode.

                // Verificação feita para evitar que o close não seja chamado,
                // caso ocorra uma exceção
                /* if (fluxoDoArquivo != null)
                 {
                     fluxoDoArquivo.Close(); // Indica que o arquivo foi fechado
                                             // Permite que o arquivo seja modificado/renomeado
                                             // pois o arquivo será fechado / a aplicação não 
                                             // estará segurando o arquivo.
                 } */

                // O método CLOSE não precisa ser chamado explicitamente quando é
                // usado o USING (que chama o Close).
            }

            // Using pode ser usado apenas com classes que implementam a interface
            // IDisposable
            #endregion

        }
        #endregion

        // Método para escrever o buffer na tela
        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            // Deriva do tipo Enconding
            var utf8 = new UTF8Encoding(); // transformar os bytes para texto esperado
                                           // ou var utf8 = Encoding.UTF8;
                                           // ou Enconding.Default - padrão utilizado no
                                           //   sistema operacional
                                           // Unicode - utiliza o UTF-16

            // Não é possível usar o UTF-32 neste caso, pois o doc foi salvo como UTF-8

            // Espera um array de bytes do texto que será recuperado
            var texto = utf8.GetString(buffer, 0, bytesLidos);
            // .GetString(array de bytes, inicio da leitura, quantidades de  bytes para
            // processamento)

            Console.Write(texto);

            /* // Mostra byte por byte
            foreach(var meuByte in buffer)
            {
                // Será usado o 'WRITE' e não o 'WRITELINE', para evitar que 
                // seja mostrado um byte por linha
                Console.Write(meuByte);
                Console.Write(" "); // separador
            }
            */

        }

    }
} 
 