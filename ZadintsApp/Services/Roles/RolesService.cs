using App.Config;
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


            /*-------------------------------------------------
             * 
             * A partir de aqui entra SQl 1 donde el promer paso es buscar si
             * el buscar si el nombre del rol + correo existe en una linea de la
             * bases de datos. 
             * 
            --------------------------------------------------*/

            string commandBuscar = @"SELECT COUNT(1) FROM Roles WHERE Nombre = @Nombre AND UserMail = @UserMail";
            ListaSimple<ParametrosSQL> _listTemp = new ListaSimple<ParametrosSQL>();
            _listTemp.InsertarCola(new ParametrosSQL("@Nombre", nombre));
            _listTemp.InsertarCola(new ParametrosSQL("@UserMail", AppSetting.UsuarioPerfil.Correo));

            int CoincidenciasEncontradas = DatabaseService.DatabaseSearch(commandBuscar, _listTemp);

            if (CoincidenciasEncontradas > 0)
                return "El rol ya existe";

            /*-------------------------------------------------
            * 
            * A partir de aqui entra a la preparació nde datos para el
            * registro de datos en las tablas.
            * 
            *
            *
            *    Tabla1:
            *        Roles:
            +        -   Nombre
            *        -   Descripción
            *        -   PermisosID (Clave para relacionar)
            *       -   Color

            *    Tabla2:
            *        Permisos:
            *            -   PermisosID (Clave para relacionar)
            *            -   Venderpr....
            *
            --------------------------------------------------*/

            string permisosId = Guid.NewGuid().ToString();
            string correoActual = AppSetting.UsuarioPerfil.Correo;

            Rol nuevoRol = new Rol(nombre, color, descripcion, permisos, permisosId, correoActual);

            _role.InsertarCabeza(nuevoRol);
            

            string commandTabla1 =
                "INSERT INTO Roles (Nombre, Descripcion, PermisosId, Color, UserMail) VALUES (@Nombre ,@Descripcion, @PermisosId ,@Color, @UserMail)";
            ListaSimple<ParametrosSQL> sqlParamTabla1 = new ListaSimple<ParametrosSQL>();
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@Nombre", nombre));
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@Descripcion", descripcion));
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@PermisosId", permisosId));
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@Color", color));
            sqlParamTabla1.InsertarCola(new ParametrosSQL("@UserMail", correoActual));
            DatabaseService.DatabaseAction(commandTabla1, sqlParamTabla1);

 

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

        public static void CargarRoles(string correo)
        {
            _role = CustomService.ObtenerTodosLosRoles(correo);
        }

        

        public static string? EliminarRol(string permisosId)
        {
            string comandoEliminarRol = "DELETE FROM Roles WHERE PermisosId = @Id";

            ListaSimple<ParametrosSQL> parametrosSQL = new ListaSimple<ParametrosSQL>();
            parametrosSQL.InsertarCola(new ParametrosSQL("@Id", permisosId));
            int AccionesCompletas = DatabaseService.DatabaseAction(comandoEliminarRol, parametrosSQL);

            if (AccionesCompletas == 0)
                return "Error al eliminar el rol";


            //------------------------------------------------------------------------
            // gente no se confundan aqui es para limpiar toda la lista simple en este caso la
            // lista de tipo parametros.
            parametrosSQL.EliminarTodo();

            //------------------------------------------------------------------------

            string comandoEliminarPermisos = "DELETE FROM Permisos WHERE PermisosId = @Id";
            parametrosSQL.InsertarCola(new ParametrosSQL("@Id", permisosId));
            AccionesCompletas = DatabaseService.DatabaseAction(comandoEliminarPermisos, parametrosSQL);

            if (AccionesCompletas == 0) 
                return "Error al eliminar el permiso";


            /*-----------------------------------------------------------
             * Esto es lo mism ode la instancia de arriba en la clase
             * sol oque elimina el rol teniendo en cuenta su permisoID
            -----------------------------------------------------------*/
            var predicate = new Predicate<Rol>(p => p.permisosId == permisosId);
            _role.Eliminar(predicate);

            return null;
        }


        public static string? CambiarUsuarioRol(string nuevoRolNombre)
        {
            if(AppSetting.UsuarioPerfil.RolActual != null)
            {
                if (AppSetting.UsuarioPerfil.RolActual.Nombre == nuevoRolNombre)
                {
                    return "El rol actual ya lo tienes seleccionado";
                }
            }

            NodoSimple<Rol> actual = _role.Cabeza;

            Rol? entidadDelNuevoRol = null;

            while (actual != null)
            {
                if (actual.Dato.Nombre.Equals(nuevoRolNombre, StringComparison.OrdinalIgnoreCase))
                {
                    entidadDelNuevoRol = actual.Dato;
                    break;
                }
                actual = actual.Siguiente;
            }

            if (entidadDelNuevoRol == null) return "No se pudo asignar el rol al usuario porque no existe.";

            AppSetting.UsuarioPerfil.RolActual = entidadDelNuevoRol;

            return null;
        }

    }
}

