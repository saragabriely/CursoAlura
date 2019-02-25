

public class ContaCorrente
{
    public string titular;
    public int    agencia;
    public int    numero;
    public double saldo = 100.0; // valor padrão (exemplo)
    
    // Função - Sacar
    public bool Sacar(double valor)
    {
        if(this.saldo < valor) // 'this' acessa o saldo dessa instância/objeto
        {
            return false;
        }

        this.saldo -= valor; // Saque

        return true;
        
    }

    // Função - Depositar (sem retorno)
    public void Depositar(double valor)
    {
        this.saldo += valor;
    }

    // Função - Transferir
    public bool Transferir(double valor, ContaCorrente contaDestino)
    {
        if(this.saldo < valor)  // verifica se o valor da transferência é maior que o saldo da conta origem
        {
            return false;
        }
        
        this.saldo -= valor;            // Tira o valor da conta origem

        contaDestino.Depositar(valor);  // Deposita o valor na conta destino

        return true;                    // sucesso

    }


}