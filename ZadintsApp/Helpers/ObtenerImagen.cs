using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace App.Helpers
{
    public class ObtenerImagen
    {
        public static BitmapImage ImagenDesdeBase64(string base64)
        {
            byte[] bytes = Convert.FromBase64String(base64);

            using (var ms = new MemoryStream(bytes))
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = ms;
                img.EndInit();
                img.Freeze(); 
                return img;
            }
        }

        public static string ImagenABase64(string rutaImagen)
        {
            byte[] bytes = File.ReadAllBytes(rutaImagen);
            return Convert.ToBase64String(bytes);
        }
    }
}
