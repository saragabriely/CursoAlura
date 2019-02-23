using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgencia.Extensoes
{
    // public static - classe só pra extensões, quue não possue estado e não será instanciada
    public static class ListExtensoes //<T> // T - tipo genérico
    {
        // Uma classe estática, só terá métodos estáticos

        // O 'THIS' mostra o argumento que será extendido
        // Método de extensão: o primeiro argumento terá o 'this'
        // Método genérico: AdicionarVarios<T>
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            // Varrer lista e ir adicionando um por um
            foreach (T item in itens) // não traz o indice
            {
                lista.Add(item);
            }
        }

        // Métod de extensão de string
        public static void TesteGenerico<T2>(this string texto)
        {

        }

        static void Teste()
        {
            List<int> idades = new List<int>();

            idades.Add(14);
            idades.Add(26);
            idades.Add(60);

            // ListExtensoes<string>.AdicionarVarios(idades, 2, 3, 4);

            // Quando o 'AdicionarVarios' é chamado com uma lista, 
            // não é necessário repetir o tipo, como  AdicionarVarios<int>
            idades.AdicionarVarios(56, 4545, 4565);

            string guilherme = "Guilerme";

            // neste caso, é necessário colocar o tipo, pois a declaração do 
            // mé
            guilherme.TesteGenerico<int>();



            List<string> nomes = new List<string>();

            nomes.Add("Guilherme");

            // ListExtensoes<string>.AdicionarVarios(nomes, "Lucas", "Mariana");


        }


    }

    #region Método antigo

    /*
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
     
     */

    #endregion
}
