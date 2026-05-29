using App.Domain.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Zrutas.UI.Views.Content
{
    /// <summary>
    /// Lógica de interacción para Selling.xaml
    /// </summary>
    public partial class VentasPage : Page
    { 
        public VentasPage()
        {
            InitializeComponent();
            CargarProductos();
        }


       
        private void CargarProductos()
        {
           /*
            int id = 0;
            while (true)
            {
                NodoSimple<Plato>? nodo = InventarioService.ObtenerPlato(id);

                if (nodo == null)
                    break;
                AgregarCardProducto(
                    new Plato
                    {
                        Id = nodo.Dato.Id,
                        Nombre = nodo.Dato.Nombre,
                        Precio = nodo.Dato.Precio,
                        Descripcion = nodo.Dato.Descripcion
                    }
                );
                id++;
            }*/
        }

        private void AgregarCardProducto(Plato plato)
        {
            Button card = new Button();

            card.Width = 170;
            card.Height = 180;
            card.Margin = new Thickness(10);
            card.Cursor = Cursors.Hand;
            card.Background = Brushes.White;
            card.BorderBrush = Brushes.Transparent;

            StackPanel panel = new StackPanel();

            Image imagen = new Image();

            imagen.Height = 120;
            imagen.Margin = new Thickness(0, 0, 0, 10);

           

            TextBlock nombre = new TextBlock();

            nombre.Text = plato.Nombre;
            nombre.FontSize = 20;
            nombre.FontWeight = FontWeights.Bold;
            nombre.HorizontalAlignment = HorizontalAlignment.Center;

            TextBlock precio = new TextBlock();

            precio.Text = "S/ " + plato.Precio;
            precio.FontSize = 18;
            precio.Foreground = Brushes.Green;
            precio.HorizontalAlignment = HorizontalAlignment.Center;

            panel.Children.Add(imagen);
            panel.Children.Add(nombre);
            panel.Children.Add(precio);

            card.Content = panel;
            wpProductos.Children.Add(card);
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
