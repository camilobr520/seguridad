using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaCamiloBautista.Datos
{
    public partial class VueloUsuario
    {
        public int Id { get; set; }
        public int IdVuelo { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Vuelo IdVueloNavigation { get; set; }
    }
}
