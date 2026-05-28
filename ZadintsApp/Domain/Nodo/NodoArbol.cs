using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Nodo
{
    class NodoArbol<T>
    {
        public NodoArbol<T> HijoIzquierdo { get; set; }
        public NodoArbol<T> HijoDerecho { get; set; }

        public T dato { get; set; }

        public NodoArbol(T dato)
        {
            this.dato = dato;
            HijoIzquierdo = null;
            HijoDerecho = null;
        }

        public bool EsHoja()
        {
            if (HijoIzquierdo is null && HijoDerecho is null)
            {
                return true;
            }
            return false;
        }
    }
}
