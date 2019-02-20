using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    // : Exception
    
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        public double Saldo      { get; }
        public double ValorSaque { get; }

        public SaldoInsuficienteException() { }
        
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : base("Tentativa de saque do valor de R$ " + valorSaque +
                   ", em uma conta com saldo de R$ " + saldo)
        {
            Saldo       = saldo;
            ValorSaque  = valorSaque;
        }

        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }

        // É uma boa pratica colocar um construtor com uma InnerException
        public SaldoInsuficienteException (string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }

    }
}
