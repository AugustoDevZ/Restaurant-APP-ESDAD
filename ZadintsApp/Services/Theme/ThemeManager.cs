using App.Config;
using App.Domain.DataStructures;
using App.Domain.Entities;
using App.Services.Database;
using App.Services.ListGeneral;
using System;
using System.IO.Packaging;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Documents;

namespace App.Services.Theme
{
    class ThemeManager: AppSetting
    {
        public static void ChangeTheme(ThemeType newTheme, ThemeType? oldTheme)
        {
            string? rutaNewTheme = null;
            string? rutaOldTheme = null;

            if (oldTheme is null)
            {
                rutaNewTheme = $@"Components\Ui\Theme\{newTheme.ToString()}.xaml";
                rutaOldTheme = $@"Components\Ui\Theme\Noche.xaml";
            }
            else
            {
                rutaNewTheme = $@"Components\Ui\Theme\{newTheme.ToString()}.xaml";
                rutaOldTheme = $@"Components\Ui\Theme\{oldTheme.ToString()}.xaml";
            }            

            var dictionaries = Application.Current.Resources.MergedDictionaries;
            var oldDict = dictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains(rutaOldTheme));
            try
            {
                if (oldDict is not null)
                {
                    dictionaries.Remove(oldDict);
                }

                var newDict = new ResourceDictionary();
                newDict.Source = new Uri(rutaNewTheme, UriKind.Relative);

                dictionaries.Add(newDict);
                DbManagerSet.DatabaseSetTeme(rutaNewTheme.ToString());
                AppSetting.CurrentTheme = newTheme;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar el tema: " + ex.Message);
            }


        }

    }
}
