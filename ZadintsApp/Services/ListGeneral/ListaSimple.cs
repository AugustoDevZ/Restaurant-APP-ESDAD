using App.Domain.DataStructures.Nodo;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.ListGeneral
{
    class ListaSimple<T>
    {
        public NodoSimple<T> Head { get; set; }
        public NodoSimple<T> Last { get; set; }

        public void InsertHead(T content)
        {
            NodoSimple<T> newNodo = new NodoSimple<T>(content);
            newNodo.Siguiente = Head;
            Head = newNodo;
            if (Last is null)
            {
                Last = Head;
            }
        }

        public void InsertLast(T content)
        {
            NodoSimple<T> newNodo = new NodoSimple<T>(content);
            if (Head is null)
            {
                Head = newNodo;
                Last = newNodo;
                return;
            }

            Last.Siguiente = newNodo;
            Last = newNodo;
        }

        private T Search(Predicate<T> criterio)
        {           
            int count = 0;
            NodoSimple<T> current = Head;
            while (current != null)
            {
                if (criterio(current.Dato))
                {
                    return current.Dato;
                }
                current = current.Siguiente;
                count++;
            }
            return default(T);
        }

        public bool Delete(Predicate<T> criterio)
        {
            if(Head is null) return false;

            if (criterio(Head.Dato))
            {
                if(Head.Siguiente == null)
                {
                    Head = null;
                    return true;
                }

                Head = Head.Siguiente;
                return true;
            }

            NodoSimple<T> current = Head;

            while (current.Siguiente != null)
            {
                if(criterio(current.Siguiente.Dato))
                {
                    current.Siguiente = current .Siguiente.Siguiente;
                    return true;
                }
                current = current.Siguiente;

            }
            return false;
        }


    }
}
