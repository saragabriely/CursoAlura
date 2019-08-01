using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace certificacao_csharp_roteiro
{
    class ParametrosNomeados : IAulaItem
    {
        public void Executar()
        {
            // O método pode ser chamado do jeito normal, usando argumentos posicionados
            ImprimirDetalhesDoPedido("Maria de Fatima", 31, "Caneca Vermelha");
            // Ordem que os parametros foram declarados no método

            // Argumentos nomeados podem ser fornecidos para os parametros
            // em qualquer ordem
            ImprimirDetalhesDoPedido(numeroPedido:  31,
                                    nomeProduto:    "Caneca Vermelha", 
                                    vendedor:       "Maria de Fatima");

            ImprimirDetalhesDoPedido(nomeProduto:   "Caneca Vermelha", 
                                     vendedor:      "Maria de Fatima", 
                                     numeroPedido:  31);

            // Argumentos nomeados misturados com argumentos posicionais validos
            ImprimirDetalhesDoPedido("Maria de Fatima", 31, nomeProduto: "Caneca Vermelha");

            // As 2 linhas abaixo geravam erro de compilacao ANTES DO C# 7.2:
            ImprimirDetalhesDoPedido(vendedor:  "Maria de Fatima", 31, 
                                     nomeProduto: "Caneca Vermelha");

            ImprimirDetalhesDoPedido("Maria de Fatima", numeroPedido: 31, "Caneca Vermelha");

        }

        void ImprimirDetalhesDoPedido(string vendedor, int numeroPedido, string nomeProduto)
        {
            if (string.IsNullOrWhiteSpace(vendedor))
            {
                throw new ArgumentException(message: "Nome de vendedor não pode ser nulo ou vazio.", paramName: nameof(vendedor));
            }

            Console.WriteLine($"Vendedor: {vendedor}, Pedido No.: {numeroPedido}, Produto: {nomeProduto}");
            Console.WriteLine();
        }
    }
}
