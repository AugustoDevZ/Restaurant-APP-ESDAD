using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using App.Domain.Emun;
using App.Domain.Entities;

namespace App.Config
{
    public class AppSetting
    {
        /*----------------------------------
         Campos para la conexion SQL
        ----------------------------------------*/
        private static string exeDir = AppDomain.CurrentDomain.BaseDirectory;
        public static string dbPath = Path.Combine(exeDir, "Database", "UserData.db");
        public static string connectionString = $"Data Source={dbPath};Version=3;";

        /*----------------------------------
        * Campos para la sesion del user
        ----------------------------------------*/
        public static AuthStatus Session { get; set; } = AuthStatus.Closed;

    }
}
