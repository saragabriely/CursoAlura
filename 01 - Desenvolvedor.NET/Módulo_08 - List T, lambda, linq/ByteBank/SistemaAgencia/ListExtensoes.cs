using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgencia
{
    // public static - classe só pra extensões, quue não possue estado e não será instanciada
    public static class ListExtensoes
    {
        // Uma classe estática, só terá métodos estáticos

        // O 'THIS' mostra o argumento que será extendido
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        {
            // Varrer lista e ir adicionando um por um
            foreach (int item in itens) // não traz o indice
            {
                listaDeInteiros.Add(item);
            }
        }


    }
}
