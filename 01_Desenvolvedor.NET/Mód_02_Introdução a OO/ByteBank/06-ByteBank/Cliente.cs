using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteBank
{
    public class Cliente
    {
        private string _nome;
        private string _cpf;
        private string _profissao;
        
        public string Nome       { get; set; }
        public string CPF        { get; set; }
        public string Profissao
        {
            get
            {
                return _cpf;
            }
            set
            {
                // Escrevo minha 
                _cpf = value;
            }
        }

        

    }
}
