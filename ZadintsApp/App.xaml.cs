using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using ZadintsApp.Utils.DataManager;
using Zrutas.Config;
using Zrutas.Domain.Entities.enumerated;
using Zrutas.Utils.DataStructures;


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

            ThemeType actualTheme = DbManagerGet.DatabaseGetTeme();

            foreach (ThemeType theme in Enum.GetValues<ThemeType>())
            {
                ThemeModel themeModel = new ThemeModel();
                themeModel.Theme = theme;
                themeModel.Route = $@"UI\Styles\Theme\{theme.ToString()}.xaml";

                if (theme == actualTheme)
                {
                    ThemeManager.InsertarInicio(themeModel);
                    continue;
                }

                ThemeManager.InsertarFinal(themeModel);
            }

            ThemeManager.ChangeTheme(actualTheme);
        }


        



    }

}
