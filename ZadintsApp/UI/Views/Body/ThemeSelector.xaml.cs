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
using ZadintsApp.UI.Views;
using Zrutas.Domain.Entities.enumerated;
using Zrutas.Utils.DataStructures;

namespace Zrutas.UI.Views.Body
{
    /// <summary>
    /// Lógica de interacción para ThemeSelector.xaml
    /// </summary>
    public partial class ThemeSelector : Page
    {
        public ThemeSelector()
        {
            InitializeComponent();
        }

        private void btnCloseThemeSelector_Click(object sender, RoutedEventArgs e)
        {
           Dashboard mainWindow = (Dashboard)Application.Current.MainWindow;

            mainWindow.frBody.Content = null;
            mainWindow.frBody.Visibility = Visibility.Collapsed;

        }







        private void btnThemeMentolada_Click(object sender, RoutedEventArgs e)
        {

            ThemeManager.ChangeTheme(ThemeType.Mentolada);
        }

        private void btnThemeCitricos_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Citrico);
        }

        private void btnThemeNubarronRetro1_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Nubarron);
        }

        private void btnThemeCerezo_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Cerezo);
        }

        private void btnThemePantera_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Pantera);
        }

        private void btnThemeBosque_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Bosque);
        }

        private void btnThemeLimonada_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Limonada);
        }

        private void btnThemeGlaciar_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Glaciar);
        }

        private void btnThemeAurora_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Aurora);
        }

        private void btnThemeCrepusculo_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Crepusculo);
        }

        private void btnThemeNoche_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Noche);
        }
    }
}
