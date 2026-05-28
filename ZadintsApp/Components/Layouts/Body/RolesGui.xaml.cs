using App.Components.Views;
using App.Domain.DataStructures.Nodo;
using App.Domain.Entities;
using App.Services.ESDAD;
using App.Services.Inventory;
using App.Services.Roles;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace App.Components.Layouts.Body
{
    /// <summary>
    /// Lógica de interacción para RolesGui.xaml
    /// </summary>
    public partial class RolesGui : Page
    {
        private int ContadorPermisos;
        public RolesGui()
        {
            InitializeComponent();
            MostrarRoles();
        }

        private void btnCloseRoleGui_Click(object sender, RoutedEventArgs e)
        {
            Dashboard mainWindow = (Dashboard)Application.Current.MainWindow;

            mainWindow.frBody.Content = null;
            mainWindow.frBody.Visibility = Visibility.Collapsed;
            
    
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cbxRolColor.IsDropDownOpen = true;
        }

        private void btnCrearRol_Click(object sender, RoutedEventArgs e)
        {
            string nombreRol = tbxNombreRol.Text;
            int colorRol = cbxRolColor.SelectedIndex;
            string descripcionRol = tbxDescripcioRol.Text;
            string contraseñaRol = tbxPasswordRol.Text;
            
            if(nombreRol.Contains("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("El nombre del rol no puede contener 'admin'");
                return;
            }

            Permisos permisos = new Permisos(
                EstaSeleccionado(cbxVenderProductos),
                EstaSeleccionado(cbxEliminarProductos),
                EstaSeleccionado(cbxAgregarProductos),
                EstaSeleccionado(cbxEditarProductos),
                EstaSeleccionado(cbxVerClientes)
            );

            if (ContadorPermisos == 0)
            {
                MessageBox.Show("Debes seleccionar al menos 1 permiso");
                return;
            }


            string? resultadoProceso = RolService.Insertar(nombreRol, colorRol, descripcionRol, permisos, contraseñaRol);

            if(resultadoProceso != null)
            {
                MessageBox.Show(resultadoProceso, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MostrarRoles();
        }

        private void MostrarRoles()
        {
            NodoSimple<Rol> actual = RolService._role.Cabeza;
            lstRolesExistentes.Items.Clear();
            while (actual != null)
            {
                lstRolesExistentes.Items.Add(actual.Dato);
                
                actual = actual.Siguiente;
            }

        }

        private bool EstaSeleccionado(CheckBox checkBox)
        {

            if (checkBox.IsChecked == true)
            {
                ContadorPermisos++;
                return true;
            }
            return false;


        }

        private void btnEliminarRol_Click(object sender, RoutedEventArgs e)
        {

            if (lstRolesExistentes.SelectedItem == null || !(lstRolesExistentes.SelectedItem is Rol))
            {
                MessageBox.Show("Selecciona un rol de la lista.", "Aviso");
                return;
            }

            Rol seleccionado = (Rol)lstRolesExistentes.SelectedItem;

            MessageBoxResult resultado = MessageBox.Show(
                "¿Eliminar \"" + seleccionado.Nombre + "\" del inventario?",
                "Confirmar",
                MessageBoxButton.YesNo);

            if (resultado == MessageBoxResult.Yes)
            {
                string? respuesta = RolService.EliminarRol(seleccionado.permisosId);
                if (respuesta != null)
                {
                    MessageBox.Show(respuesta, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MostrarRoles();
            }
        }

      
    }
}
