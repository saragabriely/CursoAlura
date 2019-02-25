using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgencia
{
    public class Estagiario : Funcionario
    {
        public Estagiario(double salario, string cpf) : base(salario, cpf)
        {

        }

        public override void AumentarSalario()
        {
            // Qualquer código
        }

        // O INTERNAL faz sentido apenas na classe base - pois é sobre projetos

        protected override double GetBonificacao()
        {
            throw new NotImplementedException();
        }

    }
}
