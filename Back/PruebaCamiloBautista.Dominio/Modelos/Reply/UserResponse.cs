using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaCamiloBautista.Dominio.Modelos.Reply
{
    public class UserResponse
    {
        public string Email { set; get; }
        public string Token { set; get; }

        public int IdRoll { get; set; }

        public string NombreRoll { get; set; }

    }
}
