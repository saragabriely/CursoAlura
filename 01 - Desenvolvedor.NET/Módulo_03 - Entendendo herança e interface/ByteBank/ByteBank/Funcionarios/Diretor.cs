using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Diretor : Funcionario
    {
        // override: diz que o método está sobrepondo um comportamento
        public override double GetBonificacao()
        {
            //  return Salario + ( Salario * 0.10 );
            return Salario + base.GetBonificacao();
            // está somando a bonificação do diretor (salario) com 
            // a bonificação de funcionario implementada na classe original (salario * 0.10)

            // 'base': busca a implementação original do método
        }
    }
}
