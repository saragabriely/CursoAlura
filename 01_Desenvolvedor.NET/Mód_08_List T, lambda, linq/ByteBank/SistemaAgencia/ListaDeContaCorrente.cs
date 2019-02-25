using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgencia
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;

        private int _proximaPosicao;

        // indica o numero de itens existentes na lista
        public int Tamanho
        {
            get { return _proximaPosicao; }
        }

        /* public ListaDeContaCorrente() : this(5)
        {
            // Nova sobrecarga
        } */

        // Mostra para o desenvolvedor(a) o valor padrão, e a sobrecarga com 
        // construtor sem argumentos, não mostra
        public ListaDeContaCorrente(int capacidadeInicial = 5) // valor opcional
        {
            _itens = new ContaCorrente[capacidadeInicial];

            _proximaPosicao = 0;
        }

        public void MeuMetodo(string texto = "texto padrao", int numero = 5) { }

        #region ADICIONAR
        public void Adicionar(ContaCorrente item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

           // Console.WriteLine($"Adicionando item ns posição {_proximaPosicao}");

            _itens[_proximaPosicao] = item;

            _proximaPosicao++; // aumenta o tamanho do array
        }
        #endregion


        #region AdicionarVarios(Array de ContaCorrente)

        // Ao adicionar o 'PARAMS', o corpo do código é o mesmo;
        // Porém é possível chamar o método com diversos argumentos.

        // O compilador criará um Array com todos os objetos passados como parametros
        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            // for (int i = 0; i < itens.Length; i++) { Adicionar(itens[i]);  }

            // FOREACH - Para cada ContaCorrente no array itens
            foreach(ContaCorrente conta in itens)
            {
                // A compilação é semelhante ao FOR 'normal'
                // Quando os indices não são importantes

                Adicionar(conta);
            }
        }

        #endregion
        
        #region REMOVER
        public void Remover(ContaCorrente item)
        {
            int indiceITem = -1; // item invalido

            // Buscar o indice do objeto desejado, para posteriormente deletá-lo

            // Laço - varre a lista até a proxima posicao livre
            for(int i = 0; i < _proximaPosicao - 1; i++)
            {
                ContaCorrente itemAtual = _itens[i];

                // _itens[i] == item -> comparação de referencia (posicao do objeto na memmora)
                if (itemAtual.Equals(item)) // caso seja verdadeiro, descobrimos o indice
                {                           // do item desejado
                    indiceITem = i;

                    break; // abandonar o laço de repetição.
                }
            }

            // Deslocando o Array para cobrir o objeto que será tirado
            // Iniciando pelo in
            for(int i = indiceITem; i < _proximaPosicao; i++)
            {
                _itens[i] = _itens[i + 1];
                // muda a posição
            }

            _proximaPosicao--; // diminui o tamanho do array 
            _itens[_proximaPosicao] = null;
        }
        #endregion

        #region GetItemNoIndice
        public ContaCorrente GetItemNoIndice(int indice)
        {
            if(indice < 0 || indice >= _proximaPosicao)
            {
                // Indice fora do intervalo permitido
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }
        #endregion

        #region EscreverListaNaTela
        /*
        public void EscreverListaNaTela()
        {
            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente conta = _itens[i];

                Console.WriteLine($"Conta no indice {i} - {conta.Agencia} {conta.Numero}");
            }
        } */
        #endregion

        #region Verifica capacidade do Array
        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;

            if(novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

         //   Console.WriteLine("Aumentando a capaciddade da lista!");

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho]; // [tamanhoNecessario]

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];

                Console.WriteLine("."); // mostra quantas iterações foram feitas com o array
            }

            _itens = novoArray;
        }
        #endregion

        #region Indexadores
        // Não é um método - será tratado como um INDEXADOR ([])
        public ContaCorrente this[int indice]
        {
            get
            {
                return GetItemNoIndice(indice);
            }
        }

        public ContaCorrente this[string texto]
        {
            get
            {
                return null;
            }
        }
        #endregion

    }
}
