using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class TiposDeReferencia : IAulaItem
    {
        public void Executar()
        {

            int idade = 42;

            // copia da variavel
            int copiaIdade = idade;

            Console.WriteLine("INT Idade       = 42");
            Console.WriteLine("INT copiaIdade  = idade");
            Console.WriteLine();
            Console.WriteLine($"INT Idade      : {idade}");
            Console.WriteLine($"INT copiaIdade : {copiaIdade}");

            // altera o valor da variavel original
            idade = 32;
            Console.WriteLine();
            Console.WriteLine("INT Idade       = 32");
            Console.WriteLine($"INT Idade      : {idade}"); // valor modificado
            Console.WriteLine($"INT copiaIdade : {copiaIdade}"); // manteve o valor
            // A alteração do valor não afetou a copia da variável
            // Isso ocorre quando trabalhamos com tipos de valor. quando é
            // feita a atribuição a outra variavel, cada uma das variaveis se mantem
            // independentes
            //---------------------------------------------------
            
            var cliente1 = new Cliente ("José da Silva", 42);

            var cliente2 = cliente1; // copia do cliente1

            Console.WriteLine();
            Console.WriteLine(@"var cliente1 = new Cliente (""José da Silva"", 42)");
            Console.WriteLine(@"var cliente2 = cliente1;");
            Console.WriteLine($"Cliente1: {cliente1}");
            Console.WriteLine($"Cliente2: {cliente2}");

            // alterando o primeiro cliente para ver o que acontece com a copia

            cliente1.Nome = "Maria de Souza";

            Console.WriteLine();
            Console.WriteLine(@"cliente1.Nome =  ""Maria de Souza""");
            Console.WriteLine(@"var cliente2 = cliente1;");
            Console.WriteLine($"Cliente1: {cliente1}"); // Maria de Souza
            Console.WriteLine($"Cliente2: {cliente2}"); // José da Silva

            // A alteração não afetou o cliente2.

            // Alterar o tipo do cliente - usar uma classe ao invés do struct

            // Após alterar 'Cliente' de 'struct' para 'class', a alteração
            // feita afeta a copia, pois passamos a trabalhar com tipos de referencia
            // ou seja, ao realizar a copia do objeto, a copia passa a apontar (ponteiro)
            // para o mesmo local na memória que o original.

            // Tipo de valor = Copia independente
            // Tipo de referencia = não existe copia independente!

            // Quando é realizada a copia do 'cliente1', a copia não contêm um valor
            // pois ela é uma classe!
            // Ela contem uma referencia para um objeto que está em algum lugar na 
            // memoria!

            // Logo, a alteração foi feita na mesma area da memoria

        }
    }
    // struct Cliente
    class Cliente
    {
        public Cliente(string nome, int idade) 
        {
            Nome  = nome;
            Idade = idade;
        }

        public string Nome { get; set; }
        public int    Idade { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome} - Idade: {Idade}";
        }
    }
}
