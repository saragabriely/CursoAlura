
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Promocao
    {
        public int Id { get; set; }
        public string   Descricao   { get; internal set; }
        public DateTime DataFinal   { get; internal set; }
        public DateTime DataInicio  { get; internal set; }
        public IList<PromocaoProduto> Produtos { get; internal set; }

        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }

        public void IncluiProduto(Produto produto)
        {
            this.Produtos.Add(new PromocaoProduto() { Produto = produto});
        }
    }
}
