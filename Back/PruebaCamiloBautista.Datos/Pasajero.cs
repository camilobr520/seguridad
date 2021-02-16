using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaCamiloBautista.Datos
{
    public partial class Pasajero
    {
        public int Id { get; set; }
        public int IdVuelo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdSexo { get; set; }

        public virtual Vuelo IdVueloNavigation { get; set; }
    }
}
