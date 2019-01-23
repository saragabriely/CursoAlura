using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ConversoesEOutrosTiposNumericos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 4");
            
            // Double
            double salario;
            salario = 1200.50;
            
            Console.WriteLine("Salario - Double:   " + salario);

            // Inteiro - Variável que suporta até 32 bits
            int salarioEmInteiro;
            salarioEmInteiro = (int) salario;
            
            Console.WriteLine("Salario - Inteiro: " + salarioEmInteiro);

            //Long - Variável de 64 bits
            long idadeLong;
            idadeLong = 13000000000;

            Console.WriteLine("Idade - Long: " + idadeLong);

            // Short - Variável de 16 bits
            short quantidadeProdutos;
            quantidadeProdutos = 16000;

            Console.WriteLine("Quantidade - Short: " + quantidadeProdutos);

            // Float - Precisão curta de números que suporta depois da casa decimal.
            float altura = 1.80f;

            Console.WriteLine("Altura - Float: " + altura);


            // Fim
            Console.WriteLine("Projeto finalizado. Selecione ENTER para finalizar ...");
            Console.ReadLine();
        }
    }
}
