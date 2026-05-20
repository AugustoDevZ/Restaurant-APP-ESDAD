using System.Windows;
using Zrutas.UI.Views;
using Zrutas.UI.Views.Content;
using App.Components.Layouts.Body;
using App.Services.Database;
using Zrutas.UI.Views.Frames;

namespace App.Components.Views
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private bool isRecording = false;
        public Dashboard()
        {
            InitializeComponent();
            
            frBody.Visibility = Visibility.Collapsed;
        }
        // ================================================================
        // ======================= Sidebar Buttons Content==========================
        // =================================================================
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
        private void btnCloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        // ================================================================
        // ======================= Oterns options Body ==========================
        // =================================================================

        private void btnNews_Click(object sender, RoutedEventArgs e)
        {
           
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
