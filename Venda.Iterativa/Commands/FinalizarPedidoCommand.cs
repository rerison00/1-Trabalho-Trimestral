using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Venda.Iterativa.Classes;
using Venda.Iterativa.UserControls;
using Venda.Iterativa.ViewModel;

namespace Venda.Iterativa.Commands
{
    internal sealed class FinalizarPedidoCommand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            try
            {
                var vm = parameter as ReceberViewModel;
                vm.Pedido = ucReceber
                    .Exibir(vm.MainUserControl, vm.Pedido);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
