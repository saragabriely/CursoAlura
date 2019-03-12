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

        #region 04



        #endregion

        #region 03

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
