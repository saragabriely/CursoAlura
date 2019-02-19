using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class Cliente
    {
        private string _cpf;

        public string Nome { get; set; }
        public string CPF  { get; set; }
        /*{
            get
            {
                return _cpf;
            }
            set
            {
                // Escrevo minha lógica de validação de CPF
                _cpf = value;
            }
        } */

        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            // Cliente outroCliente = (Cliente)obj;
            Cliente outroCliente = obj as Cliente; 
            // 'as' retorna null quando a conversão não ocorre com sucesso

            if(outroCliente == null)
            {
                return false;
            }

            return CPF == outroCliente.CPF;

            /*
            return Nome      == outroCliente.Nome
                && CPF       == outroCliente.CPF
                && Profissao == outroCliente.Profissao;
            */
        }
    }
}
