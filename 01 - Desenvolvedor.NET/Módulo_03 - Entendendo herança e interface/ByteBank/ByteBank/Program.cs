using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Funcionarios;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();

            // Carlos
            Funcionario Carlos = new Funcionario();

            Carlos.Nome    = "Carlos";
            Carlos.CPF     = "546.879.157-20";
            Carlos.Salario = 2000;

            gerenciador.Registrar(Carlos);

            Console.WriteLine("Nome:        " + Carlos.Nome);
            Console.WriteLine("Bonificação: R$ " + Carlos.GetBonificacao());
            
            Console.WriteLine();

            Console.WriteLine("Total de funcionários: " + Funcionario.TotalDeFuncionarios);

            Console.WriteLine();

            // Pedro
            // Funcionario Pedro = new Diretor();

            // Roberta
            Diretor roberta = new Diretor();
            roberta.Nome    = "Roberta";
            roberta.CPF     = "454.658.148-3";
            roberta.Salario = 5000;
            
            gerenciador.Registrar(roberta);

            Console.WriteLine("Nome:        " + roberta.Nome);
            Console.WriteLine("Bonificação: R$ " + roberta.GetBonificacao());

            Console.WriteLine();
            
            Funcionario robertaTeste = roberta;

            Console.WriteLine("Bonificação de uma referência Diretor:     " + roberta.GetBonificacao());
            Console.WriteLine("Bonificação de uma referência Funcionario: " + robertaTeste.GetBonificacao());

            Console.WriteLine();

            Console.WriteLine("Total de bonificações: " + gerenciador.GetTotalBonificacao());
            Console.ReadLine();

            Console.ReadLine();
        }
    }
}
