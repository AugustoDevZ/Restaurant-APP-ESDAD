using App.Domain.DataStructures.Nodo;
using App.Domain.Nodo;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.ESDAD
{
    class ArbolesBinarios<T>
    {
        public NodoSimple<T> Raiz { get; set; }

        public void CrearRaiz(T dato)
        {
            if(Raiz != null)
            {
                throw new InvalidOperationException("La raíz ya existe.");
            }

            Raiz = new NodoSimple<T>(dato);
        }

        public void AgregarHijoIzquierdo(NodoArbol<T> padre, T dato)
        {
            if (padre == null)
            {
                throw new ArgumentNullException("El nodo no puede ser nulo.");
            }

            if (padre.HijoIzquierdo != null)
            {
                throw new InvalidOperationException("El hijo izquierdo ya existe.");
            }

            padre.HijoIzquierdo = new NodoArbol<T>(dato);
        }


    }
}
