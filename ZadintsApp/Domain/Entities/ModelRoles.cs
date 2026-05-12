using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace App.Domain.Entities
{
    public class ModelRoles
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Permissions { get; set; }
        public String Color { get; set; }

        public ModelRoles(ModelRoles role)
        {
            this.Name = role.Name;
            this.Description = role.Description;
            this.Permissions = role.Permissions;
            this.Color = role.Color;
        }


    }
}
