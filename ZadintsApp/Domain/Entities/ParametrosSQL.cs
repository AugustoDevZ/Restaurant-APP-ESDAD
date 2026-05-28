using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class ParametrosSQL
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public ParametrosSQL(string name, object value)
        {
            Name = name;
            Value = value;
        }
            
    }
}
