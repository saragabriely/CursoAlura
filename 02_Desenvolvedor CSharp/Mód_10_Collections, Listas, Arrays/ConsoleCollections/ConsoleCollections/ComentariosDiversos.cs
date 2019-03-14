using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    class ComentariosDiversos
    {
        // Transcrição das aulas
        // Todo o conteúdo abaixo irá ser ajustado/diminuido, para conter apenas
        // algumas explicações dadas nos vídeos!

        #region Comentários - Qual collection usar?
        /*
         *  QUEUE (FILA) - Coleção genérica
            . O primeiro que entra é o primeiro que sai?
            - Remoção na mesma ordem de entrada
            - Adição: Enqueue;
            - Remoção: Dequeue;

          STACK (PILHA)
          . O último a entrar, será o primeiro a sair.
          . Adição: Push;
          . Remoção: Pop;

        LIST<T> - Coleção mais flexivel e mais poderosa
        . É possível trocar a ordem de entrada dos elementos;
        . É possível ordenar a lista;

        ARRAY
        . Lidar com arquivos de baixo nível (bytes, numeros inteiros) e 
        coleções de tamanho fixo;
        . O problema é manipular o tamanho do array - o melhor seria converter 
        e trabalhar com uma lista;

        LINKED LIST (LISTA LIGADA)
        . Inserção e/ou remoção de muitos dados;
        . É possível inserir um elemento em qualquer posição da coleção;
        . cada elemento é chamado de nó - que possui dois ponteiros/referencias
        que mostra o nó anterior e o próximo nó;
        . O unico porém é que o acesso a um elemento de forma indexada, é 
        impossível.

        HASH SET
        . Verificar se um elemento está contido ou não em uma coleção;
        . Verificar se um elemento está em um outro conjunto;

        DICTIONARY<TKey, TValue>
        . Ideal para buscar um valor a partir de uma chave: buscar um elemento
        através do CPF ou do CNPJ - trabalha com chave e valor;
        . è necessário fornecer o tipo da chave e o tipo do valor.


         */
        #endregion

        #region 06 - 01 - Qual collection usar?
        /*
         * Apresentaremos um pequeno guia para ajudarmos na escolha da coleção adequada para determinadas situações. Vamos imaginar uma coleção em que sempre iremos remover o primeiro elemento colocado, isto é, a remoção será feita na mesma ordem da entrada dos elementos.

Como exemplo, usaremos uma fila de pedágio, ou uma fila de carros em um estacionamento, em que é necessário manter-se a ordem de prioridade. Assim, a coleção adequada é uma fila, ou Queue<T>, em inglês.

Trata-se de uma coleção genérica que receberá os elementos adicionados na fila pelo método Enqueue(). Os mesmos serão removidos usando-se Dequeue() e, ao fazermos isto, os elementos são reposicionados de forma que o segundo passa a ser o primeiro, e assim sucessivamente.

Há também situações em que o elemento removido será sempre o último que foi adicionado. Isto ocorre com a coleção genérica pilha, ou Stack<T>, em inglês. Nela, os elementos são adicionados usando-se Push(), e removidos com o método Pop().

Existe um tipo de coleção, a mais flexível e poderosa de todas: a List<T>, uma implementação do .NET Framework que permite a inserção de um elemento em qualquer posição da coleção (Insert()), ou especificamente no fim (Add() e AddRange()). É possível também remover elementos do meio da coleção, com Remove() ou RemoveRange(), limpar a coleção (Clear()) ou reverter sua ordem (Reverse()). Pode-se também ordená-la por um critério qualquer, com Sort().

Caso tenhamos que lidar com arquivos de baixo nível (bytes, números inteiros, por exemplo) ou tamanho fixo, quase sempre utilizamos uma matriz, ou array, em inglês, uma coleção de tamanho fixo que facilita o uso através do índice da coleção.

data[27] = #9EA3A7
Tomando como exemplo um array cujas informações gráficas, no caso, uma cor, um pixel sendo lido em uma determinada posição, são mantidas, é bastante simples acessar os dados de forma indexada. No entanto, quando precisamos alterar sua dimensão, é mais recomendado convertê-lo para uma lista.

Ainda, há situações em que é necessário inserir ou remover muitos dados em uma coleção, de forma rápida. Nestes casos, pode-se considerar utilizar uma lista ligada, ou LinkedList<T>. Com ele, é possível adicionar um elemento no início (AddFirst()), no fim (AddLast()), antes (AddBefore()) ou depois (AddAfter()) de outro elemento da mesma coleção.

O que caracteriza uma lista ligada é que cada elemento é chamado de nó, remetendo à classe do .NET Framework denominada LinkedListNode. Estes nós possuem dois ponteiros (ou duas referências) que apontam tanto para o elemento anterior quanto para o próximo, de forma a manter a ordem de entrada dos elementos nesta lista, o que possibilida a inserção ou remoção independentemente de sua posição.

As desvantagens de uma lista ligada implicam no acesso a um elemento de forma indexada, o que é impossível, e na busca de elementos em uma lista, causando um processo bastante demorado. Nestes casos, recomenda-se o uso de List<T>.

Em uma situação de operações com conjuntos matemáticos, para saber se um elemento está contido em uma coleção ou não, ou para saber se duas coleções possuem um ou mais elementos em comum, utilizaremos HashSet<T>.

Outro tipo de coleção ideal para a busca de um valor a partir de uma chave a ser armazenada (um cliente por um CPF, por exemplo, ou uma empresa através do CNPJ) é o dicionário, ou Dictionary<TKey, TValue>, para o qual forneceremos o tipo da chave e do valor.

Para saber mais
Alguns cursos complementares:

Curso Algoritmos II: MergeSort, QuickSort, Busca Binária e Análise de Algoritmo
https://cursos.alura.com.br/course/projetos-de-algoritmos-2

Curso C# III: Tópicos Avançados
https://cursos.alura.com.br/course/csharp-topicos-avancados

Curso Entity LinQ parte 1: Crie queries poderosas em C#
https://cursos.alura.com.br/course/linq-c-sharp
         */
        #endregion

        /* IList é uma sequência e aceita elementos duplicados. ISet não aceita
         duplicados e não define ordem.
         */

        #region 05 - LinkedList, Queue, Stack (fila, pilha e lista ligada)

        #region 05 - 09 - Mão na Massa: Filas
        /*
         E vamos agora começar nosso último Mão na Massa do curso!

Em muitas situações do dia-a-dia, nos deparamos com o tipo de coleção que veremos agora: as filas, que em inglês são chamadas de queues.

No .NET Framework, esse tipo de coleção é implementada pela classe Queue<T>, onde T é o tipo de dado armazenado nos elementos.

Vamos criar um novo projeto Console Application para lidar com as filas em C#.Nosso programa fará a implementação de uma fila de carros passando pelo pedágio.

Na classe Program, colocamos uma variável estática chamada pedagio, que conterá os nomes dos carros enfileirados.

static Queue<string> pedagio = new Queue<string>();
O primeiro veículo a entrar na fila será uma van. Para isso, armazenamos seu nome numa variável

string veiculo = "van";
E para deixar registrado na tela, colocamos o código que imprime o nome do carro que entrou na fila.

Console.WriteLine($"Entrou na fila: {veiculo}");
Agora vamos adicionar esse primeiro carro à fila do pedágio. Note que a classe Queue não possui método Add, pois o elemento não está simplesmente sendo adicionado a uma fila. O elemento está sendo enfileirado, o que em inglês é chamado de enqueued. Logo, o método adequado é Enqueue, ou “enfileirar”:

pedagio.Enqueue(veiculo);
Quando um elemento é enfileirado, ele assume a posição “no final da fila”. Vamos adicionar um método local, chamado Enfileirar, para encapsular essa funcionalidade e ainda exibir os veículos da fila no console:

string veiculo = "van";
Enfileirar(veiculo);
private static void Enfileirar(string veiculo)
{
    Console.WriteLine($"Entrou na fila: {veiculo}");
    pedagio.Enqueue(veiculo);
    foreach (var v in pedagio)
    {
        Console.WriteLine(v);
    }
}
Refatorando um pouco mais, vamos extrair o método que imprime a fila de veículos:

private static void Enfileirar(string veiculo)
{
    Console.WriteLine($"Entrou na fila: {veiculo}");
    pedagio.Enqueue(veiculo);
    ImprimirFila();
}
private static void ImprimirFila()
{
    Console.WriteLine("FILA:");
    foreach (var v in pedagio)
    {
        Console.WriteLine(v);
    }
}
Voltando à nossa fila, vamos começar a chamar o método Enfileirar, visualizando o primeiro elemento da coleção pedagio.

Enfileirar("van");


Entrou na fila: van
FILA:
van
Pressione qualquer tecla para continuar. . .
Ao enfileirarmos o segundo veículo, ele assumirá a posição após o último carro.

Enfileirar("kombi");


Entrou na fila: kombi
FILA:
van
kombi
E assim prosseguimos enfileirando veículos até que o último seja adicionado.

Enfileirar("guincho");


Entrou na fila: guincho
FILA:
van
kombi
guincho
Enfileirar("pickup");


Entrou na fila: pickup
FILA:
van
kombi
guincho
pickup
Por outro lado, temos que liberar os carros que estão esperando no pedágio. Mais uma vez, temos que lembrar que uma fila tem regras de prioridade não só para entrada, mas também saída. O primeiro carro a sair é o primeiro que entrou.

Vamos chamar o método que remove elementos da fila, ou seja, que “desenfileira” os carros.

string veiculo = pedagio.Dequeue();
Note que, ao desenfileirar, não estamos apenas “eliminando” um elemento da fila. Estamos também obtendo esse elemento. Precisamos saber qual foi o carro que saiu da fila, logo armazenamos seu valor na variável veiculo.

Vamos encapsular essa funcionalidade criando o novo método estático Desenfileirar, que não só remove o elemento da fila, mas também imprime esse elemento e também imprime os carros restantes na fila do pedágio.

private static void Desenfileirar()
{
    string veiculo = pedagio.Dequeue();
    Console.WriteLine($"Saiu da fila: {veiculo}");
    ImprimirFila();
}
Então podemos chamar esse método, sem parâmetro nenhum:

Desenfileirar();


Saiu da fila: van
FILA:
kombi
guincho
pickup
Note como foi o primeiro veículo que saiu da fila do pedágio.

Vamos proceder desenfileirando os demais carros da fila:
Desenfileirar();


Saiu da fila: kombi
FILA:
guincho
pickup
E se quisermos ver o próximo elemento da fila, porém sem removê-lo? Podemos “dar uma olhada” no elemento sem desenfileirar. Em inglês, “dar uma espiada” é “peek”, logo vamos usar o método Peek(), que retorna o próximo elemento a sair da fila:

if (pedagio.Peek() == "guincho")
{
    Console.WriteLine("guincho está fazendo o pagamento.");
}
Desenfileirar();


guincho está fazendo o pagamento.
Saiu da fila: guincho
FILA:
pickup
E assim sobrou apenas um veículo para passar pelo pedágio: pickup.

E o que acontece se tentarmos desenfileirar depois do último elemento ter sido removido?

Desenfileirar();
Desenfileirar();
Exceção Sem Tratamento: System.InvalidOperationException: Fila vazia.
   em System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
   em System.Collections.Generic.Queue`1.Peek()
Obviamente, tomamos uma exceção!

Então, se precisarmos colocar uma proteção na nossa fila contra esse tipo de exceção, podemos usar o método Any() para saber se há pelo menos um carro na fila do pedágio:

if (pedagio.Any())
{
    if (pedagio.Peek() == "guincho")
    {
        Console.WriteLine("guincho está fazendo o pagamento.");
    }

    string veiculo = pedagio.Dequeue();
    Console.WriteLine($"Saiu da fila: {veiculo}");
    ImprimirFila();
}
Resumindo, uma fila é uma coleção protegida contra inserção e remoção aleatória de elementos: em vez disso, uma fila possui regra de prioridade, em que o primeiro que entre é o primeiro que sai (PEPS), também chamada em inglês de first-in-first-out (FIFO).

E assim terminamos nosso Mão na Massa! Obrigado e até a próxima!
         */
        #endregion

        #region 05 - 08 - Mão na Massa: Pilhas
        /*
         * Uma “Stack” é uma coleção que funciona exatamente como uma pilha na vida real: por exemplo, numa pilha de pratos para serviço de um buffet de um restaurante, os últimos pratos colocados na pilha são os primeiros a serem retirados dela.

Vamos usar um outro tipo de metáfora para aprender como funcionam pilhas: um navegador web começa a navegar pelas páginas, seguindo os links e abrindo novas páginas. Nesse percurso, os botões anterior e próximo nos auxiliam a navegar para os itens navegados anteriormente. Essa funcionalidade é implementada internamente como duas pilhas de urls: a primeira pilha permite acessar as páginas anteriores e a segunda as próximas páginas.

Na implementação dessa funcionalidade, vamos criar um projeto Console Application que irá consumir uma nova classe, que chamaremos de Navegador.

class Program
{
    static void Main(string[] args)
    {
        var navegador = new Navegador();
    }
}
internal class Navegador
{
    public Navegador()
    {

    }
}
Assim que o navegador é instanciado, queremos saber qual a página atual que está sendo exibida. Vamos imprimir a página atual, que no início da navegação é vazia.

internal class Navegador
{
    public Navegador()
    {
        Console.WriteLine("vazia");
    }
}
porém, queremos que essa url seja armazenada numa variável. Agora precisamos criar a variável que chamaremos de atual

private string atual = "vazia";
public Navegador()
{
    Console.WriteLine(atual);
}
vazia
Pressione qualquer tecla para continuar. . .
O primeiro site que queremos acessar é o google.com. Vamos implementar o método para navegar para esse site

var navegador = new Navegador();
navegador.NavegarPara("google.com");
internal void NavegarPara(string v)
{
    throw new NotImplementedException();
}
O que esse método faz? Primeiro, ele deve definir a página atual como a url que está sendo recebida como parâmetro pelo método.

internal void NavegarPara(string url)
{
    atual = url;
}
Mas note que, se fizermos isso, perderemos o valor da variável atual. Precisamos guardar seu valor para ser acessado posteriormente. Mas onde iremos guardá-lo?

Numa coleção, obviamente. Mas qual coleção? Como mencionamos antes, o navegador funciona com duas pilhas de navegação, tanto para frente quanto para trás. Vamos criar a pilha de navegação anterior:

private readonly Stack<string> historicoAnterior = new Stack<string>();
Agora sim, vamos guardar o valor da url atual nessa pilha. Mas note que um Stack não possui o método Add. Em vez disso, o método usado para “empilhar” numa pilha é Push, que sempre adiciona o elemento no topo da pilha:

internal void NavegarPara(string url)
{
    historicoAnterior.Push(atual);
    atual = url;
}
Também vamos imprimir a página atual ao final do método

internal void NavegarPara(string url)
{
    historicoAnterior.Push(atual);
    atual = url;
    Console.WriteLine(atual);
}
vazia
google.com
Pressione qualquer tecla para continuar. . .
A partir do site google.com, nosso usuário procura por “ensino de tecnologia” e encontra o site da Caelum. A partir dele, ele clica num link para o site da alura:

var navegador = new Navegador();
navegador.NavegarPara("google.com");
navegador.NavegarPara("caelum.com.br");
navegador.NavegarPara("alura.com.br");
vazia
google.com
caelum.com.br
alura.com.br
Pressione qualquer tecla para continuar. . .
Agora que já navegou para os 3 sites, nosso usuário decide voltar para o site anterior. Ou seja, precisamos implementar uma navegação para trás. Faremos isso criando um método na classe Navegador chamado Anterior():

var navegador = new Navegador();
navegador.NavegarPara("google.com");
navegador.NavegarPara("caelum.com.br");
navegador.NavegarPara("alura.com.br");
navegador.Anterior();
internal void Anterior()
{
    throw new NotImplementedException();
}
Esse método deve pegar o valor da última url navegada e defini-lo como url atual.

Quando trabalhamos com pilhas, o método para obter elemento na verdade é o que “desempilha”, logo o nome do método é Pop:

internal void Anterior()
{
    atual = historicoAnterior.Pop();
}
Mas perceba que, fazendo isso, estaremos perdendo o valor da url atual. Então precisamos guardá-lo em algum lugar. Mas onde?

A resposta é: na pilha de urls “à frente”, que poderão ser navegadas com o botão “próximo” do navegador. vamos chamar essa segunda pilha de historicoProximo:

private readonly Stack<string> historicoProximo = new Stack<string>();
Para guardar o valor da url atual, incluiremos o valor em historicoProximo através do método `Push`.
internal void Anterior()
{
    historicoProximo.Push(atual);
    atual = historicoAnterior.Pop();
    Console.WriteLine(atual);
}
Assim, quando desempilhamos um valor de uma pilha, empilhamos esse mesmo valor em outra. E vice-versa!

vazia
google.com
caelum.com.br
alura.com.br
caelum.com.br
google.com
Pressione qualquer tecla para continuar. . .
Perceba como conseguimos voltar ao site anterior, caelum.com.br!

Vamos voltar mais duas vezes a navegaçao:

var navegador = new Navegador();
navegador.NavegarPara("google.com");
navegador.NavegarPara("caelum.com.br");
navegador.NavegarPara("alura.com.br");
navegador.Anterior();
navegador.Anterior();
navegador.Anterior();
vazia
google.com
caelum.com.br
alura.com.br
caelum.com.br
google.com
vazia
Pressione qualquer tecla para continuar. . .
Agora sim, conseguimos voltar ao início da nossa navegação, até a url vazia. Mas e se tentarmos voltar mais uma vez?

navegador.Anterior();
vazia
google.com
caelum.com.br
alura.com.br
caelum.com.br
google.com
vazia

Exceção Sem Tratamento: System.InvalidOperationException: Pilha vazia.
   em System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
Tomamos uma exceção de pilha vazia!

Precisamos então de uma proteção. Vamos verificar se há elementos na pilha, com o método Any():

internal void Anterior()
{
    if (historicoAnterior.Any())
    {
        historicoProximo.Push(atual);
        atual = historicoAnterior.Pop();
        Console.WriteLine(atual);
    }
}
vazia
google.com
caelum.com.br
alura.com.br
caelum.com.br
google.com
vazia
Pressione qualquer tecla para continuar. . .
Então nos resta implementar a navegação para a frente. Vamos criar o método Proximo na classe Navegador:

var navegador = new Navegador();
navegador.NavegarPara("google.com");
navegador.NavegarPara("caelum.com.br");
navegador.NavegarPara("alura.com.br");
navegador.Anterior();
navegador.Anterior();
navegador.Anterior();
navegador.Anterior();
navegador.Proximo();
internal void Proximo()
{
    throw new NotImplementedException();
}
Seguindo o mesmo raciocínio do método Anterior, temos que primeiro proteger o método e verificar se há elementos na pilha historicoProximo, com o método Any:

internal void Proximo()
{
    if (historicoProximo.Any())
    {

    }
}
E agora guardamos o valor da url atual na pilha anterior:

internal void Proximo()
{
    if (historicoProximo.Any())
    {
        historicoAnterior.Push(atual);
    }
}
Por fim, desempilhamos um valor da pilha historicoProximo e atribuimos ele à variavel atual.

internal void Proximo()
{
    if (historicoProximo.Any())
    {
        historicoAnterior.Push(atual);
        atual = historicoProximo.Pop();
        Console.WriteLine(atual);
    }
}
Rodando a aplicação, temos a navegação para a próxima url, que é “google.com”:

vazia
google.com
caelum.com.br
alura.com.br
caelum.com.br
google.com
vazia
google.com
Pressione qualquer tecla para continuar. . .
E assim concluímos nosso Mão na Massa sobre Pilhas. Até à próxima!
         */
        #endregion

        #region 05 - 07 - Mão na Massa - Lista Ligada
        /*
         * Vamos iniciar esse Mão na Massa para aprender um pouco mais e implentar uma lista ligada.

As listas do .NET Framework (List<T>) oferecem diversas funcionalidades e são bastante poderosas. Mas como elas são baseadas em arrays (uma lista pode ser imaginada como um array dinâmico), elas possuem um ponto fraco dos arrays: o custo de adicionar ou remover elementos no meio da lista.

Imagine uma lista que armazena nomes de frutas. Essas frutas ficam armazenadas no array interno da lista, e os elementos desse array ocupam posições sequenciais na memória:



//Imagine uma lista de frutas
List<string> frutas = new List<string>
{
    "abacate", "banana", "caqui", "damasco", "figo"
};
//Vamos imprimir essa lista
foreach (var fruta in frutas)
{
    Console.WriteLine(fruta);
}
abacate
banana
caqui
damasco
figo
O que acontece se quisermos inserir um elemento no meio da lista, na terceira posição (índice 2)?

frutas.Insert(2, "caju");
Com o método Insert, o elemento será adicionado, mas o que ocorrerá com os outros elementos seguintes da lista?



Eles serão movidos “para a frente”, para liberar espaço para o elemento que está sendo inserido!

foreach (var fruta in frutas)
{
    Console.WriteLine(fruta);
}
abacate
banana
caju
caqui
damasco
figo
Por esse motivo, uma coleção List é ineficiente para inserir ou remover elementos no início da coleção, porque os elementos precisam ser reposicionados com frequência.

Se quisermos adicionar ou remover elementos com muita frequência, podemos considerar um LinkedList.

Um LinkedList consegue armazenar elementos numa determinada ordem, porém, na memória, os elementos de um LinkedList não precisam ocupar uma posição sequencial. Imagine um LinkedList com os dias da semana, sendo d1 “domingo” e d7 “sábado”:



Perceba que d4 é “quarta-feira”, porém está posicionado na memória antes de d2 “segunda”. Como o LinkedList consegue manter a ordem?

Simples: No LinkedList, cada elemento possui 2 links: o before e o after:



Agora vamos ver como esse LinkedList foi montado. Vamos instanciar uma variável dias que armazenará nossa lista ligada de dias da semana:

LinkedList<string> dias = new LinkedList<string>();
O primeiro elemento a ser inserido é “quarta”.

var d4 = dias.AddFirst("quarta");


Note que o método AddFirst precisa ser obrigatoriamente chamado para adicionar o primeiro elemento. Note também que ele está sozinho na lista, portanto as ligações “antes” e “depois” desse elemento estão vazias, isto é, nulas.

Mas aí resta a dúvida: se estamos armazenando strings nesse LinkedList, de onde vêm as ligações before e after? Uma string não possui essas propriedades…

É importante notar que o que estamos armazenando na verdade não são as strings diretamente, mas sim um objeto especial que contém a string. Esse objeto especial é da classe LinkedListNode, e ele representa os nós da lista ligada.

Agora vamos proceder com o segundo elemento (o segundo nó). Mas não podemos simplesmente adicionar com Add, como fazemos com o List<T>. Um nó só pode ser adicionado “sozinho” se for o primeiro da lista ligada. A partir do segundo nó, todos precisam ser adicionados antes ou depois de um nó preexistente.

O segundo nó d2 será adicionado antes de d4, logo o uso do método AddBefore.

var d2 = dias.AddBefore(d4, "segunda");


E o nó d3 é adicionado depois de d2:

var d3 = dias.AddAfter(d2, "terça");


Note que antes d2 era ligado diretamente a d4. Mas como d3 foi adicionado depois de d2, as ligações que ficariam soltas foram redirecionadas para d3!

Agora adicionamos d6 depois de d4:

var d6 = dias.AddAfter(d4, "sexta");


Perceba que d6 agora é o último nó da lista ligada. Vamos adicionar agora o d7...

var d7 =dias.AddAfter(d6, "sábado");


E adicionando o d5 antes de d6, as ligações entre d4 e d6 foram redirecionadas para o nó d5:

var d5 = dias.AddBefore(d6, "quinta");


Restando apenas adicionar o nó d1 antes de d2.

var d1 = dias.AddBefore(d2, "domingo");


Agora que adicionamos todos os nós, vamos percorrer a lista, imprimindo todos os elementos:

foreach (var dia in dias)
{
    Console.WriteLine(dia);
}
domingo
segunda
terça
quarta
quinta
sexta
sábado
domingo
E se quisermos remover um nó?

Vamos remover o nó “quarta-feira” (d4):

var quarta = dias.Find("quarta");
dias.Remove("quarta");
IMPORTANTE: LinkedList NÃO DÁ suporte ao acesso de índice, por isso podemos fazer um laço foreach mas não um laço for!

Para removermos um elemento, podemos tanto remover pelo valor quanto pela referência do LinkedListNode:

dias.Remove("quarta") ou dias.Remove(quarta);

Automaticamente, os elementos d3 e d5, que apontavam para d4, acabam apontando para eles mesmos, assim “fazendo a ponte” para ocupar o espaço que ficou vazio:



Mas note que, assim como a inclusão de nós, a remoção desse nó também não necessitou de um redimensionamento do array, nem a realocação dos nós em memória. Os elementos continuaram em memória como antes, a única mudança foi entre os ponteiros “before” e “after” desses nós!

Vamos imprimir então nossa lista ligada novamente para ver as alterações:

foreach (var dia in dias)
{
    Console.WriteLine(dia);
}
domingo
segunda
terça
quinta
sexta
sábado
E assim aprendemos na prática que uma lista ligada é um tipo de coleção especializada e otimizada para adicionar e remover muitos elementos com bastante frequência!

A seguir vamos ver como trabalhar com pilhas. Até à próxima!
         */
        #endregion

        #region 05 - 05 - Queue
        /*
         * Neste vídeo veremos outro problema de vida real em um projeto, implementando uma fila de pedágio para veículos. Declararemos no escopo da classe Program uma variável estática que será uma coleção que representará a fila (Queue).

static Queue<string> pedagio = new Queue<string>();

static void Main(string[] args)
{
    //entrou: van
    string veiculo = "van";
    Console.WriteLine(veiculo);
}
Rodando a aplicação, obteremos a impressão de van, como gostaríamos. No entanto, queremos descrever melhor o que está acontecendo. Acrescentaremos:

static Queue<string> pedagio = new Queue<string>();

static void Main(string[] args)
{
    //entrou: van
    string veiculo = "van";
    Console.WriteLine($"Entrou na fila: {veiculo}");
}
Rodando a app novamente, o resultado impresso será Entrou na fila: van. Para realmente adicionarmos um elemento na fila, utilizaremos a variável pedagio e chamaremos um método de adição. Caso existisse como opção em filas .NET Framework, poderíamos pensar em usar o Add(), mas optaremos por Enqueue(), a receber a variável veiculo.

Em seguida, para sabermos o estado atual da fila, varreremos os veículos, com sendo v o representante de um deles:

static Queue<string> pedagio = new Queue<string>();

static void Main(string[] args)
{
    //entrou: van
    string veiculo = "van";
    Console.WriteLine($"Entrou na fila: {veiculo}");
    pedagio.Enqueue(veiculo);
    Console.WriteLine("FILA:");
    foreach (var v in pedagio)
    {
        Console.WriteLine(v);
    }
}
Com "Ctrl + F5" rodaremos novamente o código. Obteremos:

Entrou na fila: van
FILA:
van
Legal! Conforme adicionamos mais veículos, não queremos que o código fique duplicado. Por isto, selecionaremos parte do que digitamos e a extrairemos em um método (Enfileirar()) por meio de "Ctrl + .":

static void Main(string[] args)
{
    //entrou: van
    string veiculo = "van";
    Enfileirar(veiculo);
}
Refatorando mais um pouco, é possível simplesmente removermos a linha string veiculo = "van";, trocando o local com a referência para veiculo pelo nome van:

//entrou: van
Enfileirar("van");
Vamos rodar para ver se esta alteração não afetou negativamente o código. Tendo tudo funcionado conforme esperado, seguiremos adicionando mais veículos à fila:

//entrou: kombi
Enfileirar("kombi");
//entrou: guincho
Enfileirar("guincho");
//entrou: pickup
Enfileirar("pickup");
Agora faremos o caminho inverso, pois os carros passarão pela cancela do pedágio e irão embora. Percebam que uma fila não é uma coleção qualquer, portanto temos que seguir algumas regras, e uma delas é: ao entrar na fila, o carro vai para o fim dela e, em relação à saída, é sempre aquele que está lá na frente que irá sair primeiro.

Faremos esta liberação para os carros começarem a sair, ou seja, chamando o processo inverso do Enqueue, o método para desenfileirar, ou Dequeue() em inglês. Ele não recebe nenhum parâmetro, porém retorna o nome do carro que acabou de sair.

//carro liberado
pedagio.Dequeue();
Extrairemos a chamada para um novo método, que denominaremos Desenfileirar(). Apertando F12, começaremos a trabalhar neste método. Ao tirarmos um elemento de uma fila, ele retorna como uma string, que é o tipo de elemento contido. Atribuiremos este valor a uma variável veiculo. Para exibirmos quem sai, usaremos Console.WriteLine():

private static void Desenfileirar()
{
    string veiculo = pedagio.Dequeue();
    Console.WriteLine($"Saiu da fila: {veiculo}");
}
Rodaremos este código com "Ctrl + F5", e obteremos Saiu da fila: van. Como também queremos ver a situação atual da fila, vamos imprimir os veículos. Já temos este processo no método Enfileirar(), e não queremos copiar e colá-lo no método recém criado, pois com isto teríamos uma duplicação de código.

O que faremos, então, é extrair o método que imprime a fila para podermos reutilizá-lo. O nome deste método será ImprimirFila(), e também o chamaremos no momento de desenfileirarmos o veículo:

private static void Desenfileirar()
{
    string veiculo = pedagio.Dequeue();
    Console.WriteLine($"Saiu da fila: {veiculo}");
    ImprimirFila();
}
Vamos rodar a aplicação e ver o que ocorre. Teremos o seguinte:

Saiu da fila: van
FILA:
kombi
guincho
pickup
Do mesmo modo, liberaremos outro carro e teremos a informação de que a kombi (o veículo seguinte na nossa lista) saiu da fila, permanecendo apenas o guincho e a pickup. É interessante notar que ao descobrirmos qual carro está sendo liberado (com o método Dequeue()), já o removemos. Para sabermos qual veículo está para sair da fila, não poderemos utilizar o Dequeue(), já que assim o removeremos.

Para verificarmos este veículo seguinte sem que ele seja removido, chamaremos outro método! Digamos que queremos saber se quem está esperando na fila é o guincho. Como faríamos? Poderíamos utilizar uma condição if:

private static void Desenfileirar()
{
    if (pedagio.Peek() == "guincho")
    {
        Console.WriteLine("guincho está fazendo o pagamento.");
    }
}
Feito isso, usando Desenfileirar(); liberaremos mais um veículo, rodando a aplicação em seguida. Teremos a impressão:

guincho está fazendo o pagamento.
Saiu da fila: guincho
FILA:
pickup
Faremos o mesmo procedimento para liberarmos a pickup. Agora que não há nada na fila, caso tentemos desenfileirar novamente, ocorre um erro de exceção sem tratamento alegando-se que a fila está vazia. Para evitarmos situações do tipo, é necessário fazermos uma proteção. No método Desenfileirar(), colocaremos uma condição para verificação de existência de pelo menos um elemento na fila.

private static void Desenfileirar()
{
    if (pedagio.Any())
    {
        if (pedagio.Peek() == "guincho")
        {
            Console.WriteLine("guincho está fazendo o pagamento.");
        }

        string veiculo = pedagio.Dequeue();
        Console.WriteLine($"Saiu da fila: {veiculo}");
        ImprimirFila();
    }
}
Rodando a aplicação de novo, não teremos nenhum erro, nenhuma exceção será lançada. Portanto, aprendemos como implementar uma solução para um problema prático, que também poderia ser uma fila de mercado ou atendimento médico, por exemplo.

Lembrando que filas normalmente são utilizadas juntamente com pilhas. Estas possuem uma prioridade distinta: o primeiro elemento que entra é o último que sai, enquanto numa fila o primeiro que entra é, também, o primeiro que sai.
         */
        #endregion

        #region 05 - 04 - Stack
        /*
         Neste vídeo trabalharemos com outro projeto novo, em que implementaremos a solução de um problema de navegação de browser, ou navegador Web. Abrindo o site da Alura no Google Chrome como exemplo, veremos as páginas navegadas anteriormente por meio do botão "Voltar" (a seta para a esquerda localizada ao lado do campo de endereço). Do mesmo modo, se clicarmos no botão de "Avançar" (a seta para a direita), faremos o caminho inverso.

Neste momento veremos como implementar um novo tipo de coleção do .NET Framework, criando inicialmente uma instância de um navegador, sendo que a classe ainda não existe. Utilizaremos "Ctrl + ." e selecionaremos "Generate class 'Navegador'":

class Program
{
    static void Main(string[] args)
    {
        var navegador = new Navegador();
    }
}

internal class Navegador
{
    private string atual = "vazia";

    public Navegador()
    {
        Console.WriteLine(atual);
    }
}
Rodaremos este código com "Ctrl + F5" e obteremos a impressão:

vazia
Vamos melhorar isto imprimindo assim:

internal class Navegador
{
    private string atual = "vazia";

    public Navegador()
    {
        Console.WriteLine("Página atual: " + atual);
    }
}
Ao que será retornado

Página atual: vazia
Agora simularemos o processo de navegação entre páginas anteriores e posteriores a partir do método NavegarPara(), ainda inexistente, que será extraído, redefinindo-se a página atual da navegação:

class Program
{
    static void Main(string[] args)
    {
        var navegador = new Navegador();

        navegador.NavegarPara("google.com");
    }
}

internal class Navegador
{
    private string atual = "vazia";

    public Navegador()
    {
        Console.WriteLine("Página atual: " + atual);
    }

    internal void NavegarPara(string url)
    {
        atual = url;
        Console.WriteLine("Página atual: " + atual);
    }
}
Rodaremos novamente a aplicação e teremos:

Página atual: google.com
Faremos o mesmo processo para sermos redirecionados aos sites da Caelum e da Alura:

var navegador = new Navegador();

navegador.NavegarPara("google.com");
navegador.NavegarPara("caelum.com.br");
navegador.NavegarPara("alura.com.br");
Desta vez, navegaremos à página anterior criando um método Anterior() e utilizando "Ctrl + .".

internal void Anterior()
{
}
No entanto, quando navegamos a outras páginas, perdemos o valor da página atual.

navegador.NavegarPara("alura.com.br");

navegador.Anterior();
Portanto, é necessário alterarmos o método NavegarPara() para salvar a página atual a ser substituída. Para isto, criaremos uma coleção denominada Pilha, ou Stack, em inglês.

No escopo da classe Navegador, digitaremos:

private readonly Stack<string> historicoAnterior = new Stack<string>();
Salvaremos em historicoAnterior a página que deixou de ser a atual, e não poderemos usar Add() para adicioná-la em nosso histórico, pois este método não funciona neste caso de coleção especializada.

Chamaremos outro método, Push(), que receberá nossa página atual.

internal void NavegarPara(string url)
{
    historicoAnterior.Push(atual);
    atual = url;
    Console.WriteLine("Página atual: " + atual);
}
Feito isso, poderemos implementar o método Anterior() para obtenção da página contida no histórico, utilizando Pop(), responsável por pegar o próximo elemento de uma pilha. Ele retorna uma string, portanto precisaremos armazená-la em algum lugar.

internal void Anterior()
{
    atual = historicoAnterior.Pop();
    Console.WriteLine("Página atual: " + atual);
}
Rodaremos a aplicação e verificaremos que passamos de uma página atual vazia para google.com, depois para caelum.com.br, alura.com.br e por fim caelum.com.br, o que quer dizer que conseguimos voltar com sucesso.

Navegaremos à página anterior para chegar à página do Google:

var navegador = new Navegador();

navegador.NavegarPara("google.com");
navegador.NavegarPara("caelum.com.br");
navegador.NavegarPara("alura.com.br");

navegador.Anterior();
navegador.Anterior();
Com "Ctrl + F5", obteremos a sequência de visitações da seguinte forma:

Página atual: vazia
Página atual: google.com
Página atual: caelum.com.br
Página atual: alura.com.br
Página atual: caelum.com.br
Página atual: google.com
Repetindo o procedimento, voltaremos à página vazia. Nosso histórico está funcionando! No entanto, se tentarmos voltar mais uma vez, ocorrerá um erro de exceção sem tratamento, pois a pilha está vazia. Neste caso, não poderemos utilizar o método Pop() pois não existe nada ali para ser removido.

Portanto, colocaremos uma proteção verificando se há algum elemento na pilha, acrescentando uma condição no método Anterior():

internal void Anterior()
{
    if(historicoAnterior.Any())
    {
        atual = historicoAnterior.Pop();
        Console.WriteLine("Página atual: " + atual);
    }
}
Rodando o código, o programa não dá mais erro. Continuando, vamos tentar navegar para a frente agora.

var navegador = new Navegador();

navegador.NavegarPara("google.com");
navegador.NavegarPara("caelum.com.br");
navegador.NavegarPara("alura.com.br");

navegador.Anterior();
navegador.Anterior();
navegador.Anterior();
navegador.Anterior();

navegador.Proximo();
No método Main(), implementaremos Proximo(), assim como fizemos com Anterior(). Desta vez, pegaremos o histórico do próximo, ou seja, teremos dois tipos de históricos. Na classe Navegador criaremos uma nova pilha para este novo histórico:

private readonly Stack<string> historicoAnterior = new Stack<string>();
private readonly Stack<string> historicoProximo = new Stack<string>();
E o código referente ao novo método ficará assim:

internal void Proximo()
{
    atual = historicoProximo.Pop();
    Console.WriteLine("Página atual: " + atual);
}
Vamos rodar e ver o que acontece?

Deu erro! Somos informados de que a pilha está vazia, precisaremos alimentá-la. Isto é, ao navegarmos a uma página anterior, precisaremos alimentar a pilha do historicoProximo.

Voltando ao método Anterior(), faremos algumas alterações:

if(historicoAnterior.Any())
{
    historicoProximo.Push(atual);
    atual = historicoAnterior.Pop();
    Console.WriteLine("Página atual: " + atual);
}
Rodando o código de novo, teremos que, após voltarmos à página vazia, acessamos google.com com sucesso. Ao seguirmos à próxima página, alimentaremos o histórico anterior, pois elas se complementam.

Caso nosso historicoProximo possuir algum elemento, aí sim será possível navegarmos adiante. Caso contrário obteremos o mesmo erro de pilha vazia.

internal void Proximo()
{
    if(historicoProximo.Any())
    {
        historicoAnterior.Push(atual);
        atual = historicoProximo.Pop();
        Console.WriteLine("Página atual: " + atual);
    }
}
A aplicação roda com sucesso, e conseguimos implementar estas duas funcionalidades, os dois botões do navegador. Vimos como funciona a pilha, com a prioridade de que "o último elemento que entra é o primeiro que sai", o que chamamos de LIFO, em inglês, "Last in, first out".
         */
        #endregion

        #region 05 - 01 - LinkedList
        /*
         * Isso mesmo! Cada elemento de um LinkedList é um nó, ou seja, um objeto LinkedListNode, que mantém duas referências, apontando para o nó anterior e outra apontando para o próximo nó, e essa lista pode ser navegada pela ordem definida pela associação entre esses nós.
         * 
         Neste vídeo trabalharemos com um novo projeto Console Application, e um tipo de coleção do .NET Framework. Antes, revisaremos o que foi visto até aqui criando uma lista de frutas, que inicializaremos com alguns valores (frutas).

List<string> frutas = new List<string>
{
    "abacate", "banana", "caqui", "damasco", "figo"
};
//vamos imprimir essa lista
foreach (var fruta in frutas)
{
    Console.WriteLine(fruta);
}
Rodando a aplicação, teremos:

abacate
banana
caqui
damasco
figo
Esta lista é armazenada em memória em um array interno, com posições sequenciais. Caso queiramos adicionar um elemento ao fim da lista, apenas a última posição será alterada, sendo possível removê-lo posteriormente, e redimensionar a lista.

Para inserirmos um elemento no meio da lista, algo que exige mais esforço computacional, usaremos como exemplo a imagem abaixo, com caju ocupando a posição após banana, antes ocupada por caqui. damasco e figo, que estavam na sequência, também serão deslocados à direita.

frutas ocupando retângulos alinhados horizontalmente e representando a memória, e setas vermelhas indicando deslocamento de elementos

Por causa dos deslocamentos, há necessidade de maior processamento. Se quisermos remover caju, o que acontecerá? Não poderemos ter um "buraco" no meio do array de listagem. Neste caso, os elementos seguintes precisarão ser realocados.

Para uma lista pequena, este processo é relativamente rápido, porém o desempenho será afetado conforme o tamanho da lista, sendo portanto ineficiente para listas maiores. Para estes casos, em que inserções ou remoções ocorrem frequentemente, é necessário utilizar outro tipo de coleção do .NET Framework, a Lista Ligada (ou linked list).

Com ela, poderemos esquecer a organização em memória sequenciada, já que seus elementos não precisam estar memorizados em sequência para representar a ordem desejada. Cada elemento contém sua posição anterior, atual e seguinte, e chamamos isto de nó. Ou seja, cada elemento é um nó que contém um valor.

Na imagem abaixo, temos em memória uma lista ligada com cada valor representando um dia da semana. d1 é domingo, e aparece ao fim da lista; d5 é quinta-feira, aparece antes de domingo e depois de d7, que é sábado. Como se mantém uma ordem em uma lista dessas?

memória sendo representada com uma lista alinhada horizontalmente, com os valores dentro de círculos coloridos

No diagrama abaixo, veremos as ligações entre os elementos (ou nós) desta lista ligada:

a mesma memória com os valores dentro de círculos coloridos, agora com setas apontando um elemento a outro em ordem numérica

O elemento inicial, d1 (domingo), aponta ao d2 (segunda-feira), que por sua vez aponta para d3 (terça), e assim por diante. Neste momento, instanciaremos uma lista ligada cujos elementos precisarão ser incluídos um a um.

Como a lista ainda está vazia, adicionaremos o primeiro elemento (AddFirst()) passando uma string com o valor quarta.

//instanciando uma nova lista ligada: dias da semana
LinkedList<string> dias = new LinkedList<string>();
//adicionando um dia qualquer: "quarta"
var d4 = dias.AddFirst("quarta");
Quando passamos o mouse em cima de AddFirst(), vê-se que é retornado um nó chamado LinkedListNode. É ele que irá armazenar o valor quarta, agora o primeiro elemento da nossa lista ligada. Cada elemento desta lista é um nó LinkedListNode<T>, e não uma string, como poderíamos imaginar.

Isto é necessário pois uma string é um objeto que não contém informações de ponteiros, então, para a implementação desta lista ligada, a Microsoft precisou de um tipo de objeto que encapsulasse o valor - neste caso a string -, sendo que LinkedListNode é o objeto com os ponteiros referentes a posições anteriores e posteriores.

Para alcançarmos o valor de d4, acessaremos a propriedade d4.Value:

//mas e o valor "quarta"? está na propriedade d4.Value
Console.WriteLine("d4.Value: " + d4.Value);
Com "Ctrl + F5", rodaremos a aplicação. O resultado impresso é:

d4.Value: quarta
E se quisermos adicionar mais itens? É importante notar que o LinkedList não possui Add, como vimos em outras coleções! Na verdade, ele possui estas quatro formas de adição:

como primeiro nó (AddFirst());
como último nó (AddLast());
antes de um nó previamente conhecido (AddBefore());
depois de um nó previamente conhecido (AddAfter()).
Vamos adicionar, então, um novo valor (segunda-feira), antes de quarta-feira:

var d2 = dias.AddBefore(d4, "segunda");
Com d2 e d4 ligados entre si, como acessaremos um nó através do outro? Para pegar o nó seguinte a partir de d2, por exemplo, teremos que d2.Next é igual a d4. Em relação a d4, colocaremos que d4.Previous é igual a d2.

Continuando com nossa lista ligada, adicionaremos terça depois de segunda-feira:

var d3 = dias.AddAfter(d2, "terça");
Neste momento d3 se encontra entre dois elementos, d2 e d4. Perceba que os "ponteiros", ou referências de ambos os elementos foram redirecionados para d3!

Em seguida, adicionaremos sexta depois de quarta-feira:

var d6 = dias.AddAfter(d4, "sexta");
d6 agora aparece na última posição da fila. Continuando, acrescentaremos sábado após sexta:

var d7 = dias.AddAfter(d6, "sábado");
Colocando quinta antes de sexta, teremos:

var d5 = dias.AddBefore(d6, "quinta");
Para domingo antes de segunda, digitaremos:

var d1 = dias.AddBefore(d2, "domingo");
Visualmente, a memória ficará assim:

memória com valores dentro de círculos coloridos, com setas apontando um elemento a outro nas dois sentidos

Imprimiremos a lista ligada da mesma forma que fazemos com uma lista qualquer, por meio do foreach, que a varrerá.

foreach (var dia in dias)
{
    Console.WriteLine(dia);
}
Rodando o código, teremos com sucesso a impressão:

domingo
segunda
terça
quarta
quinta
sexta
sábado
No entanto, não conseguiremos imprimir utilizando o laço for, pois o LinkedList não dá suporte ao acesso por meio de índices. No caso de querermos usar dias[0], por exemplo, teremos uma sintaxe inválida.

Como já foi dito, LinkedList facilita muito o acesso à inserção e remoção rápidas, porém, ele não é tão eficiente na realização de buscas. Para isto, utilizaremos o método Find(), como neste exemplo:

var quarta = dias.Find("quarta");
Poderemos remover um elemento através do nome do nó, como também pela referência do LinkedListNode. Para removermos quarta-feira, existem as opções dias.Remove("quarta") ou dias.Remove(d4).

Rodaremos a aplicação após escolhermos uma delas, imprimindo novamente a lista com o laço foreach:

dias.Remove("quarta");
foreach (var dia in dias)
{
    Console.WriteLine(dia);
}
Obteremos o seguinte:

domingo
segunda
terça
quinta
sexta
sábado
Neste vídeo vimos os prós e os contras de implementarmos listas ligadas!
         */
        #endregion

        #endregion

        #region 04 Dicionários

        #region 04 - Aul 04 - Funcionamento de um dicionário 
        /*
         O que acontecerá se tentarmos adicionar ao nosso dicionário um aluno com uma chave preexistente? Vamos fazer um teste cadastrando e rodando a aplicação com um novo aluno cujo número de matrícula é 5617:

Aluno fabio = new Aluno("Fabio Gushiken", 5617);
csharpColecoes.Matricula(fabio);
Aparece um erro: "Já foi adicionado um item com a mesma chave"!!

Uma das características de um dicionário é justamente esta: a chave é única. Não é possível armazenar mais de um valor em uma chave. Vamos comentar a linha que acabamos de criar e testar o que acontece ao substituirmos o aluno com a chave 5617 pelo valor do aluno fabio.

Na classe Curso, teremos:

//e se quisermos trocar o aluno que tem a mesma chave?
csharpColecoes.SubstituiAluno(fabio);
Criaremos o método SubstituiAluno() com o cursor em cima e usando "Ctrl + .". Com F12, navegaremos a ele e o implementaremos. Este código de substituição precisará atribuir um novo valor àquele preexistente na chave que estamos verificando. Para isto, referenciaremos o dicionário e usaremos uma sintaxe muito similar àquela de arrays, com colchetes.

internal void SubstituiAluno(Aluno aluno)
{
    this.dicionarioAlunos[aluno.NumeroMatricula] = aluno;
}
Voltaremos a Program.cs e faremos uma pergunta para verificar qual aluno possui a matrícula 5617.

//pergunta: "Quem é o Aluno 5617 agora?"
Console.WriteLine("Quem é o Aluno 5617 agora?");
Console.WriteLine(csharpColecoes.BuscaMatriculado(5617));
Rodaremos a aplicação mais uma vez, e obteremos:

Quem é o Aluno 5617 agora?
[Aluno: Fabio Gushiken, matricula: 5617]
Deste modo conseguimos substituir um aluno para uma matrícula que já existia antes. Para terminar, veremos como um dicionário é implementado internamente. Assim como o HashSet, ele também faz uso de um código de dispersão. No diagrama abaixo veremos que de um lado há as chaves e, do outro, os valores.

esquema de tabela de dispersão, com os valores no centro, as chaves (nomes dos alunos à esquerda) e os valores (nomes e matrículas) à direita

Ao buscarmos pela chave, o .NET Framework irá pegá-la internamente e rodar um algoritmo para a obtenção do código de dispersão, que indicará o grupo de valores em que cairá o valor que estamos armazenando, como se fossem gavetas ou caixas que os armazenam.

A busca pode ser mais ou menos eficiente de acordo com o código de dispersão. Na grande maioria dos casos, como no do dicionário, é possível confiar no algoritmo gerado no GetHashCode do próprio programa. Observando o diagrama, para obtermos o valor Rafael Rollo ou Rafael Nercessian, ambos caíram no mesmo grupo, pois seus valores foram calculados para o mesmo hash code (código de dispersão) do dicionário.

No próximo vídeo veremos como trabalhar com listas ligadas, pilhas e filas. Até lá!
         */
        #endregion

        #region 04 - Aula 01 - Introdução a dicionários
        /*
         Continuando com o nosso projeto, trabalharemos com dicionários e, para começar, limparemos o console. Sabemos que existe um mecanismo para a verificação da existência do aluno no curso por meio do HashSet, agora utilizaremos o método de busca para saber que aluno possui determinado número de matrícula. Perguntaremos isto ao console e implementaremos um novo método chamado BuscaMatriculado(), a ser chamado na classe Curso.

//limpando o console
Console.Clear();

//já temos método para saber se o aluno está matriculado.
//mas agora precisamos buscar aluno por número de matrícula

//pergunta: "Quem é o aluno com matrícula 5617?"
Console.WriteLine("Quem é o aluno com matrícula 5617?");
//implementando Curso.BuscaMatriculado
Aluno aluno5617 = csharpColecoes.BuscaMatriculado(5617);
Como o método ainda não existe, posicionaremos o mouse em cima dele e, com "Ctrl + .", geraremos o método, para o qual navegaremos por meio do F12 e o implementaremos. Varreremos a coleção até encontrarmos o aluno cujo número de matrícula é 5617. Caso isto não ocorra, será lançada uma exceção:

internal Aluno BuscaMatriculado(int numeroMatricula)
{
    foreach (var aluno in alunos)
    {
        if (aluno.NumeroMatricula == numeroMatricula)
        {
            return aluno;
        }
    }
    throw new Exception("Matrícula não encontrada: " + numeroMatricula);
}
Voltando a Program.cs, imprimiremos o resultado (o aluno encontrado):

//imprimindo o aluno5617 encontrado
Console.WriteLine("aluno5617: " + aluno5617);
Vamos rodar a aplicação e ver o que acontece? Obteremos o seguinte:

Quem é o aluno com matrícula 5617?
aluno5617: [Aluno: Ana Losnak, matricula: 5617]
Será que esta busca pode ser melhorada?

O .NET Framework felizmente possui um tipo de coleção específico, o dicionário, que permite associar uma chave (no caso, a matrícula) a um valor (o nome do aluno).

No início da classe Curso, em que já temos o conjunto (HashSet) declarado, implementaremos um dicionário para trabalho paralelo, bem como a interface privada IDictionary<>:

class Curso
{
    //implementando um dicionário de alunos
    private IDictionary<int, Aluno> dicionarioAlunos = new Dictionary<int, Aluno>();

    //...
}
Por ora, o dicionário está vazio, tendo sua utilidade assim que for alimentada, a partir do método de matricular os alunos.

internal void Matricula(Aluno aluno)
{
    this.alunos.Add(aluno);
    this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
}
Agora é necessário modificarmos o método de busca para que ela seja feita não mais no HashSet e sim no dicionário. Vamos navegar ao método BuscaMatriculado() e trocar seu corpo por outro tipo de busca:

internal Aluno BuscaMatriculado(int numeroMatricula)
{
    return this.dicionarioAlunos[numeroMatricula];
}
Indo a Program.cs, rodaremos a aplicação e obteremos o mesmo resultado anterior, com a aluna Ana Losnak. A troca foi efetuada com sucesso! No entanto, pode ser que busquemos uma chave inexistente, como 5618, por exemplo. O que ocorrerá neste caso?

//quem é o aluno 5618?
Console.WriteLine("Quem é o aluno 5618?");
Console.WriteLine(csharpColecoes.BuscaMatriculado(5618));
Ao rodarmos a aplicação, ocorre um erro que diz: a chave fornecida não estava presente no dicionário. Talvez tenhamos que tenhamos que tratar isto para que o erro não apareça ao usuário final. Poderemos retornar um valor nulo, por exemplo. Para isso, modificaremos o método BuscaMatriculado(), para o qual iremos utilizando a tecla F12.

Em vez de utilizarmos a sintaxe dos colchetes, chamaremos outro método em dicionarioAlunos para "tentarmos a obtenção do valor" (TryGetValue), passando a mesma chave que estávamos buscando anteriormente, juntamente com um parâmetro de saída, retornando exatamente o valor que buscamos.

Como aluno ainda não existe no escopo deste método, precisaremos declará-lo, e ele será preenchido pelo TryGetValue caso seja encontrado no dicionário, neste caso, retornando:

internal Aluno BuscaMatriculado(int numeroMatricula)
{
    Aluno aluno = null;
    this.dicionarioAlunos.TryGetValue(numeroMatricula, out aluno);
    return aluno;
}
Feita esta implementação, voltaremos a Program.cs e rodaremos a aplicação. Veremos que a pergunta "Quem é o aluno 5618" é feita, seguida de uma linha em branco, ou seja, concatenando-se nulo.
         */
        #endregion

        #endregion

        #region 03 - Sets, HashCode, Equals

        #region 03 - Aula 10 - Para saber mais
        /*
         * Conjuntos Ordenados com o SortedSet
Em muitas aplicações além da busca rápida, também precisamos manter a ordenação dos elementos de um conjunto. Nesse tipo de aplicação, podemos utilizar uma nova classe do C# chamada SortedSet.

O SortedSet funciona de forma similar ao HashSet, utilizamos o Add para adicionar um elemento, o Remove para remover itens, o Count para perguntar quantos elementos estão armazenados e Contains para verificar se um determinado elemento está no conjunto. A diferença é que no HashSet os elementos são espalhados em categorias e por isso não sabemos qual é a ordem da iteração, já o SortedSet guarda os elementos na ordem crescente.

PARA SABER MAIS: - Conjuntos Ordenados com o SortedSet - Caelum Ensino e Inovação
https://www.caelum.com.br/apostila-csharp-orientacao-objetos/lidando-com-conjuntos/#20-2-conjuntos-ordenados-com-o-sortedset
         */
        #endregion

        #region 03 - Aula 07 - Mão na Massa: O Poder dos Sets
        /*      
         *Chegou a hora de botar a mão na massa e começar a trabalhar com HashSet, a classe do .NET Framework que representa conjuntos.



Um HashSet é uma coleção que representa um conjunto de valores. Falando assim, ele se parece com uma lista. Porém, existem diferenças claras:

Um conjunto não aceita duplicação de itens. Por outro lado, uma lista permite que o mesmo valor seja armazenado em várias posições diferentes.
Um conjunto não é uma sequência. Diferente da classe List, onde adicionamos elementos ao final da coleção, os elementos do conjunto HashSet não são mantidos em nenhuma ordem específica.
Declarando um HashSet
Vamos iniciar criando um projeto Console Application novo. Nesse projeto iremos criar um conjunto de alunos.

Um conjunto HashSet é uma classe genérica, que declararmos passando o tipo dos elementos:

HashSet<string> alunos = new HashSet<string>();
Como HashSet é uma classe que implementa ISet, podemos fazer uso do polimorfismo declarando alunos como ISet:

ISet<string> alunos = new HashSet<string>();
Adicionando itens ao conjunto


Aí sim, começamos a adicionar elementos a esse conjunto. Vamos alimentar essa coleção com três alunos, usando método Add:

alunos.Add("Vanessa Tonini");
alunos.Add("Ana Losnak");
alunos.Add("Rafael Nercessian");
Imprimindo itens do conjunto
Para imprimir coleções, já vimos que o método Console.WriteLine não pode ser usado sobre a variável das coleções array ou List<T>. O mesmo acontece com HashSet:

Console.WriteLine(alunos);
Nesse caso, vamos fazer algo diferente: gerando uma string concatenando todos os alunos separados por vírgula. Felizmente, a classe string possui o método que facilita esse trabalho:

string.Join(",", alunos)
Note que Join toma como primeiro parâmetro uma string com o separador, e como segundo argumento a coleção que queremos imprimir. Essa coleção pode tanto ser um HashSet, um array, um List<T> ou qualquer outra classe que implementa a interface IEnumerable<T>.

Assim, usamos string.Join dentro do Console.WriteLine e conseguimos ver nossa lista separada por vírgulas no console:

Console.WriteLine(string.Join(",", alunos));
Diferenças entre HashSet<T> e List<T>
Já dissemos as diferenças que existem entre HashSet<T> e List<T>, mas é bom fazer um teste para isso ficar bem evidente.

Primeiro, vamos adicionar outros três alunos:

alunos.Add("Priscila Stuani");
alunos.Add("Rafael Rollo");
alunos.Add("Fabio Gushiken");
E em seguida vamos imprimir novamented nossa lista:

Console.WriteLine(string.Join(",", alunos));
Agora observe atentamente o resultado que esse código acima gerou:

Vanessa Tonini,Ana Losnak,Rafael Nercessian,Priscila Stuani,Rafael Rollo,Fabio Gushiken


Agora vamos fazer algo interessante! Removendo um aluno e inserindo outro:

alunos.Remove("Ana Losnak");
alunos.Add("Marcelo Oliveira");
Até aqui nada de especial, certo? Tanto o método Remove quanto Add existem em outras coleções, como List<T>. Mas a diferença entre o HashSet fica mais evidente quando imprimimos o nosso conjunto novamente:

Console.WriteLine(string.Join(",", alunos));
Executando de novo, temos:

Vanessa Tonini,Marcelo Oliveira,Rafael Nercessian,Priscila Stuani,Rafael Rollo,Fabio Gushiken
Note a posição de Marcelo Oliveira acima!



Quando adicionamos um item numa List<T>, ele vai para o "final" da coleção. Mas Mas veja que agora o aluno Marcelo Oliveira está ocupando a segunda posição, no mesmo lugar onde havia Ana Losnak! Então conseguimos provar que um elemento num HashSet<T> não ocupa uma ordem específica!

Duplicidade em um HashSet<T>
Já dissemos que um conjunto em .NET Framework não aceita duplicidade. Vamos comprovar isso?

Para isso, adicionamos novamente um valor que já existe. Vamos incluir na coleção o aluno Fabio Gushiken:

alunos.Add("Fabio Gushiken");
O que será que acontece se executarmos o código agora? Será que dá um erro?

Vamos lá! Rodando o programa, temos:

Vanessa Tonini,Marcelo Oliveira,Rafael Nercessian,Priscila Stuani,Rafael Rollo,Fabio Gushiken
Veja só, sem erros! Mas algo interessante aconteceu. Ou melhor, não aconteceu. O aluno Fabio Gushiken não foi adicionado novamente! Ou seja, quando adicionamos um valor duplicado em um conjunto, essa operação não gera erro, porém um novo item com o mesmo valor não é inserido!

Ordenando um conjunto
Se os itens de um conjunto não são mantidos em uma ordem específica, mas será que podemos ordená-lo programaticamente?

Vamos lá. Escreveremos uma nova linha de código:

alunos.Sort();
Ao executarmos, tomamos um erro de compilação! A interface ISet<T> não suporta o método Sort()! Mas não se desespere! Podemos contornar esse problema trabalhando com uma cópia do nosso conjunto. Vamos copiar o HashSet<T> alunos para uma lista. E a melhor maneira de fazer essa cópia é criar uma instância de List<T> passando no construtor da lista o nosso conjunto:

List<string> alunosEmLista = new List<string>(alunos);
Note que uma lista pode ser criada dessa maneira não somente a partir de um conjunto, mas a partir de qualquer coleção que implementa a interface IEnumerable<T>!

Agora sim, podemos aproveitar o poder e flexibilidade de uma lista e efetuar a ordenação:

alunosEmLista.Sort();
E, claro, imprimir a lista com o resultado ordenado:

Console.WriteLine(string.Join(",", alunosEmLista));
Rodando o programa novamente...

Fabio Gushiken,Marcelo Oliveira,Priscila Stuani,Rafael Nercessian,Rafael Rollo,Vanessa Tonini


Sucesso!

Colocando Set no Modelo
Vimos acima as operações básica com conjuntos. Mas como trabalhamos com HashSet<string>, existem conceitos mais avançados de conjuntos que não pudemos mostrar ainda.

Portanto, vamos começar a introduzir conjuntos no modelo de classes que vimos nas aulas anteriores.

Então, vamos criar um novo projeto Console Application e vamos pôr a mão na massa!

Primeiro, vamos declarar o curso, definindo seu nome e o nome do instrutor:

Curso csharpColecoes = new Curso("C# Colecoes", "Marcelo Oliveira");
E em seguida adicionar 3 aulas a esse curso:

csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
csharpColecoes.Adiciona(new Aula("Criando uma Aula", 20));
csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));
Adicionando alunos ao curso
Agora chegou a vez de adicionarmos os alunos ao nosso curso. Só que em vez de usarmos strings, podemos também definir número de matrícula. E para manter duas informações para cada aluno, nada melhor do que criar uma classe para esse propósito. Crie uma classe Aluno com Nome e NumeroMatricula:

class Aluno
{
    private string nome;
    private int numeroMatricula;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int NumeroMatricula
    {
        get { return numeroMatricula; }
        set { numeroMatricula = value; }
    }
}
E para preencher essas informações, é bom definir um construtor passando o nome e o número da matrícula:

public Aluno(string nome, int numeroMatricula)
{
    this.nome = nome;
    this.numeroMatricula = numeroMatricula;
}
Agora sim, podemos começar a trabalhar com alunos no curso.

Voltando ao Program.cs, vamos instanciar três alunos:

Aluno a1 = new Aluno("Vanessa Tonini", 34672);
Aluno a2 = new Aluno("Ana Losnak", 5617);
Aluno a3 = new Aluno("Rafael Nercessian", 17645);
E como vamos adicionar esses alunos ao curso? Basta criar um método novo, e em seguida vamos ver o que podemos fazer!

csharpColecoes.Matricula(a1);
csharpColecoes.Matricula(a2);
csharpColecoes.Matricula(a3);
Opa! Não existe o método Matricula! O que fazer? Calma, basta teclar CTRL + PONTO sobre o nome Matricula que o Visual Studio cria o método para nós!

internal void Matricula(Aluno a1)
{

}
Lembre-se de renomear o parâmetro para aluno:

internal void Matricula(Aluno aluno)
{

}
Nesse ponto haverá o código para adicionar um aluno ao curso. Mas um curso não possui nenhuma coleção de alunos. Vamos criar essa coleção agora, definindo no escopo da classe Curso um campo privado que será uma coleção do tipo HashSet<T>:

private ISet<Aluno> alunos = new HashSet<Aluno>();
Pronto! Agora basta adicionar o aluno que está sendo matriculado à coleção:

internal void Matricula(Aluno aluno)
{
    alunos.Add(aluno);
}
Imprimindo os alunos
Voltando ao método Main da classe Program, vamos fazer um laço pra varrer os alunos do curso e imprimi-los:

Console.WriteLine("Imprimindo os alunos matriculados");
foreach (var aluno in csharpColecoes.Alunos)
{

}
Mas note que não existe uma propriedade pública Alunos! Tudo bem, basta criar na classe Curso:

public ISet<Aluno> Alunos
{
    get
    {
        return alunos;
    }
}
Mas note que essa propriedade expõe os alunos da classe Curso, e nada impede que um código externo modifique a coleção sem permissões. Vamos utilizar a mesma técnica de proteção da coleção Aulas que vimos na aula passada, retornando uma instância de ReadOnlyCollection, contendo a cópia dos alunos:

public IList<Aluno> Alunos
{
    get
    {
        return new ReadOnlyCollection<Aluno>(alunos.ToList());
    }
}
Agora sim vamos imprimir os alunos em Program.cs:

foreach (var aluno in csharpColecoes.Alunos)
{
    Console.WriteLine(aluno);
}
Opa! A linha Console.WriteLine(aluno); não imprime os dados do aluno como desejamos. Vamos então implementar o método override ToString():

public override string ToString()
{
    return $"[Nome: {nome}, Matrícula: {numeroMatricula}]";
}
Verificando se um item existe no HashSet
Uma das especialidades de um HashSet é realizar operações de conjuntos matemáticos, como por exemplo quando queremos saber se item existe no HashSet. Vamos criar o método EstaMatriculado para fazer essa verificação:

Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?");
Console.WriteLine(csharpColecoes.EstaMatriculado(a1));
E implementamos o novo método EstaMatriculado na classe Curso:

public bool EstaMatriculado(Aluno aluno)
{
    return alunos.Contains(aluno);
}
Nada demais até aqui, certo? O método Contains apenas retorna um boolean indicando se o elemento está ou não no conjunto.

Comparando instâncias diferentes, mas com mesmos valores
Mas e se declaramos uma nova instância de Aluno, porém com informações idênticas a de um aluno preexistente?

Aluno tonini = new Aluno("Vanessa Tonini", 34672);
Veja: A aluna com os dados acima já existe, e já foi adicionada uma vez ao HashSet.

Console.WriteLine("Tonini está matriculada? " + csharpColecoes.EstaMatriculado(tonini));
Opa! Desta vez, EstaMatriculado retornou false! Nossa aluna está ou não matriculada, afinal?

Algo está estranho... vamos fazer outra verificação:

Console.WriteLine("a1 é equals a Tonini?");
Console.WriteLine(a1.Equals(tonini));
São diferentes! É por isso que o método Contains que vimos lá na classe Curso está retornando false! Isso porque Contains verifica os elementos comparando as instâncias em si, e não valores que elas carregam.

O que fazer então, se queremos considerar instâncias com mesmos valores como equivalentes?

Precisamos então implementar Equals(). Vamos implementar esse método fazendo um override na classe Aluno:

public override bool Equals(object obj)
{
    return base.Equals(obj);
}
Note que o código acima é usado pela classe Object para comparar instâncias e não valores.

O que precisamos fazer é adaptar esse método para comparar valores em vez de instâncias.

public override bool Equals(object obj)
{
    return this.nome.Equals(outro.nome);
}
Porém, temos que proteger o método para os casos em que comparamos a instância com valor null, caso contrários tomaremos uma exceção:

public override bool Equals(object obj)
{
    Aluno outro = obj as Aluno;

    if (outro == null)
    {
        return false;
    }

    return this.nome.Equals(outro.nome);
}
O método GetHashCode
Mas espere! Implementar o Equals é só parte da história! Sempre que implementamos Equals precisamos implementar o código de dispersão, ou código de espalhamento!

Vamos à explicação: a coleção HashSet usa uma tabela de espalhamento para realizar mais rapidamente suas buscas. Imagine que cada vez que você adiciona algo dentro do seu Set para espalhar os objetos, um número mágico é gerado e todos os objetos que o tenham são agrupados. E ao buscar, em vez de comparar o objeto com todos os outros objetos contidos dentro do HashSet (isso daria muitas comparações), ele gera novamente o mesmo número mágico, e compara apenas com aqueles que também tiveram como resultado esse número. Ou seja, ele compara apenas dentro do grupo de semelhança. No caso da matricula não reconhecida, o aluno a1 estava num grupo diferente de tonini, e por isso o método Contains não conseguia encontrá-lo.

Como é gerado esse número mágico? Utilizando o método GetHashCode, por isso precisamos sobrescrevê-lo, mudando-o para quando criarmos um objeto Aluno com o mesmo nome, que esses objetos gerem o mesmo GetHashCode e portanto, fiquem no mesmo grupo. Podemos por exemplo pegar o primeiro caractere do nome. Dessa maneira, estaremos dividindo os grupos em grupos de alunos que começam com A, B, C, D, ..., e Vanessa Tonini tanto em a1 quanto em tonini estarão no grupo V:

public override int GetHashCode()
{
    return this.nome[0];
}
Testando, vemos que funciona! Mas temos outro probleminha... O espalhamento é feito para que se tenha o menor número possível de objetos dentro de um grupo, e separando alfabeticamente como estamos fazendo, não é a maneira mais eficiente. Se abrirmos a classe String do C#, veremos que ela tem o método GetHashCode implementado, e ele já faz uma conta bem difícil, para que haja o melhor espalhamento e assim, a busca seja bastante eficiente.



Então, podemos fazer com que o nosso GetHashCode devolva o hash da String nome:

public override int GetHashCode()
{
    return this.nome.GetHashCode();
}
Se rodarmos o código novamente, obteremos true no método Equals. Considere a seguinte regra: caso você sobrescreva o método Equals, obrigatoriamente deverá sobrescrever o método GetHashCode.





E assim fechamos nosso capítulo sobre HashSet. Nos vemos em breve, quando apresentaremos nossa nova coleção: os dicionários. Até à próxima!      
         */
        #endregion

        #region 03 - Aula 04 - Equals e HashCode
        /*
         * Continuando com os conjuntos, vamos verificar se o aluno está matriculado no curso fazendo esta pergunta ao console e acrescentando o nome do aluno entre chaves ("{}"), não esquecendo do sinal $ para permitir a interpolação, após o qual rodaremos a aplicação.

//imprimir: "O aluno a1 está matriculado?"
Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?");
Obteremos a seguinte impressão:

Imprimindo os alunos matriculados
[Aluno: Vanessa Tonini, matricula: 34672]
[Aluno: Ana Losnak, matricula: 5617]
[Aluno: Rafael Nercessian, matricula: 17645]
O aluno a1 Vanessa Tonini está matriculado?
Responderemos a pergunta criando um método booleano ao fim da nossa classe Curso, o qual nos retornará "verdadeiro" ou "falso" e receberá um aluno:

public bool EstaMatriculado(Aluno aluno)
{
    return alunos.Contains(aluno);
}
Voltando a Program.cs, acrescentaremos as seguintes linhas de código:

//Criar um método EstaMatriculado
Console.WriteLine(csharpColecoes.EstaMatriculado(a1));
Vamos rodar a aplicação. O resultado retornado é "verdadeiro" ("true"):

O aluno a1 Vanessa Tonini está matriculado?
True
Para verificarmos se outra instância contendo as mesmas informações de a1 pertence à coleção de alunos, instanciaremos um aluno preexistente.

//vamos instanciar uma aluna (Vanessa Tonini)
Aluno tonini = new Aluno("Vanessa Tonini", 34672);
//e verificar se Tonini está matriculada
Console.WriteLine("Tonini está matriculada? " + csharpColecoes.EstaMatriculado(tonini));
Vamos chamar o método rodando o código mais uma vez. Obteremos:

Tonini está matriculada? False
Vejam que interessante: a segunda instância não é reconhecida como sendo igual à primeira, previamente adicionada à coleção. Desta vez, perguntaremos ao .NET Framework se a1 é igual a Tonini, ou seja, se as duas instâncias são iguais:

//mas a1 == a Tonini?
Console.WriteLine("a1 == a Tonini?");
Console.WriteLine(a1 == tonini);
Ao rodarmos a aplicação agora, teremos:

a1 == a Tonini?
False
O operador de igualdade está retornando "false" por se tratar de instâncias distintas. Se quisermos que o programa reconheça que as duas instâncias na verdade são a mesma, teremos que utilizar um método. Mas antes disso chamaremos o método Equals(), que fará a comparação entre as instâncias.

//o que ocorreu? a1 é equals a Tonini?
Console.WriteLine("a1 é equals a Tonini?");
Console.WriteLine(a1.Equals(tonini));
Rodando com "Ctrl + F5", teremos:

a1 é equals a Tonini?
False
Então, é necessário sobrescrevermos o método Equals() do objeto que se encontra acima na hierarquia da classe Aluno, em que digitaremos:

public override bool Equals(object obj)
{
    return base.Equals(obj);
}
Deste modo, as instâncias são comparadas, sendo que o que queremos é verificar se os nomes são iguais. Existem outras estratégias, como combinar nome e matrícula, nome e data de nascimento, e outros, mas por ora optaremos pelo código abaixo:

public override bool Equals(object obj)
{
    return this.nome.Equals(obj.nome);
}
No entanto, obj é obviamente um objeto, e não possui a propriedade nome e, sendo assim, o programa aponta erro. Precisaremos fazer uma conversão para realizar esta comparação, declarando Aluno, que chamaremos de outro a ser um obj convertido por meio de um cast.

Pode acontecer de compararmos um objeto com um valor nulo e, então, a função acarretará em erro. Para garantir que o método seja protegido contra isto, verificaremos se o objeto obj é nulo ou não.

public override bool Equals(object obj)
{
    Aluno outro = obj as Aluno;

    if (outro == null)
    {
        return false;
    }

    return this.nome.Equals(outro.nome);
}
Voltando a Program.cs e rodando o código com "Ctrl + F5", leremos o seguinte retorno:

a1 é equals a Tonini?
True
Conseguimos superar a comparação default .NET Framework simplesmente implementando o Equals(). Porém, cuidado: sempre que o implementamos, precisaremos fazer o mesmo com o hash code.

No início da classe Aluno, veremos como observação, um alerta que indica que esta classe sobrescreve o Equals() mas não o GetHashCode. O que isto significa?

Trata-se de um código de dispersão, ou espalhamento. A imagem abaixo representa o nosso conjunto de alunos, que são convertidos internamente no HashSet para códigos. Estes cairão em uma tabela de dispersão, também conhecida por HashTable, responsável por informar as "caixinhas" em que estes conjuntos de alunos cairão.

esquema de tabela de dispersão, com os valores no centro, as chaves (nomes dos alunos à esquerda) e os valores (nomes e matrículas) à direita

Quer dizer que quanto maior a dispersão, ou mais espalhado forem as caixinhas, maior será a eficiência no algoritmo de busca para posterior comparação ou verificação de um elemento em um objeto. Como podemos ver na imagem, todos os alunos caíram em caixas diferentes, com exceção do Rafael Rollo e do Rafael Nercessian, que caíram em 152 (o HashCode gerado, o tal do código de dispersão), em que ocorreu uma colisão de códigos.

Uma colisão indica que dois ou mais elementos estão caindo no mesmo grupo. Nisso, verifica-se se o elemento está realmente contido naquela caixa e, paralelamente, todos os seus elementos são varridos. Ou seja, para verificar se o Rafael Nercessian está contido em uma caixa específica, por exemplo, passamos primeiro pelo Rafael Rollo. É como se uma "segunda etapa" tivesse acontecido.

Poderíamos ter muitos elementos em uma única caixa, deixando nosso código menos eficiente. Então, via de regra, ao implementarmos o método Equals(), fazemos o mesmo com o GetHashCode para que a dispersão aconteça corretamente. Reforçando também que a rapidez de busca depente do código de dispersão.

Para implementarmos este código de dispersão (GetHashCode), utilizaremos o override para sobrescrita. Como boa prática, seguiremos o mesmo conceito do Equals(), que compara nome com nome. Em Alunos.cs:

public override int GetHashCode()
{
    return this.nome.GetHashCode();
}
Futuramente trabalharemos com dicionários, também beneficiados por este código de dispersão.

Outra informação importante é que dois objetos iguais possuem o mesmo hash code, porém o inverso nem sempre é verdadeiro, ou seja, dois objetos com mesmo hash code não são necessariamente iguais.
         */
        #endregion

        #endregion

    }
}
