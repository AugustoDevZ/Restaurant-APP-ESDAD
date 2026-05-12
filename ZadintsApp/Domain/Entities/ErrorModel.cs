using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class ErrorModel
    {
        public  String Title { get; set; }
        public string Message { get; set; }

        public ErrorModel(string message, String title)
        {
            Message = message;
            if (String.IsNullOrWhiteSpace(title))
            {
                Title = "Error inesperado";
                return;
            }

            Title = title;
        }
    }
}
