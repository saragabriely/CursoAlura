using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    public class Aluno
    {
        private string nome;
        private int    numeroMatricula;

        public Aluno(string nome, int numeroMatricula)
        {
            this.nome            = nome;
            this.numeroMatricula = numeroMatricula;
        }

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

        public override string ToString()
        {
            return $"[Nome: {nome}, Matricula: {numeroMatricula}]";
        }

        public override bool Equals(object obj)
        {
            //return base.Equals(obj); // Neste caso são comapradas as intancias;
            // porém é necessário verificar se os nomes são iguais!

            Aluno outro = obj as Aluno; // convertendo (CAST) para aluno

            if(outro == null)
            {
                return false;
            }

            return this.nome.Equals(outro.nome);
        }
        // Ao implementar o Equals, é necessário implementar também outro método:
        // O GetHashCode! Que é um método de dispersão/espalhamento.
        // Ou seja
        // IMPORTANTE: Rapidez da busca depende do CÓDIGO DE DISPERSÃO!

        public override int GetHashCode()
        {
            // Por padrão, seguir o mesmo conceito do Equals

            return this.nome.GetHashCode();
        }

        // IMPORTANTE!
        // Dois objetos que são iguais possuem o mesmo hash code.
        // PORÉM, o contrário não é verdadeiro.
        // Dois objetos com mesmo hash code não são necessiariamente iguais.




    }
}
