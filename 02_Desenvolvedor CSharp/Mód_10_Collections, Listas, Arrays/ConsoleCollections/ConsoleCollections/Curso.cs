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

        public override string ToString()
        {
            return $"Nome do curso: {nome} - Instrutor: {instrutor} - " +
                   $"Tempo total: {TempoTotal} - Aulas: {string.Join(",",aulas)}";
        }

    }
}
