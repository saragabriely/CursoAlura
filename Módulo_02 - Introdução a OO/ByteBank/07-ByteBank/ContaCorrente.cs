

namespace _07_ByteBank
{
    public class ContaCorrente
    {
        // TITULAR ----------------------------------------------
        //  private Cliente _titular; 

        public Cliente Titular   {  get; set; }

        // Propriedade que pertence a classe e todos os objetos compartilham essa informação
        // logo, a informação pertence a classe e não dos objetos
        public static int TotalDeContasCriadas { get; private set; }


        private int _agencia;

        public int Agencia
        {
            get
            {
                return _agencia;
            }
            set
            {
                if(value <= 0)
                {
                    return;
                }
                _agencia = value;
            }
        }

        public int Numero  { get; set; }
        
        private double  _saldo = 100.0; // valor padrão (exemplo)
                                        // o campo privado será visivel somente dentro da clase pertencente
                                        // campo private/privado - ENCAPSULAMENTO
                                        
        // SALDO ------------------------------------------------
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)   // Saldo negativo
                {
                    return; // 'return' vazio em um método void, para a execução desse método
                }

                _saldo = value;                
            }
        }
        
        // Construtor
        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero  = numero;

            TotalDeContasCriadas++;
        }

        // Função - Sacar
        public bool Sacar(double valor)
        {
            if(_saldo < valor) // 'this' acessa o saldo dessa instância/objeto
            {
                return false;
            }

            _saldo -= valor; // Saque

            return true;
        
        }

        // Função - Depositar (sem retorno)
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        // Função - Transferir
        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if(_saldo < valor)  // verifica se o valor da transferência é maior que o saldo da conta origem
            {
                return false;
            }
        
            _saldo -= valor;            // Tira o valor da conta origem

            contaDestino.Depositar(valor);  // Deposita o valor na conta destino

            return true;                    // sucessos
        }


    }
}