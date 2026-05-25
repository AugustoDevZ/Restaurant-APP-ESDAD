using App.Domain.Entities;
using App.Helpers;
using App.Services.Database;
using App.Services.ListGeneral;
using System.IO.Packaging;
using System.Reflection.Metadata;

namespace App.Services.auth
{
    public class AuthService
    {
        public static string? Login(string userEmail, string password)
        {
            
            
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(password))
            {
                return "Ingresa todos los datos";
            }


            if(!userEmail.Contains("@"))
            {
                return "El correo electrónico no es válido";
            }

            if (AuthHelpers.IsValidEmail(userEmail))
            {
                string? aswer = ReturnPassword(userEmail);
                if (aswer == null) return "El correo electrónico no se pudo encontrar";

                if(!EncryptString.Verify(password, aswer))
                {
                    return "La contraseña o correo es incorrecta";
                }                
            }

            return null;
        }

        private static string? ReturnPassword(string emailOrUsername)
        {
            string command = $"SELECT UserPassword FROM Users WHERE UserMail = @UserMail";

            ModelSqlParameter sqlParam = new ModelSqlParameter($"@UserMail", emailOrUsername);

            string? response = DatabaseService.DatabaseGiveDate(command, sqlParam);
            if (response == null) return null;
            return response;
        }


        private static bool ExistUserEmail(string email)
        {
            string command = "SELECT COUNT(*) FROM Users WHERE UserMail = @UserMail";

            ListaSimple<ModelSqlParameter> sqlParam = new ListaSimple<ModelSqlParameter>();
            sqlParam.InsertLast(new ModelSqlParameter("@UserMail", email));

            int response = DatabaseService.DatabaseSearch(command, sqlParam);
            if (response > 0) return true;
            return false;
        }


        


        public static string? Register(string userEmail, string password, string confirmPassword)
        {


            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                return "Ingresa todos los datos";
            }

            if (password != confirmPassword)
            {
                return "Las contraseñas no coinciden";
            }

            if (password != confirmPassword)
            {
                return "Las contraseñas no coinciden";
            }

            string? responsePassword = AuthHelpers.IsValidPassword(password);

            if (responsePassword != null)
            {
                return responsePassword;
            }

            if (!AuthHelpers.IsValidEmail(userEmail))
            {
                return "El correo electrónico no es válido";
            }
            

            if(ExistUserEmail(userEmail))
            {
                return "El correo electrónico ya está registrado";
            }

            string passwordEncrypted = EncryptString.Encrypt(password);

            string command = "INSERT INTO Users (UserName ,UserMail, UserImage, UserPassword) VALUES (@UserName ,@UserMail, @UserImage, @UserPassword)";
;
            ListaSimple<ModelSqlParameter> sqlParam = new ListaSimple<ModelSqlParameter>();
            sqlParam.InsertLast(new ModelSqlParameter("@UserName", "User"));
            sqlParam.InsertLast(new ModelSqlParameter("@UserMail", userEmail));
            sqlParam.InsertLast(new ModelSqlParameter("@UserImage", ""));
            sqlParam.InsertLast(new ModelSqlParameter("@UserPassword", passwordEncrypted));

            int response = DatabaseService.DatabaseSet(command, sqlParam);

            if (response > 0) return null;
            else return "Error al registrar el usuario";
        }

    }
}
