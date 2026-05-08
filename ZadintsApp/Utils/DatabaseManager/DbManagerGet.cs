using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using Zrutas.Config;
using Zrutas.Domain.Entities.enumerated;

namespace ZadintsApp.Utils.DataManager
{
    internal class DbManagerGet
    {
        public static ThemeType DatabaseGetTeme()
        {
            if (!File.Exists(AppSetting.dbPath))
            {
                MessageBox.Show($"La base de datos {AppSetting.dbPath} no existe");
                return ThemeType.Noche;
            }

            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                conn.Open();

                string query = "SELECT Teme FROM AppPrivateSetting LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string? type = reader["Teme"].ToString();

                        if (type != null)
                        {
                            switch (type.ToLower())
                            {
                                case "mentolada":
                                    return ThemeType.Mentolada;
                                case "citrico":
                                    return ThemeType.Citrico;
                                case "nubarron":
                                    return ThemeType.Nubarron;
                                case "cerezo":
                                    return ThemeType.Cerezo;
                                case "pantera":
                                    return ThemeType.Pantera;
                                case"glaciar":
                                    return ThemeType.Glaciar;
                                case "bosque":
                                    return ThemeType.Bosque;
                                case "limonada":
                                    return ThemeType.Limonada;
                                case "aurora":
                                    return ThemeType.Aurora;
                                case "crepusculo":
                                    return ThemeType.Crepusculo;
                                default:
                                    return ThemeType.Noche;
                            }

                        
                        }
                    }

                    return ThemeType.Noche;
                }
            }
        }
    }
}
