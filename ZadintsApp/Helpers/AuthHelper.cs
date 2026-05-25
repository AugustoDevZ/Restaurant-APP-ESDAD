using System.Net.Mail;

namespace App.Helpers
{
    public class AuthHelpers
    {
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address.Equals(email, StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public static string? IsValidPassword(string password)
        {
            if (password.Length <= 8) {
                return "La contraseña debe tener al menos 8 caracteres";
            }

            if (!password.Any(char.IsUpper) && !password.Any(char.IsDigit) && !password.Any(char.IsLower))
            {
                return "La contraseña no contiene todos los tipos de caracteres requeridos";
            }

            return null;

        }


    }
}
