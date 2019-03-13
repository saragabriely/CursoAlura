using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    public class Curso
    {

        // Implementando um dicionário de alunos
        private IDictionary<int, Aluno> dicionarioAlunos = 
            new Dictionary<int, Aluno>();

        // Alunos deve ser um ISet. Alunos deve retornar um ReadOnlyCollection
        private ISet<Aluno> alunos = new HashSet<Aluno>();

        // Propriedade que será lida pelo código externo (apenas leitura)
        public IList<Aluno> Alunos
        {
            get
            {
                return new ReadOnlyCollection<Aluno>(alunos.ToList());
            }
        }

        // A interface IList não dá suporte ao método de ordenaçao (sort).
        private IList<Aula> aulas;

        // O 'ReadOnlyCollection' implementa um IList, logo foi necessário alterar
        // o List para IList
        public IList<Aula> Aulas
        {
            //get { return aulas; } // Retornar uma lista para somente leitura
            get { return new ReadOnlyCollection<Aula>(aulas) ; }
            //set { aulas = value; } // - Removido para proteger a lista
        }
        
        private string nome;
        private string instrutor;

        public Curso(string nome, string instrutor)
        {
            this.nome      = nome;
            this.instrutor = instrutor;
            this.aulas     = new List<Aula>();
            // Declarando a lista dessa forma, será possível acessá-la
            // sem dar o erro de referencia nula.
        }

        internal void Matricula(Aluno aluno)
        {
            this.alunos.Add(aluno);

            // cada aluno adicionado, será adicionado também no dicionário de alunos
            this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
            // será necessário alterar o método de busca (de HashSet, para Dicionario)
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }


        public string Instrutor
        {
            get { return instrutor; }
            set { instrutor = value; }
        }

        internal void Adiciona(Aula aula)
        {
            this.aulas.Add(aula);
        }

        public int TempoTotal
        {
            get
            {
                //int total = 0;
                //foreach (var aula in aulas) { total += aula.Tempo; }
                //return total;
                // OU
                // LINQ = Language Integraded Query - Consulta integrada a linguagem

                return aulas.Sum(aula => aula.Tempo);
            }
        }

        public bool EstaMatriculado(Aluno aluno)
        {
            return alunos.Contains(aluno);
        }


        public override string ToString()
        {
            return $"Nome do curso: {nome} - Instrutor: {instrutor} - " +
                   $"Tempo total: {TempoTotal} - Aulas: {string.Join(",",aulas)}";
        }

        internal Aluno BuscaMatriculado(int numeroMatricula)
        {
            #region Corpo do método antes de usar o Dicionário de Alunos
            /* 
            // Varrer a lista de alunos, até encontrar aquele que possui a mtricula 
            // desejada

            foreach (var aluno in alunos)
            {
                if(aluno.NumeroMatricula == numeroMatricula)
                {
                    return aluno;
                }
            }
            // Exceção caso não econtre
            throw new Exception($"Matrícula não encontrada: {numeroMatricula}");
            */
            #endregion

            // Consulta através do dicionário
            //return this.dicionarioAlunos[numeroMatricula];

            // Tentar obter o valor - TryGetValue(entrada, parametro de saída)
            // Saída - Valor buscado

            Aluno aluno = null;

            this.dicionarioAlunos.TryGetValue(numeroMatricula, 
                out aluno);

            return aluno;
        }

        internal void SubstituiAluno(Aluno aluno)
        {
            this.dicionarioAlunos[aluno.NumeroMatricula] = aluno;
        }
    }
}
