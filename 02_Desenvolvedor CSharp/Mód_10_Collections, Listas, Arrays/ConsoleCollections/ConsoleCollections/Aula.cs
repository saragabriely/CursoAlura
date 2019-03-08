
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    public class Aula : IComparable
    {
        private string titulo;
        private int tempo;

        public Aula(string titulo, int tempo)
        {
            this.titulo = titulo;
            this.tempo = tempo;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public int Tempo { get => tempo; set => tempo = value; }

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
}
