﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    partial class Program
    {



        #region 05 - 04 - Stack/Pilha

        #region Stack/Pilha
        private static void Stack_Pilha()
        {
            // ... implementaremos a solução de um problema de navegação 
            // de browser, ou navegador Web

            // PILHA!

            // O PRIMEIRO QUE ENTRA É O ÚLTIMO QUE SAI!

            var navegador = new Navegador();

            navegador.NavegarPara("google.com");

            navegador.NavegarPara("caelum.com.br");

            navegador.NavegarPara("alura.com.br");

            Console.WriteLine("----------------------------------");

            navegador.Anterior();   // google
            navegador.Anterior();   // caelum 
            navegador.Anterior();   // vazia

            Console.WriteLine("----------------------------------");

            navegador.Proximo();

        }
        #endregion

        #region Navegador
        internal class Navegador
        {
            // Anterior: salvar a página atual que será substituida
            // criar uma coleção (pilha/STACK) para isso

            private readonly Stack<string> historicoAnterior = new Stack<string>();
            private readonly Stack<string> historicoProximo = new Stack<string>();

            private string atual = "vazia";

            public Navegador()
            {
                Console.WriteLine($"Página atual: {atual}");
            }

            internal void Anterior()
            {
                if (historicoAnterior.Any()) // Verifica se tem algum valor
                {
                    historicoProximo.Push(atual); // alimentando o historico Proximo

                    // POP: Obter o valor 
                    atual = historicoAnterior.Pop(); // Retorna uma string
                    Console.WriteLine($"Página atual: {atual}");
                }

                // Para acessar a página anterior, a página atual irá assumir 
                // o valor da página anterior

            }

            internal void NavegarPara(string url)
            {
                // PUSH: Colocar em pilha
                historicoAnterior.Push(atual); // salvar a página que será trocada

                atual = url;

                Console.WriteLine($"Página atual: {atual}");
            }

            internal void Proximo()
            {
                if (historicoProximo.Any())
                {
                    historicoAnterior.Push(atual); // alimentando o histórico anterior

                    atual = historicoProximo.Pop();

                    Console.WriteLine($"Página atual: {atual}");

                }
            }
        }
        #endregion

        #endregion

        #region 05 - 03 - LinkedList
        private static void LinkedList_()
        {
            // LINKEDLIST

            // Lista de frutas
            var frutas = new List<string>()
            {
                "abacate", "banana", "caqui", "damasco", "figo"
            };

            // Imprimindo
            foreach (var fruta in frutas)
            {
                Console.WriteLine(fruta);
            }

            // As frutas são armazenadas no array interno da lista
            // Adicionar um valor no final da lista, é rápido!

            // Inserir um elemento no meio da lista: é mais complicado.
            // Pois os elementos têm que ser deslocados para darem espaço ao novo
            // elemento.

            // Quanto maior a lista, mais ineficiente é a inserção e remoção
            // de elementos no meio dela!

            // Lista/coleção mais adequada

            // LISTA LIGADA - 
            // Os elementos da lista ligada não preciam estar em sequencia na´
            // memória para representar.

            // - Elementos não precisam estar em uma sequencia em memória;
            // - Cada elemento sabe quem é o anterior e o próximo;
            // - Cada elemento é um nó que contém um valor.

            // Instanciando uma nova lista ligada: dias da semana
            LinkedList<string> dias = new LinkedList<string>();

            // Adicionando um dia qualquer: "quarta"
            var d4 = dias.AddFirst("quarta");

            // "quarta" é o primeiro elemento da lista ligada
            // cada elemento é um nó: LinkedListNode<T> e não uma string(pois 
            // não possui informações de ponteiros)

            // Valor da variável d4 ("quarta")
            Console.WriteLine($"\n d4.Value: {d4.Value}");

            // O linkedList não tem o método Add, porém tem 4 opções:
            // 1. AddFirst - Como primeiro nó;
            // 2. AddLast - Ultimo 
            // 3. AddBefore - Antes de um nó conhecido
            // 4. AddAfter - Depois de um nó conhecido

            // Vamos adicionar 'segunda', antes de quarta
            var d2 = dias.AddBefore(d4, "segunda"); // d2 <-> d4

            // Obter o próximo nó: d2.Next
            // Obter o nó anterior: d4.Previous

            // Adicionar 'terça' depois da segunda
            var d3 = dias.AddAfter(d2, "terça");    // d2 <-> d3 <-> d4

            // Adicionar 'sexta' depois de 'quarta'
            var d6 = dias.AddAfter(d4, "sexta");   // d2 <-> d3 <-> d4 <-> d6

            // Adicionar 'sabado' depois de 'sexta'
            var d7 = dias.AddAfter(d6, "sábado");   // d2 <> d3 <> d4 <> d6 <> d7

            // Adicionar 'quinta' antes de 'sexta'
            var d5 = dias.AddBefore(d6, "quinta");
            // d2 <> d3 <> d4 <> d5 <> d6 <> d7

            // Adicionar 'domingo' antes da 'segunda'
            var d1 = dias.AddBefore(d2, "domingo");
            // d1 <> d2 <> d3 <> d4 <> d5 <> d6 <> d7

            Console.WriteLine("");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

            // LinkedList não dá suporte através de indice! dias[0]
            // Por isso podemos fazer um laço foreach mas não um for!

            // Para encontrar algum elemento, deverá ser usado o método FIND!
            var quarta = dias.Find("quarta");

            // Em caso de muitas buscas, o LinkedList não é eficiente.

            // Para removermos um elemento, podemos tanto 
            // remover pelo valor quanto pela referência do LinkedListNode
            // dias.Remove("quarta") ou dias.Remove(d4);
            dias.Remove("quarta");

            Console.WriteLine("");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }

        }
        #endregion

        #region 03 e 04 - Conjuntos e Dicionários
        static void Conjuntos_E_Dicionarios()
        {
            #region 03 - Conjuntos

            // Declarando o curso
            Curso csharpColecoes = new Curso("C# Coleções", "Marcelo Oliveira");

            // Adicionar 3 aulas a esse curso
            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adiciona(new Aula("Criando uma aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            // Um aluno também tem matricula - Criar classe

            // Instanciando 3 alunos com suas matriculas
            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            // Matriculando os alunos no curso - Criando um método
            csharpColecoes.Matricula(a1);
            csharpColecoes.Matricula(a2);
            csharpColecoes.Matricula(a3);
            //--------------------------------------------

            // Imprimindo os alunos matriculados
            Console.WriteLine("Imprimindo os alunos matriculados: \n");

            foreach (var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno);
            }

            // Imprimir: "O aluno a1 está matriculado?"

            Console.WriteLine($"\n O aluno a1 {a1.Nome} está matriculado? ");

            // Criar método EstaMatriculado
            Console.WriteLine(csharpColecoes.EstaMatriculado(a1));

            // Vamos instanciar uma aluna (Vanessa Tonini)
            Aluno tonini = new Aluno("Vanessa Tonini", 34672);

            // Verificar se Tonini está matriculada ou não
            Console.WriteLine($"\n Tonini está matriculada? " +
                $"{csharpColecoes.EstaMatriculado(tonini)}"); // Retorna false!

            // Verificar se a1 é igual a tonini
            Console.WriteLine($"a1 == a Tonini?");
            Console.WriteLine(a1 == tonini);            // Retorna false!

            // O que ocorreu? a1 é equals a Tonini
            Console.WriteLine("\n 'a1' é equals a Tonini?");
            Console.WriteLine(a1.Equals(tonini));
            // Continua dando como false! Logo, será necessário sobreescrever o 
            // método do object (que está acima da hierarquia da classe aluno).
            // São diferentes! Precisamos então implementar o método Equals()
            #endregion

            //---------------------------------------------------------------
            //---------------------------------------------------------------

            // 04 - Aula 01 - Introdução a dicionários

            // Limpando o console
            Console.Clear();

            // Já temos a verificação de alunos matriculados;
            // Agora a busca será feita pelo número de matricula

            // Pergunta: Quem é o aluno com a matricula 5617?
            Console.WriteLine("Quem é o aluno com a matricula 5617?");

            // Implementando Curso.BuscaMatriculado
            Aluno aluno5617 = csharpColecoes.BuscaMatriculado(5617);

            // Imprimindo o aluno5617 encontrado
            Console.WriteLine($"aluno5617: {aluno5617}");
            // Funciona! Mas essa busca é eficiente?

            // Introduzindo uma nova coleção: Dicionário
            // Um dicionário permite associar uma chave (no caso, matricula) a
            // um valor (o aluno)

            // Implementar um dicionário de alunos em Curso

            // Pergunta: Quem é o aluno 5618?
            Console.WriteLine("\nQuem é o aluno 5618?");

            Console.WriteLine(csharpColecoes.BuscaMatriculado(5618));

            //-----------------------------------------------------------

            // Tentativa de adicionar um aluno com uma chave existente - ERRO
            Aluno fabio = new Aluno("Fabio Gushiken", 5617);

            //csharpColecoes.Matricula(fabio);

            // A CHAVE EM UM DICIONÁRIO É ÚNICA!

            // Substituir alunos
            csharpColecoes.SubstituiAluno(fabio);

            // verificar a substituição
            Console.WriteLine("\nQuem é o aluno 5617?");
            Console.WriteLine(csharpColecoes.BuscaMatriculado(5617));

            //-----------------------------------------------------------

        }
        #endregion

        #region Sets - 3 - Aula 01
        private static void PoderDosSets()
        {
            // * 3 - Aula 01 - Poder dos Sets

            // Sets = Conjuntos
            // 1 - Não permite duplicidade.
            // 2 - Os elementos não são mantidos em ordem alfabetica

            //Declarando set de alunos
            ISet<string> alunos = new HashSet<string>();

            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");

            // Imprimir
            Console.WriteLine(alunos); // erro
            Console.WriteLine(string.Join(", ", alunos));
            Console.WriteLine(""); // Pula linha

            // Qual a diferença para uma lista? 

            // Adicionando mais alunos
            alunos.Add("Priscila Stuani");
            alunos.Add("Rafael Rolo");
            alunos.Add("Fabio Gushiken");

            Console.WriteLine(string.Join(", ", alunos));
            Console.WriteLine(""); // Pula linha

            // E a ordem?

            // Removendo um aluno
            alunos.Remove("Ana Losnak");    // Ocupava a 2ª posição

            alunos.Add("Marcelo Oliveira"); // Ocupou a posição que era da Ana

            Console.WriteLine(string.Join(", ", alunos));
            Console.WriteLine(""); // Pula linha

            // O conjunto não garante a posição a ser ocupada pelo item adicionado

            //-------------------------------------------------
            // 1 - Não permite duplicidade - TESTE

            alunos.Add("Fabio Gushiken");

            Console.WriteLine(string.Join(", ", alunos));
            Console.WriteLine(""); // Pula linha

            // Ao tentar adicionar o mesmo elemento no conjunto, nada será feito!
            // Ou seja, não será adicionado outro aluno com o mesmo nome.

            //-------------------------------------------------

            #region Qual a vantagem do SET sobre a LISTA? 
            // O conjunto é mais rápido para buscar elementos!
            // Pois, diferente de uma lista, que é feita uma varredura em toda a 
            // lista para procurar o elemento desejado. Já com o Hashset, é 
            // utilizada a tabela de espalhamento, que ocupa mais memória que uma
            // lista, ela direciona mais rapidamente para o elemento buscado.
            #endregion

            #region Desempenho: HashSet X Lista : Escalabilidade X Memória
            // O Hashset possui uma grande escalabilidade, permite que em uma 
            // escala bem grande de elementos é possível ter uma boa performance.
            // Porém ocupa mais memória que uma lista
            #endregion

            //-------------------------------------------------

            // Ordenando
            // alunos.Sort();

            List<string> alunosEmLista = new List<string>(alunos);

            alunosEmLista.Sort();

            Console.WriteLine(string.Join(", ", alunosEmLista));
            Console.WriteLine(""); // Pula linha
        }

        #endregion

        #region ImprimirListaAulas
        // (List<Aula> aulas)
        private static void ImprimirListaAulas(IList<Aula> aulas)
        {
            Console.Clear();

            // Para cada aula em aulas, faça ...
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula); // Imprima no console
            }

            // Ao tentar imprimir dessa forma, sem declarar o ToString()
            // na classe Aula, sairá no console apenas:
            // ConsoleCollections.Program+Aula
            // Pois, essa classe herda da Object, o padrão de saída será
            // ConsoleCollections.Program+Aula!
        }
        #endregion

        #region Classe Aula
        /*
        class Aula : IComparable
        {
            private string titulo;
            private int    tempo;

            public Aula(string titulo, int tempo)
            {
                this.titulo = titulo;
                this.tempo  = tempo;
            }

            public string Titulo { get => titulo; set => titulo = value; }
            public int    Tempo  { get => tempo;  set => tempo  = value; }

            public int CompareTo(object obj)
            {
                // Convertendo o tipo Object para o tipo Aula
                Aula that = obj as Aula;
                
                // Comparação em ordem alfabética
                return this.titulo.CompareTo(that.titulo);
            }

            // Configuração da impressão dos objetos dessa classe
            public override string ToString()
            {
                return $"[titulo: {titulo},  tempo: {tempo} minutos]";
            }
        }
        */
        #endregion

        #region ImprimirLista()
        private static void ImprimirLista(List<string> aulas)
        {
            #region Outras formas de imprimir
            //foreach(var item in aulas)
            //{
            //    Console.WriteLine(item);
            //}
            // ou
            //for (int i = 0; i < aulas.Count; i++)
            //{
            //    Console.WriteLine(aulas[i]);
            //}
            // ou
            #endregion

            // O ForEach recebe um método anonimo (Action)
            // Para cada aula, será executado o que estiver dentro dos {}
            aulas.ForEach(aula => { Console.WriteLine(aula); });

        }
        #endregion

        #region Lista_2_Aula07()
        private static void Lista_2_Aula07()
        {
            // * 2 - Aula 05 - Somente Leitura

            Curso csharpColecoes = new Curso("C# Collections", "Marcelo Oliveira");

            // Adicionando aulas
            // csharpColecoes.Aulas.Add(new Aula("Trabalhando com listas", 21));
            csharpColecoes.Adiciona(new Aula("Trabalhando com listas", 21));

            #region Code Smell
            /* Code smell (mau cheiro no código ou algo do tipo)
             * 
             * Aulas está sendo acessado diretamente através do csharpColecoes
             * e está sendo adicionando elementos nela. Ou seja, estamos passando
             * por cima da responsabilidade da classe curso de manter seus objetos
             * e propriedades, e estamos manipulando a lista de aulas diretamente.
             * O correto seria chamar um método da classe curso para manipular
             * essa lista, que está exposta!             
             * 
             * Para evitar que uma propriedade fique exposta para manipulação externa,
             * é necessário encapsular essa funcionalidade de adicionar elemntos na 
             * lista. Será necessário bloquear a lista interna para que ela não possa
             * ser manipulada por uma classe externa.
             * 
             * * Remover o set da classe
             */
            #endregion

            ImprimirListaAulas(csharpColecoes.Aulas);
            //--------------------------------------------

            csharpColecoes.Adiciona(new Aula("Criando uma aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com coleções", 19));

            ImprimirListaAulas(csharpColecoes.Aulas);
            Console.WriteLine("");
            //--------------------------------------------

            // Ordenar a lista de aulas
            //csharpColecoes.Aulas.Sort();
            // A interface IList não dá suporte ao método de ordenaçao (sort).

            // Copiar a lista para outra lista
            List<Aula> aulasCopiadas = new List<Aula>(csharpColecoes.Aulas);
            // Dessa forma é possível ordenar a lista

            // Ordenar a copia
            aulasCopiadas.Sort();

            ImprimirListaAulas(aulasCopiadas);
            Console.WriteLine("");
            //--------------------------------------------

            // Totalizar o tempo do curso
            Console.WriteLine(csharpColecoes.TempoTotal);
            Console.WriteLine("");
            //--------------------------------------------

            // Imprimir detalhes do curso
            Console.WriteLine(csharpColecoes);

        }
        #endregion

        #region Listas de Objeto
        private static void Listas_2_Aula03()
        {
            // 02 - Aula 03 - Listas de Objetos
            //string aulaIntro     = "Introdução às Coleções";
            //string aulaModelando = "Modelando a Classe Aula";
            //string aulaSets      = "Trabalhando com conjuntos.";

            var aulaIntro = new Aula("Introdução às Coleções", 20);
            var aulaModelando = new Aula("Modelando a Classe Aula", 18);
            var aulaSets = new Aula("Trabalhando com conjuntos.", 16);


            List<Aula> aulas = new List<Aula>();

            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);

            // aulas.Add("Conclusão");
            // Não é possível adicionar a string dessa forma, pois a lista espera
            // um OBJETO do tipo AULA! Só é possível adicionar elementos que sejam
            // do mesmo tipo, ou classes derivadas/herdadas da classe Aula.

            ImprimirListaAulas(aulas);
            Console.WriteLine("");  // Pula linha

            // ordenando
            aulas.Sort();

            ImprimirListaAulas(aulas);
            Console.WriteLine("");  // Pula linha

            // Comparação de tempo
            aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));

            ImprimirListaAulas(aulas);
            Console.WriteLine("");  // Pula linha

        }
        #endregion

        #region Listas_2_Aula02
        private static void Lista_2_Aula02()
        {
            // 02 - Aula 01 - Introdução às Listas
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos.";

            //List<string> aulas = new List<string>()
            //{
            //    aulaIntro, aulaModelando, aulaSets
            //};

            // OU
            List<string> aulas = new List<string>();

            // Lista = Array dinamico! Aumenta e diminui de acordo com a necessidade

            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);


            ImprimirLista(aulas);

            Console.WriteLine(""); //-------------------------

            Console.WriteLine($"A primeira aula é: {aulas[0]}");
            Console.WriteLine($"A primeira aula é: {aulas.First()}");

            Console.WriteLine($"A última aula é: {aulas[aulas.Count - 1]}");
            Console.WriteLine($"A última aula é: {aulas.Last()}");

            Console.WriteLine(""); //-------------------------

            // Trocar o nome da primeira aula
            aulas[0] = "Trabalhando com listas";

            ImprimirLista(aulas);

            Console.WriteLine(""); //-------------------------

            // Procurar palavra na lista de aulas
            Console.WriteLine($"A primeira aula 'Trabalhando' é: " +
                $"{aulas.First(aula => aula.Contains("Trabalhando"))}");

            Console.WriteLine($"A última aula 'Trabalhando' é: " +
                $"{aulas.Last(aula => aula.Contains("Trabalhando"))}");

            // FirstOrDefault devolve o primeiro elemento ou um valor Default
            // Assim, tratando uma eventual excessão
            Console.WriteLine($"A primeira aula 'Conclusão' é: " +
                $"{aulas.FirstOrDefault(aula => aula.Contains("Conclusão"))}");

            Console.WriteLine(""); //-------------------------

            // Reverse
            aulas.Reverse();

            ImprimirLista(aulas);

            Console.WriteLine("");

            aulas.Reverse();

            ImprimirLista(aulas);

            Console.WriteLine(""); //-------------------------

            // RemoveAt - Remove posição especifica
            aulas.RemoveAt(aulas.Count - 1); // remove o último elemento da lista

            Console.WriteLine(""); //-------------------------

            aulas.Add("Conclusão");
            ImprimirLista(aulas);

            Console.WriteLine(""); //-------------------------

            // Ordenando

            aulas.Sort();
            ImprimirLista(aulas);

            Console.WriteLine(""); //-------------------------

            // Copia
            List<string> copia = aulas.GetRange(aulas.Count - 2, 2);
            // GetRange - Obter faixa de valores
            // Pegar os dois ultimos elementos da lista
            ImprimirLista(copia);

            Console.WriteLine(""); //-------------------------

            // "Clonar"
            List<string> clone = new List<string>(aulas);

            ImprimirLista(clone);

            Console.WriteLine(""); //-------------------------

            // Remover
            clone.RemoveRange(clone.Count - 2, 2);
            ImprimirLista(clone);
        }
        #endregion

        #region Arrays_Aula01
        private static void Arrays_Aula01()
        {
            // 01 - Aula 03 - Declarando e Populando Arrays
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos.";

            //string[] aulas = new string[]{  aulaIntro, aulaModelando, aulaSets };

            // Outra forma
            string[] aulas = new string[3];

            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;

            Imprimir(aulas);

            Console.WriteLine($"Primeiro elemento: {aulas[0]}");
            Console.WriteLine($"Último elemento: {aulas.Length - 1}"); // Ultimo elemento

            aulaIntro = "Teste";

            // Atribuindo o valor 'Teste' a 'aulaIntro', não mudará o que tem no
            // Array. E para realmente alterar o array, deverá ser feito da 
            // seguinte maneira: aula[0] = "Teste";

            Console.WriteLine("");

            aulas[0] = "Trabalhando com Arrays";

            Console.WriteLine($"Aula modelando está no indice: " +
                $"{Array.IndexOf(aulas, aulaModelando)}");

            Console.WriteLine($"Ultima ocorrencia de Aula modelando:" +
                $" {Array.LastIndexOf(aulas, aulaModelando)}");

            Console.WriteLine("");

            //--------------------------------------------

            // Revertendo a ordem do Array
            Array.Reverse(aulas);
            Imprimir(aulas);

            Console.WriteLine(""); //-----------------------------

            // Revertendo a ordem do Array - novamente
            Array.Reverse(aulas);
            Imprimir(aulas);

            Console.WriteLine(""); //-----------------------------

            //--------------------------------------------

            // Redimencionar / Diminuir o tamanho do Array
            Array.Resize(ref aulas, 2);
            Imprimir(aulas);

            Console.WriteLine(""); //-----------------------------

            // O Resize cria uma nova coleção com o tamanho de array passado,
            // copia os elementos do antigo array para o novo, e altera a referencia

            // Usando o RESIZE novamente e aumentando o tamanho para 3, 
            // é copiado o array criado (cópia do array antigo) e a 
            // posição vaga recebe null!

            Array.Resize(ref aulas, 3);
            Imprimir(aulas);

            Console.WriteLine(""); //-----------------------------

            // aulas[2] = "Conclusão"; // ou
            // Para acessar e popular a ultima posição do array
            aulas[aulas.Length - 1] = "Conclusão";

            Imprimir(aulas);

            Console.WriteLine(""); //-----------------------------

            // Ordenando em ordem alfabetica
            Array.Sort(aulas);
            Imprimir(aulas);

            Console.WriteLine(""); //-----------------------------

            // Criar um array cópia
            string[] copia = new string[2];

            // copiar as duas utlimas posições
            Array.Copy(aulas, 1, copia, 0, 2);
            Imprimir(copia);

            Console.WriteLine(""); //-----------------------------

            // Copiar todos os elementos
            string[] clone = aulas.Clone() as string[];
            Imprimir(clone);

            Console.WriteLine(""); //-----------------------------

            // Limpar o array
            Array.Clear(clone, 1, 2);
            Imprimir(clone);

            Console.WriteLine(""); //-----------------------------

            /* Utilização do array: 
                É importante lembrarmos que o array é um tipo muito básico de 
                coleção do .NET, então o utilizaremos em casos específicos, 
                como em transferências de arquivos, manipulação de buffer ou 
                imagens, em arquivos de baixo nível. Isso porque normalmente, 
                embora faça parte de várias coleções do .NET, o array não é tão 
                usado quanto outro tipo de coleção (como o List). Assim sendo, 
                se for usar um tipo de coleção, busque sempre ver se é possível 
                optar pela lista no lugar de um array, pois ela fornece métodos 
                muito mais convenientes do que um simples array
            */

        }
        #endregion

        #region Imprimir()
        private static void Imprimir(string[] aulas)
        {
            //foreach (var item in aulas)
            //{
            //    Console.WriteLine(item);
            //}

            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }
        }
        #endregion

    }
}
