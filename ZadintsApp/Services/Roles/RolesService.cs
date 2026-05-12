using App.Domain.DataStructures.Nodo;
using App.Domain.Entities;
using App.Services.Database;
using App.Services.ListGeneral;
using System;
using System.Data;

namespace App.Services.Roles
{
    public class RoleService
    {
        private readonly ListaSimple<ModelRoles> _role = new ListaSimple<ModelRoles>();
        public ErrorModel? Insert(ModelRoles content)
        {
            if (content == null)
                throw new ArgumentNullException("El valor ingresado a ModelRoles es nulo");

            if (content.Color is null) content.Color = "#FFFFFF";

            if (content.Permissions is null)
                return new ErrorModel("El valor ingresado a Permisos es nulo", null);


            _role.InsertHead(content);



            ListaSimple<ModelSqlParameter> sqlParam = new ListaSimple<ModelSqlParameter>();

            sqlParam.InsertLast(new ModelSqlParameter("@Name", content.Name));
            sqlParam.InsertLast(new ModelSqlParameter("@Description", content.Description));
            sqlParam.InsertLast(new ModelSqlParameter("@Permissions", content.Permissions));
            sqlParam.InsertLast(new ModelSqlParameter("@Color", content.Color));

            DbManagerSet.DatabaseSet
                ("INSERT INTO Roles (Name,Description, Permissions, Color) VALUES (@Name,@Description,  @Permissions,@Color)",
                sqlParam);

            return null;
        }



       

    }
}
