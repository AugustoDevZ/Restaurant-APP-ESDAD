using System;
using System.Collections.Generic;
using System.Text;

namespace Zrutas.Domain.Entities.enumerated
{
    public enum ThemeType
    {
        Mentolada,
        Citrico,
        Nubarron,
        Cerezo,
        Pantera,
        Glaciar,
        Bosque,
        Limonada,
        Aurora,
        Crepusculo,
        Noche
    }


    public class ThemeModel
    {
        public ThemeType Theme { get; set; }
        public string Route { get; set; }

    }
}
