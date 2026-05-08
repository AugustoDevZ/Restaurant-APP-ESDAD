using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Zrutas.Domain.DataStructures.Nodo;
using Zrutas.Domain.Entities.Nodo;

namespace ZadintsApp.Utils.DataStructures
{
    public class NewsManager
    {

        public NodoSimple<ModelNews> Head {get; set;}
        public NodoSimple<ModelNews> Last {get; set; }

        public NewsManager()
        {
            Head = null;
            Last = null;
        }

        public void NodoHeadInsertHead(ModelNews content)
        {
            NodoSimple<ModelNews> newNodo = new NodoSimple<ModelNews>(content);
            newNodo.Pointer = Head;
            Head = newNodo;

            if (Last is null)
            {
                Last = Head;
            }
        }

        public void NodoLastInsert(ModelNews content)
        {
            
            if (Head is null)
            {
                NodoHeadInsertHead(content);
                return;
            }

            NodoSimple<ModelNews> newNodo = new NodoSimple<ModelNews>(content);
            Last.Pointer = newNodo;
            Last = newNodo;

        }

        public int NodoSearch(long messageId)
        {
            if (Head == null)
                return -1;

            int position = 0;
            NodoSimple<ModelNews> current = Head;

            while (current != null)
            {
                if (current.Content.MessageID == messageId)
                {
                    return position;
                }
                current = current.Pointer;
                position++;
            }

            return -1;
        }




    }
}
