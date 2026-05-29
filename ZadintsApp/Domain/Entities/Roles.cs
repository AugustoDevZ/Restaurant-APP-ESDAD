using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace App.Domain.Entities
{
    public class Rol
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string permisosId { get; set; }
        public Permisos Permisos { get; set; }
        public int Color { get; set; }

        public string Correo { get; set; }

        public Rol(string nombre, int color, string descripcion, Permisos permisos, string permisosId , string correo  )
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Color = color;
            this.Permisos = permisos;
            this.permisosId = permisosId;
            this.Correo = correo;
        }

        public override string ToString()
        {
            int contadorPermisos = 0;
            if (this.Permisos.VenderProductos is true) contadorPermisos++;
            if (this.Permisos.EliminarProductos is true) contadorPermisos++;           
            if (this.Permisos.AgregarProductos is true) contadorPermisos++;
            if (this.Permisos.EditarProductos is true) contadorPermisos++;
            if (this.Permisos.VerClientes is true) contadorPermisos++;


            switch (this.Color)
            {
                case 0:
                    return $"| Rol: [{this.Nombre}]    | Permisos Asignados: {contadorPermisos}📜    | Color: Rojo 🎨";
                case 1:
                    return $"| Rol: [{this.Nombre}]     | Permisos Asignados: {contadorPermisos}📜    | Color: Verde 🎨";
                case 2:
                    return $"| Rol: [{this.Nombre}]     | Permisos Asignados: {contadorPermisos}📜    | Color: Azul 🎨";
                default:
                    return $"| Rol: [{this.Nombre}]     | Permisos Asignados: {contadorPermisos}📜    | Color: Desconocido 🎨";
            }
        }


    }
}
        



