using System;
using System.Windows;
using ZadintsApp.Domain.DataStructures;
using ZadintsApp.Utils.DataManager;
using Zrutas.Config;
using Zrutas.Domain.Entities.enumerated;

namespace Zrutas.Utils.DataStructures
{
    class ThemeManager: AppSetting
    {
        
        public static NodoCircularDoble<ThemeModel> Cabeza { get; private set; }
        public static NodoCircularDoble<ThemeModel> Cola { get; private set; } 


        public ThemeManager()
        {
            Cabeza = null;
            Cola = null;
        }

        public static void InsertarFinal(ThemeModel theme)
        {
            NodoCircularDoble<ThemeModel> nuevoNodo = new NodoCircularDoble<ThemeModel>(theme);
            if (Cola == null)
            {
             
                Cabeza = Cola = nuevoNodo;
                nuevoNodo.Siguiente = Cabeza;
                nuevoNodo.Anterior = Cola;
                return;
            }
            
            nuevoNodo.Siguiente = Cabeza;
            nuevoNodo.Anterior = Cola;

            Cola.Siguiente = nuevoNodo;
            Cabeza.Anterior = nuevoNodo;

            Cola = nuevoNodo;
        }

   
        public static void InsertarInicio(ThemeModel theme)
        {
            NodoCircularDoble<ThemeModel> nuevoNodo = new NodoCircularDoble<ThemeModel>(theme);
            if (Cabeza == null)
            {

                Cabeza = Cola = nuevoNodo;
                nuevoNodo.Siguiente = Cabeza;
                nuevoNodo.Anterior = Cola;
                return;
            }

            nuevoNodo.Siguiente = Cabeza;
            Cabeza.Anterior = nuevoNodo;

            nuevoNodo.Anterior = Cola;
            Cola.Siguiente = nuevoNodo;
            Cabeza = nuevoNodo;
        }

        
        

        public static void ChangeTheme(ThemeType theme)
        
        
        {
            if (Cabeza == null) return;

            NodoCircularDoble<ThemeModel> actual = Cabeza;
            string ruta = "", ruta2 = "";
 

            if (actual.Dato.Theme.Equals(theme)) 
            {
                ruta = $@"UI\Styles\Theme\Noche.xaml";
                ruta2 = actual.Dato.Route.ToString();
            }
            else
            {
                while (actual.Siguiente != Cabeza)
                {
                    if (actual.Siguiente.Dato.Theme.Equals(theme))
                    {
                        ruta2 = actual.Siguiente.Dato.Route.ToString();
                        ruta = actual.Dato.Route.ToString();

                        Cabeza = actual.Siguiente;
                    }

                    actual = actual.Siguiente;
                }
            }

            if (String.IsNullOrWhiteSpace(ruta)) return;

            var dictionaries = Application.Current.Resources.MergedDictionaries;

            var oldDict = dictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains(ruta));

            if (oldDict is not null)
            {
                dictionaries.Remove(oldDict);
            }
            try
            {
                var newDict = new ResourceDictionary();
                newDict.Source = new Uri(ruta2, UriKind.Relative);

                dictionaries.Add(newDict);
                DbManagerSet.DatabaseSetTeme(theme.ToString());
                //MessageBox.Show($"Tema cambiado a {theme.ToString()}");
            }
            catch { return; }

            
        }
    }
}
