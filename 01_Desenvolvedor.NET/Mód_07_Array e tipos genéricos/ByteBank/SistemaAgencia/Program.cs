using ByteBank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaAgencia
{
    class Program
    {
        // Módulo 07 - Arrays

        static void Main(string[] args)
        {
            Lista<int> idades = new Lista<int>(); // Lista Genérica - Lista<T>

            idades.Adicionar(12);

            idades.AdicionarVarios(1, 5, 7);

            int idadeSoma = 0;

            for(int i = 0; i < idades.Tamanho; i++)
            {
                int idadeAtual = idades[i];
            }




            //-------------------
            Console.ReadLine();
        }

        #region Testa lista de Objects
        static void TestaListaDeObject()
        {
            // Aula 05 - Módulo 07

            ListaDeObjects listaDeIdades = new ListaDeObjects();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];

                Console.WriteLine($"Idade no indice {i}: {idade}");
            }
        }

        #endregion

        #region TestaListaContaCorrente - Aula 04 - Mód. 07
        static void TestaListaContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            // lista.MeuMetodo(numero: 10); // chama o método
            // para nomear / atribuir um valor ao atributo opcional - numero: 10
            // ou

            lista.MeuMetodo("texto padrao", 10);

            ContaCorrente contaDoGui = new ContaCorrente(546, 21112);

            lista.Adicionar(contaDoGui);

            //   lista.Adicionar(item: new ContaCorrente(745, 456232));
            //   lista.Adicionar(new ContaCorrente(745, 456232));
            //   lista.Adicionar(new ContaCorrente(748, 453232));
            //   lista.Adicionar(new ContaCorrente(789, 230157));

            Console.WriteLine();

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(745, 456232),
                new ContaCorrente(748, 453232),
                new ContaCorrente(789, 230157)
            };

            lista.AdicionarVarios(contas);

            Console.WriteLine();

            //   lista.EscreverListaNaTela();
            //   Console.WriteLine();
            //   lista.Remover(contaDoGui);
            //   Console.WriteLine();
            //   Console.WriteLine("Após remover o item: ");
            //   Console.WriteLine();
            //   lista.EscreverListaNaTela();

            for (int i = 0; i < lista.Tamanho; i++)
            {
                // ContaCorrente itemAtual = lista.GetItemNoIndice(i);
                // ou 

                // ContaCorrente teste = lista["texto"];
                // ou
                ContaCorrente itemAtual = lista[i]; // o 'lista[i]' não seria possível  
                                                    // caso não tivesse o INDEXADOR declarador na classe
                                                    // 'ListaDeContaCorrente'

                Console.WriteLine(
                    $"Item na posição {i} = Conta {itemAtual.Agencia}/{itemAtual.Numero}");
            }
        }
        #endregion

        #region Exemplo - SomarVarios - Aula 03 - Mód. 07
        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;

            foreach(int numero in numeros)
            {
                acumulador += numero;
            }

            return acumulador;
        }
        #endregion

        #region Array de Conta Corrente - Aula 02 - Mód. 07
        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(745, 456232),
                new ContaCorrente(748, 453232),
                new ContaCorrente(789, 230157)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];

                Console.WriteLine($"Conta {indice} - Contas: {contaAtual.Numero}");

            }
        }
        #endregion

        #region Array de Int - Aula 01 - Mód. 07
        static void TestaArrayInt()
        {
            // Array de inteiros
            // Array é um tipo de referência (não é um tipo de valor, como o inteiro)
            int[] idades = new int[3]; // new int[tamanho]

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;
            //idades[5] = 60;

            Console.WriteLine($"Tamanho do Array: {idades.Length}");
            Console.WriteLine(); // pula linha

            // int[] idadeNoIndice4 = idades; // Correto

            // int idadeNoIndice4 = idades[4]; // ou indice[2 + 2]

            // Console.WriteLine(idadeNoIndice4);

            // O zero é o valor padrão do inteiro. 
            // Caso ocorra a tentativa de acessar um indice que não exista,
            // irá retornar o 0;

            int acumulador = 0;

            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o Array Idades no indice: {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                Console.WriteLine();

                acumulador += idade;

            }

            int media = acumulador / idades.Length;

            Console.WriteLine($"Média de idades = {media}");


            #region Comentários - OutroArray e ArrayBooleano

            // int[] outroArray = idades;
            // Console.WriteLine(outroArray[3]);

            /*
            bool[] arrayDeBooleanos = new bool[10];

            arrayDeBooleanos[0] = true;
            arrayDeBooleanos[1] = false;
            arrayDeBooleanos[2] = false;
            arrayDeBooleanos[3] = true;
            */

            #endregion

        }
        #endregion

    }
}
