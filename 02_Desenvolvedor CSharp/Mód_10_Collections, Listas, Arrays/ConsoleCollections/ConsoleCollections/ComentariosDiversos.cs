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

        #region 05 - LinkedList



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
