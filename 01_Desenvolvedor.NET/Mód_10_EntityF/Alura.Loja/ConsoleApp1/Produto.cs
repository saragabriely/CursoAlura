namespace ConsoleApp1
{
    public class Produto
    {
        public int    Id        { get; internal set; }
        public string Nome      { get; internal set; }
        public string Categoria { get; internal set; }
        public double Preco     { get; internal set; }

        public override string ToString()
        {
            return $"Produto: {this.Nome}, {this.Categoria}, " +
                   $"{this.Preco}, {this.Id}";
        }

        #region Comentário - Chamar a classe sem o método ToString() declarado
        // Ao tentar mostrar o que tem no banco de dados através do código abaixo,
        // sem declarar o método ToString() nesta classe, o resultado será:
        // ConsoleApp1.Produto
        // ConsoleApp1.Produto

        // using(var contexto = new LojaContext())
        // {
        //     var produtos = contexto.Produtos.ToList();
        //     foreach (var p in produtos)
        //     {
        //         Console.WriteLine(p); 
        //      }
        // }
        #endregion


    }

}