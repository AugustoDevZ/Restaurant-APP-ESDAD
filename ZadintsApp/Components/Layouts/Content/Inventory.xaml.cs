using App.Domain.Entities;
using App.Services.Inventory;
using System.Windows;
using System.Windows.Controls;

namespace Zrutas.UI.Views.Content
{
    /// <summary>
    /// Lógica de interacción para Inventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
        public Inventory()
        {
            InitializeComponent();
            RefrescarLista();
        }

        private void RefrescarLista()
        {
            InventarioService.CargarLista(LstPlatos);
            TxtTotal.Text = "Total de platos: " + InventarioService.ContarPlatos();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = TxtNombre.Text.Trim();
            string descripcion = TxtDescripcion.Text.Trim();
            string precioStr = TxtPrecio.Text.Trim();

            if (nombre == "Ej: Lomo Saltado") nombre = "";
            if (descripcion == "Ej: Con papas y arroz") descripcion = "";
            if (precioStr == "Ej: 25.00") precioStr = "";

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre del plato es obligatorio.", "Aviso");
                return;
            }

            if (!decimal.TryParse(precioStr, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingresa un precio válido.", "Aviso");
                return;
            }

            InventarioService.AgregarPlato(nombre, descripcion, precio);
            RefrescarLista();

            TxtNombre.Text = "Ej: Lomo Saltado";
            TxtNombre.Foreground = System.Windows.Media.Brushes.Gray;

            TxtDescripcion.Text = "Ej: Con papas y arroz";
            TxtDescripcion.Foreground = System.Windows.Media.Brushes.Gray;

            TxtPrecio.Text = "Ej: 25.00";
            TxtPrecio.Foreground = System.Windows.Media.Brushes.Gray;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (LstPlatos.SelectedItem == null || !(LstPlatos.SelectedItem is Plato))
            {
                MessageBox.Show("Selecciona un plato de la lista.", "Aviso");
                return;
            }

            Plato seleccionado = (Plato)LstPlatos.SelectedItem;

            MessageBoxResult resultado = MessageBox.Show(
                "¿Eliminar \"" + seleccionado.Nombre + "\" del inventario?",
                "Confirmar",
                MessageBoxButton.YesNo);

            if (resultado == MessageBoxResult.Yes)
            {
                InventarioService.EliminarPlato(seleccionado.Id);
                RefrescarLista();
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
