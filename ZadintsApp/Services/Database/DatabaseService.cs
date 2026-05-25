using App.Config;
using App.Services.ListGeneral;
using System;
using App.Domain.Entities;
using System.Data.SQLite;
using System.Text;
using App.Domain.DataStructures.Nodo;

namespace App.Services.Database
{
    internal class DatabaseService
    {
        public static int DatabaseSet(string command, ListaSimple<ModelSqlParameter> list)
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
                            current.Dato.Name,
                            current.Dato.Value
                        );

                        current = current.Siguiente;
                    }

                    return cmd.ExecuteNonQuery();


                }
            }
        }

        public static string? DatabaseGiveDate(string command, ModelSqlParameter modelParameter)
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(command, conn))
                {

                    cmd.Parameters.AddWithValue(modelParameter.Name, modelParameter.Value);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader[0] == null)
                            {
                                return null;
                            }

                            return reader[0].ToString();
                        }
                        return null;
                    }
                }
            }
        }

        public static int DatabaseSearch(string command, ListaSimple<ModelSqlParameter> list)
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
                            current.Dato.Name,
                            current.Dato.Value
                        );
                        current = current.Siguiente;
                    }
                    var result = cmd.ExecuteScalar();

                    if (result == null || result == DBNull.Value)
                        return 0;

                    if (int.TryParse(result.ToString(), out int value))
                        return value;

                    return 0;
                }
            }
        }
    }
}
