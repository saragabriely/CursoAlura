// using _05_ByteBank;

using System;

namespace ByteBank
{
    // Summary -> Documentação de classes, métodos, atributos ... publicos

    /// <summary>
    /// Define uma Conta Corrente do banco ByteBank
    /// </summary>

    public class ContaCorrente
    {
        // A documentação é mais indicada para membros PUBLICOS, pois são usados por outras classes

        public Cliente       Titular                             { get; set; }

        public int           ContadorSaquesNaoPermitidos         { get; private set; }

        public int           ContadorTransferenciasNaoPermitidas { get; private set; }

        public static double TaxaOperacao                        { get; private set; }

        public static int    TotalDeContasCriadas                { get; private set; }

        public  int          Agencia    { get; } // propriedade privada / somente leitura
                             
        public  int          Numero     { get; }
        
        // Membros privados não terão que receber uma documentação (não aparecerá 
        // o risquinho verde embaixo, caso não tenha doc.), pois não será visto por
        // outras classes
        private double       _saldo = 100;
                             
        public  double       Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instância de Conta Corrente com os argumentos utilizados
        /// </summary>
        /// <param name="numeroAgencia"> Representa o valor da propriedade <see cref="Agencia"/>. E deve possuir um valor maior que 0 (zero).</param>
        /// <param name="numeroConta"  > Representa o valor da propriedade <see cref="Numero"/>. E deve possuir um valor maior que 0 (zero). </param>
        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if(numeroAgencia <= 0)
            {
                throw new ArgumentException(
                    "O argumento 'agencia' deve ser maior que 0 (zero)", 
                    nameof(numeroAgencia)); // numeroAgencia = nome do argumento que deu erro
            }

            if (numeroConta <= 0)
            {
                throw new ArgumentException(
                    "O argumento 'número' deve ser maior que 0 (zero)", 
                    nameof(numeroConta));
            }

            #region Comentários
            /*
            if (agencia <= 0 || numero <= 0)
            {
                // ArgumentException: exceção de argumento

                //Exception excecao = new Exception("Agencia e/ou numero da conta é zero!");

                ArgumentException excecao = new ArgumentException("Agencia e/ou numero da conta é zero!");

                // Lançar exceção
                //throw new Exception();
                throw excecao;
            } */
            #endregion

            Agencia = numeroAgencia;
            Numero  = numeroConta;
            
            TotalDeContasCriadas++; // Contador de contas criadas

            // Quanto mais contas, menor será a taxa de operação
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }
        
        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/></exception>
        /// <param name="valor">Representa o valor do saque. Deve ser maior que 0 (zero) e menor que o <see cref="Saldo"/></param>
        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                //  throw new 
                //      SaldoInsuficienteException("Saldo insuficiente para o saque no valor de R$ " + valor);

                ContadorSaquesNaoPermitidos++;

                throw new
                    SaldoInsuficienteException(Saldo, valor);

                /*  A máquina virtual do VS (CLR) é quem preenche o StackTrace.   */
            }

            _saldo -= valor;
        }

        #region Sacar - 01

        /*
          public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;

            return true;
        }
             */

        #endregion

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        // Anterior: bool
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

           // Sacar(valor);
            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;

                throw new OperacaoFinanceiraException("Operação não realizada.", ex); // passa a exceção adiante

            }
            /* if (_saldo < valor)  {  return false;   }
               _saldo -= valor;                             */

            contaDestino.Depositar(valor);

           // return true;
        }

        public override string ToString()
        {
            return $"Numero: {Numero}, Agencia: {Agencia}, Saldo: {Saldo}";

            // return $"Numero: {35624 + 12356 * 2}, Agencia: {Agencia}, Saldo: {Saldo}";
            // É possível realizar contas no lugar do valor que será exibido
            
            // ou
            //return "Número: " + Numero + ", Agencia: " + Agencia + ", Saldo: " + Saldo;
        }


        public override bool Equals(object obj)
        {
            // Converter a referencia de object para ContaCorrente
            ContaCorrente outraConta = obj as ContaCorrente; 

            // As - Caso a conversão acima falhe, outraConta será nula 

            if(outraConta == null)
            {
                return false;
            }

            // Comparação -------------------------------------------------

            return Numero == outraConta.Numero && Agencia == outraConta.Agencia;
        }

    }
}
