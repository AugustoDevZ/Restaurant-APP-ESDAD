
using System.Windows;
using Zrutas.UI.Views;
using Zrutas.UI.Views.Content;
using Zrutas.UI.Views.Body;
using Zrutas.Utils.DataStructures;
using Zrutas.UI.Views.Frames;

namespace ZadintsApp.UI.Views
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

        //Source="{Binding UserImage}"
        //=============================[ Otras Opciones ] =============================
        /*

        private void ConfigurarMapa()
        {
            Mapa.MapProvider = GMapProviders.GoogleMap;
            Mapa.Position = new PointLatLng(-12.0464, -77.0428);
            Mapa.MinZoom = 2;
            Mapa.MaxZoom = 18;
            Mapa.Zoom = 13;
            Mapa.CanDragMap = true;
            Mapa.DragButton = System.Windows.Input.MouseButton.Left;
            Mapa.ShowCenter = false;
        }




        
        public void UpdateNews()
        {
            for (int i = 0; i < 2; i++)
            {
                GroupBox notification = new GroupBox();
                notification.Style = (Style)Application.Current.Resources["GbNotificationStyle"];


                Grid contentGrid = new Grid();

                Label lblTitle = new Label
                {
                    Content = $"Notificación {i + 1}",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(27, 0, 0, 0),
                    Width = 235,
                    FontSize = 10,
                    FontWeight = FontWeights.Light,
                    Foreground = (Brush)Application.Current.Resources["FontColor"],
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

                Label lblContent = new Label
                {
                    Content = $"Contenido {i + 1}",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(295, 0, 0, 0),
                    Width = 564,
                    FontSize = 10,
                    FontWeight = FontWeights.Light,
                    Foreground = (Brush)Application.Current.Resources["FontColor"],
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };

    
                Button btnDelete = new Button
                {
                    Background = Brushes.Transparent,
                    BorderBrush = Brushes.Transparent,
                    BorderThickness = new Thickness(1),
                    Cursor = Cursors.Hand,
                    Margin = new Thickness(1003, 4, 22, 5),
                    Template = (ControlTemplate)Application.Current.Resources["SidebarTemplate"]
                };

         
                Grid iconGrid = new Grid { Height = 13, Width = 12 };
                Path iconPath = new Path
                {
                    Data = System.Windows.Media.Geometry.Parse("M280 64 L240 120 L120 120 L120 152 L520 152 L520 120 L400 120 L360 64 Z M160 208 L160 512 A32 32 0 0 0 192 544 L448 544 A32 32 0 0 0 480 512 L480 208 M264 280 L264 456 M376 280 L376 456"),
                    Style = (Style)Application.Current.Resources["IconPathStyleRemove"]
                };
                iconGrid.Children.Add(iconPath);
                btnDelete.Content = iconGrid;

    
                contentGrid.Children.Add(lblTitle);
                contentGrid.Children.Add(lblContent);
                contentGrid.Children.Add(btnDelete);
                notification.Content = contentGrid;

 
                wrpDatabase.Children.Add(notification);
            }
        }
        */


        
        // ================================================================
        // ======================= Sidebar Buttons Content==========================
        // =================================================================
        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            frContent.Navigate(new Main());
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            
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
            frContent.Navigate(new News());
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
