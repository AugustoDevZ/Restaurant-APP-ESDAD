using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace Zrutas.Domain.DataStructures.Nodo
{
    public class NodoSimple<T>
    {
        public T Content { get; set; }

        public NodoSimple<T> Pointer { get; set; }

        public NodoSimple(T content)
        {
            Content = content;
            Pointer = null;
        }
    }
}


