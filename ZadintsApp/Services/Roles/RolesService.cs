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
        private static readonly ListaSimple<ModelRoles> _role = new ListaSimple<ModelRoles>();
        public static ErrorModel? Insert(ModelRoles content)
        {
            if (content == null)
                throw new ArgumentNullException("El valor ingresado a ModelRoles es nulo");

            if (content.Color is null) content.Color = "#FFFFFF";

            if (content.Permissions is null)
                return new ErrorModel("El valor ingresado a Permisos es nulo", null);


            _role.InsertHead(content);

            string command = "INSERT INTO Roles (Name,Description, Permissions, Color) VALUES (@Name,@Description,  @Permissions,@Color)";

            ListaSimple<ModelSqlParameter> sqlParam = new ListaSimple<ModelSqlParameter>();
            sqlParam.InsertLast(new ModelSqlParameter("@Name", content.Name));
            sqlParam.InsertLast(new ModelSqlParameter("@Description", content.Description));
            sqlParam.InsertLast(new ModelSqlParameter("@Permissions", content.Permissions));
            sqlParam.InsertLast(new ModelSqlParameter("@Color", content.Color));

            DatabaseService.DatabaseSet(command, sqlParam);

            return null;
        }



       

    }
}


/*
 
 
 
 
 
 <Application x:Class="ZadintsApp.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:App.Components.Views"
             StartupUri="Components/Views/Dashboard.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>

                <ResourceDictionary Source="/Components/Ui/Theme/Glaciar.xaml"/>
                <ResourceDictionary Source="/Components/Ui/Controls/GbNotification.xaml"/>
                <ResourceDictionary Source="/Components/Ui/Controls/DictionaryButtonsTheme.xaml"/>
                <ResourceDictionary Source="/Components/Ui/Controls/Combobox.xaml"/>
                <ResourceDictionary Source="/Components/Ui/Controls/ButtonsOne.xaml"/>
                <ResourceDictionary Source="/Components/Ui/Controls/ButtonsTwo.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
 
 
 
 
 
 
 */