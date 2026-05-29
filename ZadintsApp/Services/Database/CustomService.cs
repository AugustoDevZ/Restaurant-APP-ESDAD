using App.Config;
using App.Domain.Entities;
using App.Services.ESDAD;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace App.Services.Database
{
    public class CustomService
    {
        public static string ObtenerImagenUsuario(string correo)
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                conn.Open();

                string query = "SELECT UserImage FROM Users WHERE UserMail = @UserMail";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserMail", correo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["UserImage"].ToString();
                        }
                    }
                }
            }

            return null;
        }

        public static ListaSimple<Rol> ObtenerTodosLosRoles(string correo)
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                ListaSimple<Rol> respuestaRoles = new ListaSimple<Rol>();

                conn.Open();
                string command = "SELECT * FROM Roles WHERE UserMail = @UserMail";
                using (var cmd = new SQLiteCommand(command, conn))
                {
                    cmd.Parameters.AddWithValue("@UserMail", correo);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {   
                            string _permisosId = reader["PermisosId"].ToString();

                            Rol _rol = new Rol
                            (
                                nombre: reader["Nombre"].ToString(),
                                color: Convert.ToInt32(reader["Color"]),
                                descripcion: reader["Descripcion"].ToString(),
                                permisosId: _permisosId,
                                permisos: ObtenerPermisos(conn, _permisosId),
                                correo: reader["UserMail"].ToString()
                            );
                            respuestaRoles.InsertarCabeza(_rol);
                        }

                        return respuestaRoles;
                    }
                }
            }
        }

        private static Permisos ObtenerPermisos(SQLiteConnection conn, string permisosId)
        {
            string command = "SELECT * FROM Permisos WHERE PermisosId = @PermisosId";

            using (var cmd = new SQLiteCommand(command, conn))
            {
                cmd.Parameters.AddWithValue("@PermisosId", permisosId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Permisos(
                            venderProductos: Convert.ToBoolean(reader["VenderProductos"]) == true,
                            eliminarProductos: Convert.ToBoolean(reader["EliminarProductos"]) == true,
                            agregarProductos: Convert.ToBoolean(reader["AgregarProductos"]) == true,
                            editarProductos: Convert.ToBoolean(reader["EditarProductos"]) == true,
                            verClientes: Convert.ToBoolean(reader["VerClientes"]) == true
                        );
                    }
                }
            }

            throw new Exception("No se encontraron permisos.");
        }
    }
}
