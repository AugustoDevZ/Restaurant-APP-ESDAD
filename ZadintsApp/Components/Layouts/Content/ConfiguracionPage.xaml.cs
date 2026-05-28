using App.Components.Layouts.Body;
using App.Components.Views;
using App.Config;
using App.Domain.DataStructures.Nodo;
using App.Domain.Entities;
using App.Helpers;
using App.Services.Roles;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
        }

        private void CargarImagen()
        {
            var imagen = ObtenerImagen.ImagenDesdeBase64(AppSetting.UsuarioPerfil.Image);
            imgPerfil.Source = imagen;
            mainWindow.imgAvatar.Source = imagen;
        }
        public void CargarDatos()
        {
            NodoSimple<Rol> actual = RolService._role.Cabeza;
            cbxCambiarRol.Items.Clear();
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

        private void btnImageCambiar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Title = "Seleccionar imagen";
            openFile.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFile.ShowDialog() == true)
            {
                string ruta = openFile.FileName;
                string base64 = ObtenerImagen.ImagenABase64(ruta);
                AppSetting.UsuarioPerfil.Image = base64;
                CargarImagen();

                //registrar imagen en db
            }
        }

        private void PreviewMouseDown_Click(object sender, MouseButtonEventArgs e)
        {
            CargarDatos();
        }

        private void cbxCambiarRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            string rol = cbxCambiarRol.SelectedItem?.ToString();
            MessageBox.Show("Seleccionó: " + rol);
        }
    }
}
