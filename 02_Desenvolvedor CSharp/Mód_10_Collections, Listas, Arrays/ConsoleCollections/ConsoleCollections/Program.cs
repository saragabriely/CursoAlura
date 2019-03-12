using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    partial class Program
    {
        static void Main(string[] args)
        {
            #region 03 - Conjuntos

            // Declarando o curso
            Curso csharpColecoes = new Curso("C# Coleções", "Marcelo Oliveira");

            // Adicionar 3 aulas a esse curso
            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21));
            csharpColecoes.Adiciona(new Aula("Criando uma aula",       20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            // Um aluno também tem matricula - Criar classe

            // Instanciando 3 alunos com suas matriculas
            Aluno a1 = new Aluno("Vanessa Tonini",    34672);
            Aluno a2 = new Aluno("Ana Losnak",        5617);
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



            //--------------------------------------------
            Console.ReadLine();
        }

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

        

    }
}
