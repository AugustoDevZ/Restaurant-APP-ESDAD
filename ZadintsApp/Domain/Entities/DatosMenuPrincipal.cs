using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class DatosMenuPrincipal
    {
        public int VentasHoy { get; set; }
        public int VentasAyer { get; set; }
        public double IngresoTotal { get; set; }


        public string Producto1 { get; set; }
        public string Producto2 { get; set; }
        public string Producto3 { get; set; }
        public string Producto4 { get; set; }


        public string Ventas1 { get; set; }
        public string Ventas2 { get; set; }
        public string Ventas3 { get; set; }
        public string Ventas4 { get; set; }


        public DatosMenuPrincipal()
        {
            VentasHoy = 0;
            VentasAyer = 0;
            IngresoTotal = 0.0;
        }

        public void ConvertVentas()
        {
            Ventas1 = evaluateVentas(Ventas1);
            Ventas2 = evaluateVentas(Ventas2);
            Ventas3 = evaluateVentas(Ventas3);
            Ventas4 = evaluateVentas(Ventas4);

            Producto1 = evaluateProductos(Producto1);
            Producto2 = evaluateProductos(Producto2);
            Producto3 = evaluateProductos(Producto3);
            Producto4 = evaluateProductos(Producto4);
        }

        private string evaluateVentas(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "--";
            }
            return value;
        }

        private string evaluateProductos(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return "";
            }
            return value;
        }
    }
}
