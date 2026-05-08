using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Zrutas.Domain.Entities.enumerated;

namespace Zrutas.Config
{
    public class AppSetting
    {
        public static ThemeType CurrentTheme { get; protected set; }
        public static int CurrentThemePost { get; protected set; }

        public const string AppName = "ZRutes";

        private static string exeDir = AppDomain.CurrentDomain.BaseDirectory;
        public static string dbPath = Path.Combine(exeDir, "Database", "UserData.db");
        public static string connectionString = $"Data Source={dbPath};Version=3;";



        public static String Transcripcion { internal set; get; }

    }
}
