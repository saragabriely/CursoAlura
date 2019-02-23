using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgencia.Comparadores
{
    // Mostra como a lista será ordenada, sem depender de um objeto que 
    // implemente a interface IComparable
    
    public class ComparadorContaCorrentePorAgencia : IComparer<ContaCorrente>
    {
        // Segue a mesma lógica do IComparable, porém não compara a instancia,
        // E sim dois itens
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            // Caso x e y nulos
            // Caso duas referencias apontarem para o mesmo objeto, no caso nulo
            if (x == y) // duas referencias iguais, sendo nulas ou não
            {
                return 0;
            }

            // Verificar casos de referência nula
            if(x == null)
            {
                // x ficará no final
                return 1;
            }

            if(y == null)
            {
                return -1;
            }

            return x.Agencia.CompareTo(y.Agencia);

            // ---------------------------------------
            // A lógica/verificação abaixo é realizada com a linha de código acima
            // * Comparação da linguagem para o tipo inteiro
            /* 
            if(x.Agencia < y.Agencia)
            {
                return -1;  // x fica na frente de y
            }

            // Equivalentes
            if(x.Agencia == y.Agencia)
            {
                return 0;   // São equivalentes
            }

            // Caso o y tenha uma precedencia maior que o x, retorna positivo (1)
            return 1;
            */
        }
    }
}
