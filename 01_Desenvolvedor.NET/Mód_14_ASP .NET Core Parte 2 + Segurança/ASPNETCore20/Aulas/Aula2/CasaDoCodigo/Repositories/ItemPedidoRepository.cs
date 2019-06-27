using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        //void UpdateQuantidade(ItemPedido itemPedido);
        ItemPedido GetItemPedido(int itemPedidoId);
        void RemoveItemPedido(int itemPedidoId);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {

        }

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
            return dbSet.Where(ip => ip.Id == itemPedidoId).SingleOrDefault();
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            dbSet.Remove(GetItemPedido(itemPedidoId));
        }

        /*
        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido) // void
        {
            // Atualizar o ItemPedido no banco de dados
            var itemPedidoDB = dbSet.Where(ip => ip.Id == itemPedido.Id)
                                    .SingleOrDefault();

            if(itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                contexto.SaveChanges();
            }
        } */
    }
}
