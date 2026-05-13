using App.Components.Views;
using App.Config;
using App.Domain.Entities;
using App.Services.Theme;
using System.Windows;
using System.Windows.Controls;

namespace App.Components.Layouts.Body
{
    /// <summary>
    /// Lógica de interacción para ThemeSelector.xaml
    /// </summary>
    public partial class ThemeGui : Page
    {   
       
        public ThemeGui()
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

            ThemeManager.ChangeTheme(ThemeType.Mentolada, AppSetting.CurrentTheme);
        }

        private void btnThemeCitricos_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Citrico, AppSetting.CurrentTheme);
        }

        private void btnThemeNubarronRetro1_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Nubarron, AppSetting.CurrentTheme);
        }

        private void btnThemeCerezo_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Cerezo, AppSetting.CurrentTheme);
        }

        private void btnThemePantera_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Pantera, AppSetting.CurrentTheme);
        }

        private void btnThemeBosque_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Bosque, AppSetting.CurrentTheme);
        }

        private void btnThemeLimonada_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Limonada, AppSetting.CurrentTheme);
        }

        private void btnThemeGlaciar_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Glaciar, AppSetting.CurrentTheme);
        }

        private void btnThemeAurora_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Aurora, AppSetting.CurrentTheme);
        }

        private void btnThemeCrepusculo_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Crepusculo, AppSetting.CurrentTheme);
        }

        private void btnThemeNoche_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeTheme(ThemeType.Noche, AppSetting.CurrentTheme);
        }
    }
}
