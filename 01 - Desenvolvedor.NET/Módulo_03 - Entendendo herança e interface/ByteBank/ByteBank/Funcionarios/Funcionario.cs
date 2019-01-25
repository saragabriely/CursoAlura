using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }

        public string Nome      { get; set; }
        public string CPF       { get; set; }
        public double Salario   { get; set; }
        
        public Funcionario()
        {
            TotalDeFuncionarios++;
        }

        // Virtual: permite que o método seja sobreescrito
        public virtual double GetBonificacao()
        {
            return Salario * 0.10;
        }

    }
}
