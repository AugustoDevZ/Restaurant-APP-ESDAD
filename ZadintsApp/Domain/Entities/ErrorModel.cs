using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace App.Domain.Entities
{
    public class ErrorModel
    {
        public  String Title { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }

        public ErrorModel(string message, String title)
        {
            Message = message;
            if (String.IsNullOrWhiteSpace(title))
            {
                Title = "Error inesperado";
                return;
            }

            Title = title;
            ColorValue();
        }

        private void ColorValue()
        {
            if (Title.Contains("Error", StringComparison.OrdinalIgnoreCase))
            {
                Color = "#FF3B3B";
            }
            else if (Title.Contains("Aviso", StringComparison.OrdinalIgnoreCase ))
            {
                Color = "#EACE3A";
            }
            else if (Title.Contains("Éxito", StringComparison.OrdinalIgnoreCase) || Title.Contains("Correcto", StringComparison.OrdinalIgnoreCase))
            {
                Color = "#4CA64C";
            }
            else
            {
                Color = "#A5A5D2";
            }
        }
    }
}
