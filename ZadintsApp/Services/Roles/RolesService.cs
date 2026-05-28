using App.Domain.DataStructures.Nodo;
using App.Domain.Entities;
using App.Services.Database;
using App.Services.ESDAD;
using System.Security.RightsManagement;

namespace App.Services.Roles
{
    public class RolService
    {
        public static ListaSimple<Rol> _role = new ListaSimple<Rol>();

        public static string? Insertar(string nombre, int color, string descripcion, Permisos permisos, string contraseña)
        {
            if (_role.Contar() >= 3)
            {
                return "No se pueden crear más de 3 roles en el restaurante Ayllu.";
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {

                return "Por favor, ingresa un nombre para el rol.";
            }

            if (string.IsNullOrWhiteSpace(contraseña))
            {
                return "Por favor, ingresa una contraseña para el rol.";
            }

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                descripcion = "Un nuevo rol para el restaurante Ayllu";
            }

            if (color < 0 || color > 2)
            {
                return "Por favor, selecciona un color válido para el rol.";
            }




            string commandBuscar =
                "SELECT COUNT(1) FROM Roles WHERE Nombre = @Nombre";

            ListaSimple<ParametrosSQL> _listTemp = new ListaSimple<ParametrosSQL>();
            _listTemp.InsertarCola(new ParametrosSQL("@Nombre", nombre));

            int respuesta = DatabaseService.DatabaseSearch(commandBuscar, _listTemp);

            if (respuesta > 0)
                return "El rol ya existe";

            //--------------------------------------------------------

            string permisosId = Guid.NewGuid().ToString();

            Rol nuevoRol = new Rol(nombre, color, descripcion, permisos, permisosId);

            _role.InsertarCabeza(nuevoRol);

            //====================== Buscamos si existe  el rol

            string commandTabla1 =
                "INSERT INTO Roles (Nombre, Descripcion, PermisosId, Color) VALUES (@Nombre ,@Descripcion, @PermisosId ,@Color)";

            ListaSimple<ParametrosSQL> sqlParamTabla1 = new ListaSimple<ParametrosSQL>();
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@Nombre", nombre));
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@Descripcion", descripcion));
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@PermisosId", permisosId));
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@Color", color));

            DatabaseService.DatabaseAction(commandTabla1, sqlParamTabla1);

            /*------------------------------------------
             
             Hasta aqui llegamos simple gente, se creará 2 tablitas: 1 para introducir el rol y otra para
            introducir los permisos, se hará una relación entre ambas tablas a través de un 
            ID único llamado "permisosId".

            Tabla1:
                Roles:
                -   Nombre
                -   Descripción
                -   PermisosID (Clave para relacionar)
                -   Color

            Tabla2:
                Permisos:
                 -   PermisosID (Clave para relacionar)
                 -   Venderpr....
             -------------------------------------------------------*/


            string commandTabla2 =
                "INSERT INTO Permisos (PermisosId, VenderProductos, EliminarProductos, AgregarProductos, EditarProductos, VerClientes) VALUES (@PermisosId, @VenderProductos, @EliminarProductos, @AgregarProductos, @EditarProductos, @VerClientes)";

            ListaSimple<ParametrosSQL> sqlParamTabla2 = new ListaSimple<ParametrosSQL>();
            sqlParamTabla2.InsertarCola(new ParametrosSQL("@PermisosId", permisosId));
            sqlParamTabla2.InsertarCola(new ParametrosSQL("@VenderProductos", permisos.VenderProductos));
            sqlParamTabla2.InsertarCola(new ParametrosSQL("@EliminarProductos", permisos.EliminarProductos));
            sqlParamTabla2.InsertarCola(new ParametrosSQL("@AgregarProductos", permisos.AgregarProductos));
            sqlParamTabla2.InsertarCola(new ParametrosSQL("@EditarProductos", permisos.EditarProductos));
            sqlParamTabla2.InsertarCola(new ParametrosSQL("@VerClientes", permisos.VerClientes));

            DatabaseService.DatabaseAction(commandTabla2, sqlParamTabla2);

            return null;
        }

        public static void CargarRoles()
        {
            _role = CustomService.ObtenerTodosLosRoles();
        }

        public static string? EliminarRol(string permisosId)
        {
            ListaSimple<ParametrosSQL> sqlParams = new ListaSimple<ParametrosSQL>();

            string comandoEliminarRol = "DELETE FROM Roles WHERE PermisosId = @Id";           
            sqlParams.InsertarCola(new ParametrosSQL("@Id", permisosId));
            int respuesta = DatabaseService.DatabaseAction(comandoEliminarRol, sqlParams);

            if (respuesta == 0)
                return "Error al eliminar el rol";

            sqlParams.EliminarTodo();

            string comandoEliminarPermisos = "DELETE FROM Permisos WHERE PermisosId = @Id";
            sqlParams.InsertarCola(new ParametrosSQL("@Id", permisosId));
            respuesta = DatabaseService.DatabaseAction(comandoEliminarPermisos, sqlParams);

            if (respuesta == 0) 
                return "Error al eliminar el permiso";

            var predicate = new Predicate<Rol>(p => p.permisosId == permisosId);
            _role.Eliminar(predicate);

            return null;
        }

    }
}

