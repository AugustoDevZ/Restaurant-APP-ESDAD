using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Permisos
    {
        public bool VenderProductos { get; set; }
        public bool EliminarProductos { get; set; }
        public bool AgregarProductos { get; set; }
        public bool EditarProductos { get; set; }
        public bool VerClientes { get; set; }

        public Permisos(bool venderProductos, bool eliminarProductos, bool agregarProductos, bool editarProductos, bool verClientes)
        {
            VenderProductos = venderProductos;
            EliminarProductos = eliminarProductos;
            AgregarProductos = agregarProductos;
            EditarProductos = editarProductos;
            VerClientes = verClientes;
        }

        public override string ToString()
        {
            return $"VenderProductos={VenderProductos}, EliminarProductos={EliminarProductos}, AgregarProductos={AgregarProductos}, EditarProductos={EditarProductos}, VerClientes={VerClientes}";
        }
    }
}
