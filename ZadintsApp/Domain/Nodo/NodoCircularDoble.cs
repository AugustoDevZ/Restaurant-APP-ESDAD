using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;


namespace ZadintsApp.Domain.DataStructures
{
    public class NodoCircularDoble<T>
    {
        public T Dato { get; set; }

        public NodoCircularDoble<T> Siguiente { get; set; }
        public NodoCircularDoble<T> Anterior { get; set; }
        public NodoCircularDoble(T dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
    }
}


