using App.Domain.Entities;
using System.Windows.Controls;
using App.Domain.DataStructures.Nodo;
using App.Services.ListGeneral;

namespace App.Services.Inventory
{
    public class InventarioService
    {
        private static ListaSimple<Plato> _listaPlatos = new ListaSimple<Plato>();
        private static int _contadorId = 1;
        

        public static void AgregarPlato(string nombre, string descripcion, decimal precio)
        {
            Plato plato = new Plato(_contadorId++, nombre, descripcion, precio);
            _listaPlatos.InsertHead(plato);
        }



        public static bool EliminarPlato(int id)
        {
            var predicate = new Predicate<Plato>(p => p.Id == id);
            return _listaPlatos.Delete(predicate);
        }

        public static void CargarLista(ListBox lista)
        {
            lista.Items.Clear();

            if (_listaPlatos.Head == null)
            {
                lista.Items.Add("No hay platos registrados");
                return;
            }

            NodoSimple<Plato> actual = _listaPlatos.Head;
            while (actual != null)
            {
                lista.Items.Add(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        public static int ContarPlatos()
        {
            int count = 0;
            NodoSimple<Plato> actual = _listaPlatos.Head;
            while (actual != null)
            {
                count++;
                actual = actual.Siguiente;
            }
            return count;
        }
    }
}