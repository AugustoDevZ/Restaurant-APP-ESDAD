using App.Components.Layouts.Body;
using App.Components.Views;
using App.Config;
using App.Domain.DataStructures.Nodo;
using App.Domain.Entities;
using App.Helpers;
using App.Services.PerfilUsuario;
using App.Services.Roles;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Zrutas.UI.Views.Frames
{
    /// <summary>
    /// Lógica de interacción para Setting.xaml
    /// </summary>
    public partial class Setting : Page
    {
        Dashboard mainWindow = (Dashboard)Application.Current.MainWindow;

        public Setting()
        {

            InitializeComponent();
            CargarImagen();
            CargarDatos();
            ActualizarRolLabel();
        }

        private void CargarImagen()
        {
            var imagen = Imagen.ObtenerDesdeBase64(AppSetting.UsuarioPerfil.Image);
            imgPerfil.Source = imagen;
            mainWindow.imgAvatar.Source = imagen;
        }
        public void CargarDatos()
        {
            NodoSimple<Rol> actual = RolService._role.Cabeza;
            cbxCambiarRol.Items.Clear();
            cbxCambiarRol.Items.Add("[🛡️ Admin ]");
            while (actual != null)
            {
                cbxCambiarRol.Items.Add(actual.Dato.Nombre);

                actual = actual.Siguiente;
            }
        }

        private void btnRoles_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.frBody.Navigate(new RolesGui());
            mainWindow.frBody.Visibility = Visibility.Visible;            
        }

        private void ActualizarRolLabel()
        {
            var rolActual = AppSetting.UsuarioPerfil.RolActual;

            if (rolActual == null)
            {
                tbxRolActual.Text = "[🛡️ Admin ]";
                return;
            }

            tbxRolActual.Text = rolActual.Nombre;
        }

        private void btnImageCambiar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Title = "Seleccionar imagen";
            openFile.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFile.ShowDialog() == true)
            {
                string ruta = openFile.FileName;
                ImagenService.GuardarImagenPerfilUsuario(ruta);
                CargarImagen();
            }
        }

        private void PreviewMouseDown_Click(object sender, MouseButtonEventArgs e)
        {
            CargarDatos();
        }

        private void cbxCambiarRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string? rol = cbxCambiarRol.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(rol)) return;
            
            if (rol == "[🛡️ Admin ]")
            {
                if(AppSetting.UsuarioPerfil.RolActual == null)
                {
                    MessageBox.Show("No puedes elegir el rol que tienes actualmente");
                    return;
                }
                AppSetting.UsuarioPerfil.RolActual = null;
                ActualizarRolLabel();
                mainWindow.MostrarBotonesSegunPermisos();
                return;
            }


            string? HayError = RolService.CambiarUsuarioRol(rol);
            if (HayError != null)
            {
                MessageBox.Show(HayError + "Rol a intentar agregar:" + rol);
                return;
            }

            ActualizarRolLabel();

            mainWindow.MostrarBotonesSegunPermisos();
        }
    }
}
