using App.Components.Layouts.Body;
using App.Components.Views;
using App.Config;
using App.Domain.Entities;
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
    /// Lógica de interacción para MenuPrincipalPage.xaml
    /// </summary>
    public partial class MenuPrincipalPage : Page
    {
        
        public MenuPrincipalPage()
        {
            InitializeComponent();
            ActualizarTop();
        }

        private void ActualizarTop()
        {
            DatosMenuPrincipal _datos = AppSetting.datosMenuPrincipal;
            _datos.ConvertVentas();

            lblVentasHoy.Text = _datos.VentasHoy.ToString();
            lblIngresoTotal.Text = _datos.IngresoTotal.ToString();
            lblVentasAyer.Text = _datos.VentasAyer.ToString();

            lblVentas1.Text = _datos.Ventas1;
            lblVentas2.Text = _datos.Ventas2;
            lblVentas3.Text = _datos.Ventas3;         
            lblVentas4.Text = _datos.Ventas4;

            bool IsNullOrWhiteSpaceProducto = false;


            if (string.IsNullOrWhiteSpace(_datos.Producto1))
            {
                btnTop1.IsEnabled = false;
                lblProducto1.Text = "--";
                IsNullOrWhiteSpaceProducto = true;
            }
            if (string.IsNullOrWhiteSpace(_datos.Producto2))
            {
                btnTop2.IsEnabled = false;
                lblProducto2.Text = "--";
                IsNullOrWhiteSpaceProducto = true;
            }
            if (string.IsNullOrWhiteSpace(_datos.Producto3))
            {
                btnTop3.IsEnabled = false;
                lblProducto3.Text = "--";
                IsNullOrWhiteSpaceProducto = true;
            }
            if (string.IsNullOrWhiteSpace(_datos.Producto4))
            {
                btnTop4.IsEnabled = false;
                lblProducto4.Text = "--";
                IsNullOrWhiteSpaceProducto = true;
            }

            if (!IsNullOrWhiteSpaceProducto)
            {
                lblProducto1.Text = _datos.Producto1;
                lblProducto2.Text = _datos.Producto2;
                lblProducto3.Text = _datos.Producto3;
                lblProducto4.Text = _datos.Producto4;
            }

        }

        private void Navigate()
        {
            Dashboard mainWindow = (Dashboard)Application.Current.MainWindow;
            mainWindow.frContent.Navigate(new VentasPage());
            mainWindow.frContent.Visibility = Visibility.Visible;
        }

        private void btnTop1_Click(object sender, RoutedEventArgs e)
        {
            Navigate();
        }   

        private void btnTop2_Click(object sender, RoutedEventArgs e)
        {
            Navigate();
        }

        private void btnTop3_Click(object sender, RoutedEventArgs e)
        {
            Navigate();
        }

        private void btnTop4_Click(object sender, RoutedEventArgs e)
        {
            Navigate();
        }
    }
}
