

namespace ConsoleApp1
{
    public class PromocaoProduto
    {

        // Incluir propriedades inteiras (inteiro) para dizer que são obrigatórias
        public int      ProdutoId       { get; set; }
        public int      PromocaoId      { get; set; }
        public Produto  Produto         { get; set; }
        public Promocao Promocao        { get; set; }

        // Chave primária composta!
        // Para criá-la, basta configurar o método OnModelCreating no LojaContext
        // informando as propriedades que irão compor a chave primária.

    }
}
