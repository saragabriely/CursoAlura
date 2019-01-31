using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }

        public string Nome     { get; set; }
        public string CPF      { get; private set; }
        public double Salario  { get; protected set; }
        // Protected: salario não é publico - é acessado somente pela classe e seus derivados

      //  public string Senha    { get; set; }

        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Criando FUNCIONÁRIO");

            CPF     = cpf;
            Salario = salario;

            TotalDeFuncionarios++;
        }

     /*   public bool Autenticar(string senha)
        {
            return Senha == senha;
        } */
 
        public abstract void AumentarSalario(); // esse método deve ser sobreescrito pelas classes derivadas
        /* public virtual void AumentarSalario()
           {
                Salario = Salario + (Salario * 0.1);
                Salario = Salario * 1.1;
                Salario *= 1.1;
          
                Console.WriteLine("Atenção! Não esqueça de sobreescrever o método AumentarSalario()");
           } */

        public abstract double GetBonificacao();
       
        // Virtual: permite que o método seja sobreescrito
      /*  public virtual double GetBonificacao()
          {
             return Salario * 0.10;
         
              Console.WriteLine("Atenção! Não esqueça de sobreescrever o método GetBonificacao()");
         
              return 0;
          } */

    }
}
