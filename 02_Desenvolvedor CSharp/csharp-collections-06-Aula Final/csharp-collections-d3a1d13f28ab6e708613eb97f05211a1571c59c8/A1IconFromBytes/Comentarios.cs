using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IconFromBytes
{
    class Comentarios
    {
        /*
         Estamos começando mais um Mão na Massa, e dessa vez vamos mostrar como um array é importante para trabalhar com dados de baixo nível, como arquivos e imagens.

Localizando o projeto na pasta
Na pasta Aula6 da solução, temos um projeto chamado A1IconFromByteArray.csproj, que é do tipo Windows Forms.

Não vamos entrar em detalhes aqui sobre como funciona uma aplicação Windows Forms, pois não é o intuito do nosso curso. Mas um formulário (Form) desse tipo de projeto possui inicialmente um construtor com somente uma linha:

public Form1()
{
    InitializeComponent();
}
Objetivo
O nosso objetivo aqui é carregar uma imagem a partir de um arquivo, e usar essa imagem como ícone do form. Para isso, o array (mais especificamente, um array de bytes) será necessário para fazer a carga dos dados desse arquivo de imagem.

Declarando o "mapa de bits" (Bitmap)
A imagem-alvo, que será gerada a partir do arquivo, é declarada como um Bitmap de 32 pixels X 32 pixels:

public Form1()
{
    InitializeComponent();

    Bitmap bm = new Bitmap(32, 32);
}
Um Bitmap tem uma estrutura de matriz, e vários métodos dessa classe trabalham com arrays de bytes. Vamos ver um exemplo disso logo abaixo.

Declarando um Stream de Memória
Trabalhar com arquivos de vídeo pode exigir bastante memória. Se você já tentou copiar um vídeo de um " para um computador sabe do que estou falando. E trabalhar com imagens não é muito diferente.

Para auxiliar na transmissão de dados, o .NET Framework conta com uma série de classes especializadas em streaming. Uma delas é o MemoryStream, que, como diz o nome, permite manipular dados em memória.

Vamos declarar um MemoryStream para receber os dados que forem lidos do arquivo de imagem.

public Form1()
{
    InitializeComponent();

    Bitmap bm = new Bitmap(32, 32);
    MemoryStream memStream;
}
Trabalhando com Stream de Arquivo
Felizmente, nosso arquivo de imagem já está incluído no projeto, e se chama favicon.ico. Para a leitura desse arquivo, vamos utilizar outro stream, mas desta vez, uma classe especializada para acesso a arquivos: o FileStream:

public Form1()
{
    InitializeComponent();

    Bitmap bm = new Bitmap(32, 32);
    MemoryStream memStream;

    using (Stream stream = new FileStream("favicon.ico", FileMode.Open, FileAccess.Read))
    {
        //AQUI VAI SER FEITA A LEITURA DO ARQUIVO E GRAVAÇÃO EM MEMÓRIA!
    }
}
Uma História com Duas Piscinas...
Agora imagine que você tenha duas piscinas: uma cheia de água e outra vazia. E você precisa transferir a água de uma piscina para a outra.

Para isso, você não irá transferir toda a água de uma vez, porque a piscina é muito grane. Em vez disso, você irá utilizar um balde.

Nessa historinha, a piscina cheia é nosso FileStream, e a piscina vazia é o MemoryStream. Agora ficou faltando o balde...

Esse balde servirá para transportar os dados temporários de um Stream para o outro. E esse "balde" é chamado de buffer.

Esse buffer tem tamanho fixo e armazena uma coleção de bytes. Adivinha qual tipo de coleção temos que usar? Isso mesmo, um array de bytes!

using (Stream stream = new FileStream("favicon.ico", FileMode.Open, FileAccess.Read))
{
    memStream = new MemoryStream();
    byte[] buffer = new byte[1024];
}
Note que o array de bytes acima tem tamanho fixo de 1024. Um arquivo de imagem geralmente tem muito mais bytes do que isso, mas o importante é que o "balde" (buffer) pode ser usado quantas vezes forem necessárias para transferir os dados.

Transportando os Dados
Agora temos que fazer o transporte dos dados. Quantas vezes faremos isso? Muitas vezes, e quantas vezes forem necessárias.

Vamos utilizar uma variável byteCount para saber quantos bytes foram transferidos a cada vez. Sempre que byteCount for maior que zero, significa que transportamos alguma coisa. Quando byteCount for igual a zero, então todo nosso arquivo foi transferido para o MemoryStream.

E para a transferência em si, vamos utilizar o método FileStream.Read e MemoryStream.Write, que farão a leitura e a gravação dos dados, respectivamente:

memStream = new MemoryStream();
byte[] buffer = new byte[1024];
int byteCount;

do
{
    byteCount = stream.Read(buffer, 0, buffer.Length);
    memStream.Write(buffer, 0, byteCount);
} while (byteCount > 0);
E por fim, nosso bitmap é montado a partir do stream em memória:

bm = new Bitmap(Image.FromStream(memStream));
Gerando o Ícone
E, para alterar o ícone da janela, usamos um método especializado da classe Icon:

    Icon ic = Icon.FromHandle(bm.GetHicon());
    this.Icon = ic;
O código completo fica assim:

public Form1()
{
    InitializeComponent();

    Bitmap bm = new Bitmap(32, 32);
    MemoryStream memStream;

    using (Stream stream = new FileStream("favicon.ico", FileMode.Open, FileAccess.Read))
    {
        memStream = new MemoryStream();
        byte[] buffer = new byte[1024];
        int byteCount;

        do
        {
            byteCount = stream.Read(buffer, 0, buffer.Length);
            memStream.Write(buffer, 0, byteCount);
        } while (byteCount > 0);
    }

    bm = new Bitmap(Image.FromStream(memStream));

    Icon ic = Icon.FromHandle(bm.GetHicon());
    this.Icon = ic;

}


É isso! Neste Mão na Massa vimos como um array de bytes é utilizado como meio de transporte para um fluxo de dados entre um arquivo e um armazenamento em memória.

Até à próxima!
         */
    }
}
