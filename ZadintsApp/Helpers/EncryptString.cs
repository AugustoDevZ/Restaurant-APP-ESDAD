using System;
using System.Collections.Generic;
using System.Text;

namespace App.Helpers
{
    public class EncryptString
    {
        public static string Encrypt(string text)
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }

        public static bool Verify(string text, string encryptText)
        {
            return BCrypt.Net.BCrypt.Verify(text, encryptText);
        }

    }
}
