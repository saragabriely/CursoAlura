

namespace _06_ByteBank
{
    public class ContaCorrente
    {
        // TITULAR ----------------------------------------------
      //  private Cliente _titular; 

        public Cliente Titular   {  get; set; }

        public int Agencia { get; set; }
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