using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    partial class Program
    {
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
