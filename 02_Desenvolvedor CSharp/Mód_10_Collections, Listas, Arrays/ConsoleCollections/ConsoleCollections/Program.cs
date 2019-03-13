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
            // ... implementaremos a solução de um problema de navegação 
            // de browser, ou navegador Web

            // PILHA!

            // O PRIMEIRO QUE ENTRA É O ÚLTIMO QUE SAI!

            var navegador = new Navegador();

            navegador.NavegarPara("google.com");

            navegador.NavegarPara("caelum.com.br");

            navegador.NavegarPara("alura.com.br");

            Console.WriteLine("----------------------------------");

            navegador.Anterior();   // google
            navegador.Anterior();   // caelum 
            navegador.Anterior();   // vazia

            Console.WriteLine("----------------------------------");

            navegador.Proximo();


            //--------------------------------------------
            Console.ReadLine();
        }
    }

    internal class Navegador
    {
        // Anterior: salvar a página atual que será substituida
        // criar uma coleção (pilha/STACK) para isso

        private readonly Stack<string> historicoAnterior = new Stack<string>();
        private readonly Stack<string> historicoProximo  = new Stack<string>();
        
        private string atual = "vazia";

        public Navegador()
        {
            Console.WriteLine($"Página atual: {atual}");
        }

        internal void Anterior()
        {
            if (historicoAnterior.Any()) // Verifica se tem algum valor
            {
                historicoProximo.Push(atual); // alimentando o historico Proximo

                // POP: Obter o valor 
                atual = historicoAnterior.Pop(); // Retorna uma string
                Console.WriteLine($"Página atual: {atual}");
            }
            
            // Para acessar a página anterior, a página atual irá assumir 
            // o valor da página anterior
            
        }
        
        internal void NavegarPara(string url)
        {
            // PUSH: Colocar em pilha
            historicoAnterior.Push(atual); // salvar a página que será trocada

            atual = url;

            Console.WriteLine($"Página atual: {atual}");
        }

        internal void Proximo()
        {
            if (historicoProximo.Any())
            {
                historicoAnterior.Push(atual); // alimentando o histórico anterior

                atual = historicoProximo.Pop();

                Console.WriteLine($"Página atual: {atual}");

            }
        }
    }
}
