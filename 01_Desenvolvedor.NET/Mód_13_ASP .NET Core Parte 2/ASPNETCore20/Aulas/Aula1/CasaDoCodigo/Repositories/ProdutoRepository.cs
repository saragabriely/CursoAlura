using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        // novo construtor
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public IList<Produto> GetProdutos()
        {
           return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                // o IF evita de mostrar livros repetidos
                if (!dbSet.Where(l => l.Codigo == livro.Codigo).Any())
                {
                    // Any() - traz verdadeiro caso encontre o livro
                    // carrega as informaçõs em memória
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            contexto.SaveChanges(); // salva as informações no banco
        }
    }

    public class Livro
    {
        public string  Codigo { get; set; }
        public string  Nome   { get; set; }
        public decimal Preco  { get; set; }
        
    }
}
