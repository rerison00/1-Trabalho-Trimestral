using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Venda.Iterativa.Interfaces;
using Venda.Iterativa.ViewModel;

namespace Venda.Iterativa.UserControls
{
    public partial class ucListarProdutos : UserControl
    {

        public ucListarProdutos()
        {
            InitializeComponent();
        }

        private ucListarProdutos(IObserver observer)
        {
            InitializeComponent();
            DataContext = new ListarProdutosViewModel(this, observer);
        }

        internal static void Exibir(IObserver observer)
        {
            (new ucListarProdutos(observer).DataContext as ListarProdutosViewModel)
                .Notify();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }
    }
}