using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class ModelSqlParameter
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public ModelSqlParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }
            
    }
}
