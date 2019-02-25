using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_CaracteresETextos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando Projto 5 - Caracteres e textos");

            // Character
            char primeiraLetra = 'a';
            Console.WriteLine("Caracter A: " + primeiraLetra);

            primeiraLetra = (char) 65;                  // Resultado: A
            Console.WriteLine("Caracter A com casting: " + primeiraLetra);

            primeiraLetra = (char)(primeiraLetra + 1); // Resultado: B
            Console.WriteLine("Caracter A com casting: " + primeiraLetra);

            // String - Tipo usado para representação de texto
            string titulo = "Alura Cursos de Tecnologia - " + 2019;

            Console.WriteLine("Titulo: " + titulo);


            string cursosProgramacao = 
                @" - .NET 
                    - Java
                    - Javascript";
            
            Console.WriteLine(cursosProgramacao);

            // É possível criar uma string vazia (teste = "")
            // Fim
            Console.WriteLine("Execução concluida. Selecione ENTER para finalizar ...");
            Console.ReadLine();
        }
    }
}
