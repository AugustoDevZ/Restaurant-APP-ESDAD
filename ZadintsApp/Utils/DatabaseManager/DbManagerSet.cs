using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using Zrutas.Config;

namespace ZadintsApp.Utils.DataManager
{
    internal class DbManagerSet
    {
        public static void DatabaseSetTeme(string name)
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                conn.Open();

                string query = "INSERT OR REPLACE INTO AppPrivateSetting (ID, Teme) VALUES (@ID, @teme)";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@teme", name);
                    cmd.Parameters.AddWithValue("@ID", 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
