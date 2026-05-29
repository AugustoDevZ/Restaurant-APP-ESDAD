using App.Services.ESDAD;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string ProductosComprados { get; set; }
        public double DineroEgresado { get; set; }

        public Cliente(string nombre, string productosComprados, double dineroEgresado)
        {
            Nombre = nombre;
            ProductosComprados = productosComprados;
            DineroEgresado = dineroEgresado;
        }

        public override string ToString()
        {
            return $"Cliente: {Nombre}  |  Productos Comprados: {ProductosComprados}  |  Dinero Egresado: {DineroEgresado}";
        }
    }
}
