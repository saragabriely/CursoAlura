

class Carrinho {

    clickIncremento(btn) {

        let data = this.getData(btn);

        data.Quantidade++;

        this.postQuantidade(data);
    }

    clickDecremento(btn) {

        let data = this.getData(btn);

        data.Quantidade--;

        this.postQuantidade(data);
    }

    updateQuantidade(input)
    {
        let data = this.getData(input);

        this.postQuantidade(data);
    }

    getData(elemento)
    {
        var linhaDoItem = $(elemento).parents('[item-id]');

        var itemId      = $(linhaDoItem).attr('item-id');

        var novaQtde    = $(linhaDoItem).find('input').val();

        return  { Id: itemId, Quantidade: novaQtde };
    }

    postQuantidade(data)
    {
        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        })
          .done(function (response)
          {   //location.reload(); // carrega a página inteira

              // objeto de resposta

              let itemPedido  = response.itemPedido;

              let linhaDoItem = $('[item-id=' + itemPedido.id +']');

              linhaDoItem.find('input').val(itemPedido.quantidade);

              linhaDoItem.find('[subtotal]').html((itemPedido.subtotal).duasCasas());

              let carrinhoViewModel = response.carrinhoViewModel;

              $('[numero-itens]')
                  .html('Total: ' + carrinhoViewModel.itens.length + ' itens');

              $('[total]').html((carrinhoViewModel.total).duasCasas());

              if (itemPedido.quantidade == 0)
              {
                  linhaDoItem.remove();
              }

              //debugger;
          }); // done - recebe a resposta do servidor e atualiza a página
    }

}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function ()
{
    return this.toFixed(2).replace('.', ',');
}



