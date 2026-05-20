using App.Domain.DataStructures.Nodo;

namespace App.Services.ListGeneral
{
    public class ListaDoble<T>
    {
        public NodoDoble<T> Head { get; set; }
        public NodoDoble<T> Last { get; set; }

        public ListaDoble()
        {
            Head = null;
            Last = null;
        }

        public void InsertHead(T Content)
        {
            NodoDoble<T> newNodo = new NodoDoble<T>(Content);

            if (Head == null)
            {
                Head = Last = newNodo;
                newNodo.Siguiente = Head;
                newNodo.Anterior = Last;  
                return;
            }


            newNodo.Siguiente = Head;            
            newNodo.Anterior = Last;
            Head.Anterior = newNodo;
            Last.Siguiente = newNodo;
            Head = newNodo;
        }


        public void InsertLast(T Content)
        {
            NodoDoble<T> newNodo = new NodoDoble<T>(Content);
            if (Head == null)
            {
                Head = Last = newNodo;
                newNodo.Siguiente = Head;
                newNodo.Anterior = Last;
                return;
            }
            newNodo.Siguiente = Head;
            newNodo.Anterior = Last;
            Last.Siguiente = newNodo;
            Head.Anterior = newNodo;
            Last = newNodo;
        }

        


    }
}
