using App.Domain.Entities;
using App.Services.Clientes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zrutas.UI.Views.Content
{
    /// <summary>
    /// Lógica de interacción para Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            string? clienteABuscar = tbxClienteABuscar.Text;
            if (string.IsNullOrWhiteSpace(clienteABuscar) || clienteABuscar.Contains("Nombre del cliente", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Ingresa el nombre del cliente a buscar");
                return;
            }

            Cliente clienteEncontrado = ClientesService.BuscarCliente(clienteABuscar);

            lstClientes.Items.Clear();
            lstClientes.Items.Add(clienteABuscar);
        }


        private void Ordenar_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb == rbOrdenarPorLetra)
            {
                MessageBox.Show("Letra");
            }
            else if (rb == rbOrdenarMayorEgresos)
            {
                MessageBox.Show("Egresos");
            }
            else if (rb == rbOrdenarMayorComprador)
            {
                MessageBox.Show("MayorComprador");
            }
            else
            {
                return;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == (string)tb.Tag)
            {
                tb.Text = "";
                tb.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = (string)tb.Tag;
                tb.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}
