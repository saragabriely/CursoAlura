using ByteBank.Sistemas;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel 
    {
        private AutenticaHelper _autenticacaoHelper = new AutenticaHelper();

        public string Senha  { get; set; }

        public FuncionarioAutenticavel(double salario, string cpf)
            : base(salario, cpf)
        {
       
        }

        public bool Autenticar (string senha)
        {
            //return Senha == senha;

            return _autenticacaoHelper.CompararSenhas(Senha, senha);
        }

    }
}
