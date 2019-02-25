using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class GerenteDeConta : FuncionarioAutenticavel // Autenticavel
    {
        //public string Senha { get; set; }

        public GerenteDeConta(string cpf) : base(4000, cpf)
        {

        }

        /*
        public bool Autenticar(string senha)
        {
            return Senha == senha;
        } */

        public override void AumentarSalario()
        {
            Salario *= 1.05;
        }

        // public override double GetBonificacao()
        internal protected override double GetBonificacao()
        {
            return Salario * 0.25;
        }

    }
}
