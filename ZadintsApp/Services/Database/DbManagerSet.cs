using App.Config;
using App.Services.ListGeneral;
using System;
using App.Domain.Entities;
using System.Data.SQLite;
using System.Text;
using App.Domain.DataStructures.Nodo;

namespace App.Services.Database
{
    internal class DbManagerSet
    {
        /*
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
        */
        public static void DatabaseSet(string command, ListaSimple<ModelSqlParameter> list)
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                conn.Open();

                using (var cmd = new SQLiteCommand(command, conn))
                {
                    NodoSimple<ModelSqlParameter> current = list.Head;

                    while (current != null)
                    {
                        cmd.Parameters.AddWithValue(
                            current.Content.Name,
                            current.Content.Value
                        );

                        current = current.Pointer;
                    }

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
