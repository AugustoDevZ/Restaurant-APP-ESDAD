using App.Config;
using App.Domain.Entities;
using App.Helpers;
using App.Services.Database;
using App.Services.ESDAD;
using App.Services.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.PerfilUsuario
{
    public class ImagenService
    {
        public static string GuardarImagenPerfilUsuario(string ruta)
        {
            string base64 = Imagen.ConvertirABase64(ruta);              
            string comandoSQl = @"UPDATE Users SET UserImage = @UserImage WHERE UserMail = @UserMail";  
            
            ListaSimple<ParametrosSQL> parametrosSQL = new ListaSimple<ParametrosSQL>();
            parametrosSQL.InsertarCola(new ParametrosSQL("@UserImage", base64));
            parametrosSQL.InsertarCola(new ParametrosSQL("@UserMail", AppSetting.UsuarioPerfil.Correo));

            int respuestaDeActualizarDato = DatabaseService.DatabaseAction(comandoSQl, parametrosSQL);
            if (respuestaDeActualizarDato > 0)
            {
                AppSetting.UsuarioPerfil.Image = base64;
                return null;
            }
            else return "No se pudo actualizar la imagen";
        }

        public static string? ObtenerImagenPerfilUsuario(string correoDelPerfilActual)
        {
            string imagenBase64 = CustomService.ObtenerImagenUsuario(correoDelPerfilActual);

            if(imagenBase64 == null)
            {
                return "No se pudo obtener la imagen del usuario";
            }
            AppSetting.UsuarioPerfil.Image = imagenBase64;
            return null;
        }


        
    }
}
