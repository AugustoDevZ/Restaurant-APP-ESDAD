using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using App.Services.Database;
using App.Config;
using App.Domain.Entities;
using App.Services.Roles;
//using App.Services.Theme;


namespace ZadintsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
           
        }
        
    }

}
