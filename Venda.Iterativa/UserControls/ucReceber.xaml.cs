using System.Reflection.Metadata;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Venda.Iterativa.Interfaces;
using Venda.Iterativa.Model;
using Venda.Iterativa.ViewModel;

namespace Venda.Iterativa.UserControls
{
    public partial class ucReceber : UserControl
    {

        private ucReceber(IObserver observer, PedidoModel pedido)
        {
            InitializeComponent();
            DataContext = new ReceberViewModel(this, observer, pedido);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        internal static PedidoModel Exibir(IObserver observer,
            PedidoModel pedido)
        {
            var tela = new ucReceber(observer, pedido);
            var vm = tela.DataContext as ReceberViewModel;

            vm.Notify();

            return vm.Pedido;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int tamanho = 0;

            if (string.IsNullOrEmpty(NumeroCartao.Text) || string.IsNullOrEmpty(CodigoCVV.Text) || string.IsNullOrEmpty(Mes.Text) || string.IsNullOrEmpty(Ano.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos!");
                return;
            }

            if(Int64.Parse(Mes.Text) > 12)
            {
                MessageBox.Show("Mes invalido, coloque um mes igual ou abaixo de 12");
                return;
            }

            int ano = Int32.Parse(Ano.Text);
            int anoatual = DateTime.Now.Year;

            if (ano < anoatual)
            {
                MessageBox.Show("O ano deve ser superior ou igual ao atual!");
                return;
            }

            tamanho = NumeroCartao.GetLineLength(tamanho);
            if (tamanho == 16) 
            {
                MessageBox.Show("Cartao de credito autorizado!");
                var window = Window.GetWindow(this);
            }
            else
            {
                MessageBox.Show("Cartao precisa ter o campo inteiro preenchido!");
            }
        }

    }
}