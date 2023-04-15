using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Venda.Iterativa.Classes;
using Venda.Iterativa.ViewModel;

namespace Venda.Iterativa.Commands
{
    internal sealed class ExcluirProdutoPedidoCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;

            if (vm.ProdutoSelecionado == null)
            {
                MessageBox.Show("Selecione um produto para excluir");
                return;
            }
            vm.ProdutoSelecionado.Estoque += 1.00m;
            vm.Pedido.Produtos.Remove(vm.ProdutoSelecionado);
            vm.Pedido.Total = vm.Pedido.Produtos.Sum(x => x.Preco);
        }
    }
}
