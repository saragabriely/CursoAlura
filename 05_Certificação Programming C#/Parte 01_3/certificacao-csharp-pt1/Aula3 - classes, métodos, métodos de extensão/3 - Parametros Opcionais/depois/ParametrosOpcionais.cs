using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class ParametrosOpcionais : IAulaItem
    {
        public void Executar()
        {

            ClienteEspecial clienteEspecial = 
                    new ClienteEspecial("Lucas Skywalker");

            clienteEspecial.FazerPedido(1, "Residencial", 1);

            // utiliza parametro opcional - neste caso, é o 'NOME'
            clienteEspecial = new ClienteEspecial(); 
            clienteEspecial.FazerPedido(1, "Residencial", 1);

            // sem fornecer a quantidade (parametro opcional - com valor default)
            clienteEspecial.FazerPedido(2, "Comercial");

            // Apenas com o numero do pedido (quantidade e endereços são opcionais)
            clienteEspecial.FazerPedido(3);

            //--------------------------------------------------------------

            // As instruções a seguir produzem erros de compilação.
            // Um argumento tem que ser fornecido para o primeiro parametro
            // precisa ser inteiro.
            //clienteEspecial.FazerPedido("Residencial", 1); // sem o arg. obrigatorio
            //clienteEspecial.FazerPedido(); // sem argumentos

            // Você pode deixar um "buraco" nos argumentos
            // clienteEspecial.FazerPedido(3, , 4); // sem o segundo argumento (vazio)
            // clienteEspecial.FazerPedido(3, 4); // pulando o segundo argumento

            // Você pode usar um argumento nomeado para fazer a instrução anterior
            // funcionar!
            clienteEspecial.FazerPedido(3, quantidade: 4);

        }
    }

    class ClienteEspecial
    {
        private readonly string nome;

        // Parametro Opcional!
        // É necessário declarar um parametro DEFAULT que será assumido 
        // quando não for passado o nome => string nome = "Anonimo"
        public ClienteEspecial(string nome = "Anonimo") // (string nome )
        {
            this.nome = nome;
        }

        // Os parametros opcionais serão os ultimos na lista de parametros do método
        // ou seja, os opcionais devem aparecer depois dos parametros obrigatorios
        public void FazerPedido(int produtoId, string endereco = "Residencial", 
                                int quantidade = 10)
        {
            Console.WriteLine("Cliente {0}: produtoId: {1}, endereço: {2}, quantidade: {3}.", nome, produtoId, endereco, quantidade);
            Console.WriteLine();
        }
    }
}
