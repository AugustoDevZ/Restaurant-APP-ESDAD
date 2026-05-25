using System.Windows;
using Zrutas.UI.Views.Content;
using Zrutas.UI.Views.Frames;
using App.Config;
using App.Domain.Emun;

namespace App.Components.Views
{
    public partial class Dashboard : Window
    {
        private bool isRecording = false;
        public Dashboard()
        {
            InitializeComponent();
            frBody.Visibility = Visibility.Collapsed;
            frContent.Navigate(new Main());
        }
        /*-------------------------------------------
         * Sidebar Buttons Content
         ------------------------------------------------*/
        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new Main());
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
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

        

        private void btnDatabase_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new Database());
        }

        private void btnSelling_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new Selling());
        }

        private void btnNews_Click(object sender, RoutedEventArgs e)
        {

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
