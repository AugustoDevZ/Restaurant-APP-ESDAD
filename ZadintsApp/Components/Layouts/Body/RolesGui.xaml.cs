using App.Components.Views;
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

namespace App.Components.Layouts.Body
{
    /// <summary>
    /// Lógica de interacción para RolesGui.xaml
    /// </summary>
    public partial class RolesGui : Page
    {
        public RolesGui()
        {
            InitializeComponent();
        }

        private void btnCloseRoleGui_Click(object sender, RoutedEventArgs e)
        {
            Dashboard mainWindow = (Dashboard)Application.Current.MainWindow;

            mainWindow.frBody.Content = null;
            mainWindow.frBody.Visibility = Visibility.Collapsed;
        }
    }
}
