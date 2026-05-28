using App.Config;
using App.Domain.DataStructures.Nodo;
using App.Domain.Entities;
using App.Services.ESDAD;
using System.Windows.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Services.Inventory
{
    public class InventarioService
    {
        private static ListaSimple<Plato> _listaPlatos = new ListaSimple<Plato>();
        private static int _contadorId = 1;
        

        public static void AgregarPlato(string nombre, string descripcion, decimal precio)
        {
            Plato plato = new Plato(_contadorId++, nombre, descripcion, precio);
            _listaPlatos.InsertarCabeza(plato);
            

        }

        public static NodoSimple<Plato> ObtenerPlato(int id)
        {
            if(_listaPlatos.Cabeza == null)
                return null;

            if (id <= 0)
                return  _listaPlatos.Cabeza;

            NodoSimple<Plato> actual = _listaPlatos.Cabeza;
            int cotador = 0;

            while (actual != null)
            {
                if (cotador == id)
                    return actual;

                actual = actual.Siguiente;
                cotador++;
            }

            return null;

        }

        public static bool EliminarPlato(int id)
        {
            int ventasHoy = AppSetting.datosMenuPrincipal.VentasHoy;
            if (ventasHoy > 0)
                AppSetting.datosMenuPrincipal.VentasHoy--;

            var predicate = new Predicate<Plato>(p => p.Id == id);
            return _listaPlatos.Eliminar(predicate);
        }

        public static void CargarLista(ListBox lista)
        {
            lista.Items.Clear();

            if (_listaPlatos.Cabeza == null)
            {
                lista.Items.Add("No hay platos registrados");
                return;
            }

            NodoSimple<Plato> actual = _listaPlatos.Cabeza;
            while (actual != null)
            {
                lista.Items.Add(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        public static int ContarPlatos()
        {
            int count = 0;
            NodoSimple<Plato> actual = _listaPlatos.Cabeza;
            while (actual != null)
            {
                count++;
                actual = actual.Siguiente;
            }
            return count;
        }
    }
}