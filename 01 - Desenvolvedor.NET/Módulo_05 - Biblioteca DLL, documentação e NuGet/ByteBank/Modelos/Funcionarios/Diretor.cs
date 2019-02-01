using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Diretor :  FuncionarioAutenticavel //Funcionario, Autenticavel  // primeiro é colocada a herança da classe e depois a interface
    {
        // Ao chamar o construtor de um tipo derivado, será chamado primeiro
        // o construtor da classe base (no caso Funcionario)
        public Diretor(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Criando DIRETOR");
            Console.WriteLine();
        }

        // override: diz que o método está sobrepondo um comportamento
        // Anterior: public override double GetBonificacao()
        internal protected override double GetBonificacao()
        {
            //  return Salario + ( Salario * 0.10 );
            // return Salario + base.GetBonificacao();

            return Salario * 0.5;

            // está somando a bonificação do diretor (salario) com 
            // a bonificação de funcionario implementada na classe original (salario * 0.10)

            // 'base': busca a implementação original do método
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

        #region Exemplo

        /*
         EXEMPLO

        public abstract class Casa
        {
            public abstract void AbrirPorta();
        }

        public interface Carro
        {
            void AbrirPorta();
        }
         
        public class Exemplo : Casa, Carro  // herança, interface
        {
            public override void AbrirPorta()
            {
                
            }
        }         
         */
        #endregion

    }
}
