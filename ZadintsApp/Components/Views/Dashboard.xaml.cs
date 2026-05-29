using App.Config;
using App.Services.Roles;
using App.Helpers;
using System.Windows;
using Zrutas.UI.Views.Content;
using Zrutas.UI.Views.Frames;
using App.Domain.DataStructures.Nodo;
using App.Domain.Entities;
using System.Windows.Controls;

namespace App.Components.Views
{
    public partial class Dashboard : Window
    {
        private bool isRecording = false;
        public Dashboard()
        {
            InitializeComponent();
            frBody.Visibility = Visibility.Collapsed;
            frContent.Navigate(new MenuPrincipalPage());
            imgAvatar.Source = Imagen.ObtenerDesdeBase64(AppSetting.UsuarioPerfil.Image);
        }
        /*-------------------------------------------
         * Sidebar Buttons Content
         ------------------------------------------------*/
        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new MenuPrincipalPage());
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new Products());
        }
        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new Inventory());

        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new Setting());
        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new VentasPage());
        }

        private void btnNews_Click(object sender, RoutedEventArgs e)
        {

        }
        /*----------------------------------
         Eventos para los roles
        ----------------------------------------*/

        public void MostrarBotonesSegunPermisos()
        {
            var Roles = AppSetting.UsuarioPerfil.RolActual;

            if (Roles == null)
            {
                btnClientes.IsEnabled = true;
                btnVender.IsEnabled = true;
                return;
            }

            
            var permisos = Roles.Permisos;
            CargarBotones(permisos);
            
        }

        private void CargarBotones(Permisos permisos)
        {
            IsEnabledButtons(btnVender, permisos.VenderProductos);
            IsEnabledButtons(btnClientes, permisos.VerClientes);
        }

        private void IsEnabledButtons(Button button, bool permiso)
        {
            if (!permiso)
            {
                button.IsEnabled = false;                
                return;
            }
            button.IsEnabled = true;
        }

        /*----------------------------------
         Eventos para los btones de cerrar sesión y app
        ----------------------------------------*/

        private void btnCloseSession_Click(object sender, RoutedEventArgs e)
        {
            Auth login = new Auth();
            Application.Current.MainWindow = login;

            login.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /*------------------------------------
         * Método del botón Anuncios , se encarga de mostrar las notificaciones a travez del tab 4 al usuario, 
         * se llama cada vez que el usuario hace click en el botón de novedades
         ------------------------------------*/
        private void Frame_Content(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

    }
}
