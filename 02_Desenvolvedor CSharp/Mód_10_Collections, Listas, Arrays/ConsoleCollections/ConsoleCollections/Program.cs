using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // 01 - Aula 03 - Declarando e Populando Arrays
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a Classe Aula";
            string aulaSets = "Trabalhando com conjuntos.";

            //string[] aulas = new string[]
            //{
            //    aulaIntro, aulaModelando, aulaSets
            //};

            // Outra forma
            string[] aulas = new string[3];

            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;

            Imprimir(aulas);

            Console.WriteLine($"Primeiro elemento: {aulas[0]}");
            Console.WriteLine($"Último elemento: {aulas.Length - 1}"); // Ultimo elemento

            aulaIntro = "Teste";

            // Atribuindo o valor 'Teste' a 'aulaIntro', não mudará o que tem no
            // Array. E para realmente alterar o array, deverá ser feito da 
            // seguinte maneira: aula[0] = "Teste";

            aulas[0] = "Trabalhando com Arrays";

            Console.WriteLine($"Aula modelando está no indice: " +
                $"{Array.IndexOf(aulas, aulaModelando)}");

            Console.WriteLine($"Ultima ocorrencia de Aula modelando:" +
                $" {Array.LastIndexOf(aulas, aulaModelando)}");

            //--------------------------------------------

            // Revertendo a ordem do Array
            Array.Reverse(aulas);
            Imprimir(aulas);

            // Revertendo a ordem do Array - novamente
            Array.Reverse(aulas);
            Imprimir(aulas);

            //--------------------------------------------

            // Redimencionar / Diminuir o tamanho do Array







            //--------------------------------------------
            Console.ReadLine();
        }

        private static void Imprimir(string[] aulas)
        {
            //foreach (var item in aulas)
            //{
            //    Console.WriteLine(item);
            //}

            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }

        }
    }
}
