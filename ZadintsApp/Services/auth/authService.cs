using App.Config;
using App.Domain.Entities;
using App.Helpers;
using App.Services.Database;
using App.Services.ESDAD;
using App.Services.PerfilUsuario;
using App.Services.Roles;
using System.IO.Packaging;
using System.Reflection.Metadata;

namespace App.Services.auth
{
    public class AuthService
    {
        public static string? Login(string userEmail, string password)
        {
            
            
            if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(password))
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
                if (aswer == null) return "El usuario no está registrado";

                if(!EncryptString.Verify(password, aswer))
                {
                    return "La contraseña o correo es incorrecta";
                }                
            }

            AppSetting.UsuarioPerfil.Correo = userEmail;
            RolService.CargarRoles(userEmail);
            ImagenService.ObtenerImagenPerfilUsuario(userEmail);
            return null;
        }

        private static string? ReturnPassword(string emailOrUsername)
        {
            string command = $"SELECT UserPassword FROM Users WHERE UserMail = @UserMail";

            ParametrosSQL sqlParam = new ParametrosSQL  ($"@UserMail", emailOrUsername);

            string? response = DatabaseService.DatabaseGiveDate(command, sqlParam);
            if (response == null) return null;
            return response;
        }


        private static bool ExistUserEmail(string email)
        {
            string command = "SELECT COUNT(*) FROM Users WHERE UserMail = @UserMail";

            ListaSimple<ParametrosSQL> sqlParam = new ListaSimple<ParametrosSQL>();
            sqlParam.InsertarCola(new ParametrosSQL("@UserMail", email));

            int response = DatabaseService.DatabaseSearch(command, sqlParam);
            if (response > 0) return true;
            return false;
        }


        
        

        public static string? Register(string userEmail, string password, string confirmPassword)
        {


            if (string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
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
            ListaSimple<ParametrosSQL> sqlParam = new ListaSimple<ParametrosSQL>();
            sqlParam.InsertarCola(new ParametrosSQL("@UserName", "User"));
            sqlParam.InsertarCola(new ParametrosSQL("@UserMail", userEmail));
            sqlParam.InsertarCola(new ParametrosSQL("@UserImage", AppSetting.UsuarioPerfil.Image));
            sqlParam.InsertarCola(new ParametrosSQL("@UserPassword", passwordEncrypted));

            int response = DatabaseService.DatabaseAction(command, sqlParam);

            if (response > 0){
                AppSetting.UsuarioPerfil.Correo = userEmail;
                RolService.CargarRoles(userEmail);
                return null;
            }
            else return "Error al registrar el usuario";
        }

    }
}
