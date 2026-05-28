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
        public static ListaSimple<Rol> ObtenerTodosLosRoles()
        {
            using (var conn = new SQLiteConnection(AppSetting.connectionString))
            {
                ListaSimple<Rol> respuestaRoles = new ListaSimple<Rol>();

                conn.Open();
                string command = "SELECT * FROM Roles";
                using (var cmd = new SQLiteCommand(command, conn))
                {
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
                                permisos: ObtenerPermisos(conn, _permisosId)

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
                            venderProductos: Convert.ToInt32(reader["VenderProductos"]) == 1,
                            eliminarProductos: Convert.ToInt32(reader["EliminarProductos"]) == 1,
                            agregarProductos: Convert.ToInt32(reader["AgregarProductos"]) == 1,
                            editarProductos: Convert.ToInt32(reader["EditarProductos"]) == 1,
                            verClientes: Convert.ToInt32(reader["VerClientes"]) == 1
                        );
                    }
                }
            }

            throw new Exception("No se encontraron permisos.");
        }
    }
}
