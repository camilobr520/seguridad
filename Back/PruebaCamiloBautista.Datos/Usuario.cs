using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaCamiloBautista.Datos
{
    public partial class Usuario
    {
        public Usuario()
        {
            VueloUsuarios = new HashSet<VueloUsuario>();
        }

        public int Id { get; set; }
        public int IdRoll { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<VueloUsuario> VueloUsuarios { get; set; }
    }
}
