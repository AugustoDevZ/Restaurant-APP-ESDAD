using App.Config;
using App.Services.ESDAD;
using System;
using App.Domain.Entities;
using System.Data.SQLite;
using System.Text;
using App.Domain.DataStructures.Nodo;
using System.Windows;

namespace App.Services.Database
{
    internal class DatabaseService
    {
        public static int DatabaseAction(string command, ListaSimple<ParametrosSQL> Parametros)
        {
            try
            {
                using (var conn = new SQLiteConnection(AppSetting.connectionString))
                {
                    conn.Open();

                    using (var cmd = new SQLiteCommand(command, conn))
                    {
                        NodoSimple<ParametrosSQL> current = Parametros.Cabeza;

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
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar la consulta: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }


        

        public static string? DatabaseGiveDate(string command, ParametrosSQL parametros)
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(command, conn))
                {

                    cmd.Parameters.AddWithValue(parametros.Name, parametros.Value);

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

        
        public static int DatabaseSearch(string command, ListaSimple<ParametrosSQL> parametros)
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(command, conn))
                {
                    NodoSimple<ParametrosSQL> current = parametros.Cabeza;
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
