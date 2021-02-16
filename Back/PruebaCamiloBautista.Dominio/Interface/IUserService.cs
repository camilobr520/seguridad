using PruebaCamiloBautista.Dominio.Modelos.Reply;
using System;
using System.Collections.Generic;
using System.Text;
using PruebaCamiloBautista.Dominio.Modelos.Request;
using WSVenta.Models.Request;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;

namespace PruebaCamiloBautista.Dominio.Interface
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);
        public Reply GetUser();
        public Reply AddUser(UserRequest model);

        public Reply GetRol();

        public Reply EditUser(UserRequest model);
        public Reply DeleteUser(UserRequest model);
    }
}
