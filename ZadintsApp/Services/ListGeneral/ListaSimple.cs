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
            newNodo.Pointer = Head;
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

            Last.Pointer = newNodo;
            Last = newNodo;
        }
        public void Update(T content)
        {

        }

        public void Delete(T content)
        {

        }


    }
}
