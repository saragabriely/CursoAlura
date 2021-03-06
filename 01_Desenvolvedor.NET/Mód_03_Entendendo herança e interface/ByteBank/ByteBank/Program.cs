﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Funcionarios;
using ByteBank.Sistemas;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            UsarSistema();

            // CalcularBonificacao();
            
            #region Primeiro Código
            /* Primeiro código
            GerenciadorBonificacao gerenciador = new GerenciadorBonificacao();

            // Carlos
            Funcionario Carlos = new Funcionario(2000, "546.879.157-20");

            Carlos.Nome    = "Carlos";
           // Carlos.CPF     = ;
           // Carlos.Salario = 2000;
            Carlos.AumentarSalario();

            gerenciador.Registrar(Carlos);

            Console.WriteLine("Nome:         " + Carlos.Nome);
            Console.WriteLine("Bonificação:  R$ " + Carlos.GetBonificacao());
            Console.WriteLine("Novo salário: R$ " + Carlos.Salario);

            Console.WriteLine();

            Console.WriteLine("Total de funcionários: " + Funcionario.TotalDeFuncionarios);

            Console.WriteLine();

            // Pedro
            // Funcionario Pedro = new Diretor();

            // Roberta
            Diretor roberta = new Diretor(5000, "454.658.148-3");
            roberta.Nome    = "Roberta";
          //  roberta.CPF     = ;
          //  roberta.Salario = 5000;
            roberta.AumentarSalario();
            
            gerenciador.Registrar(roberta);

            Console.WriteLine("Nome:         " + roberta.Nome);
            Console.WriteLine("Bonificação:  R$ " + roberta.GetBonificacao());
            Console.WriteLine("Novo salário: R$ " + roberta.Salario);

            Console.WriteLine();
            
            Funcionario robertaTeste = roberta;

            Console.WriteLine("Bonificação de uma referência Diretor:     " + roberta.GetBonificacao());
            Console.WriteLine("Bonificação de uma referência Funcionario: " + robertaTeste.GetBonificacao());

            Console.WriteLine();

            Console.WriteLine("Total de bonificações: " + gerenciador.GetTotalBonificacao());
            */
            #endregion

            Console.ReadLine();
        }


        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();

            Diretor roberta = new Diretor("159.753.398-04"); 
            roberta.Nome    = "Roberta";
            roberta.Senha   = "123";

            GerenteDeConta camila = new GerenteDeConta("326.982.628-89"); // ...
            camila.Nome  = "Camila";
            camila.Senha = "abc";

            Funcionario pedro = new Designer("833.222.048-39"); // ou Funcionario pedro = new Designer("833.222.048-39");
            pedro.Nome = "Pedro";

            ParceiroComercial parceiro = new ParceiroComercial();
            parceiro.Senha = "123456";

            sistemaInterno.Logar(roberta, "123");
            sistemaInterno.Logar(camila,  "abc");
            //  sistemaInterno.Logar(pedro,   "abc");
            sistemaInterno.Logar(parceiro, "123456");            

        }

        public static void CalcularBonificacao()
        {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

          // Funcionario carlos = new Funcionario(2000, "456.456.456-88");
          // carlos.GetBonificacao();
          // Não é possível criar uma instância de classe abstrata

            Designer pedro = new Designer("833.222.048-39"); // ou Funcionario pedro = new Designer("833.222.048-39");
            pedro.Nome = "Pedro";

            Diretor roberta = new Diretor("159.753.398-04"); // ou Funcionario roberta = new Diretor("159.753.398-04");
            roberta.Nome = "Roberta";

            Auxiliar igor = new Auxiliar("981.198.778-53"); // ...
            igor.Nome = "Igor";

            GerenteDeConta camila = new GerenteDeConta("326.982.628-89"); // ...
            camila.Nome = "Camila";

            Desenvolvedor guilherme = new Desenvolvedor("456.175.468-20");
            guilherme.Nome = "Guilherme";

            gerenciadorBonificacao.Registrar(guilherme);
            gerenciadorBonificacao.Registrar(pedro);
            gerenciadorBonificacao.Registrar(roberta);
            gerenciadorBonificacao.Registrar(igor);
            gerenciadorBonificacao.Registrar(camila);

            Console.WriteLine();

            Console.WriteLine("Total de bonificações do mês: - R$ " +
                gerenciadorBonificacao.GetTotalBonificacao());

        }

    }
}
