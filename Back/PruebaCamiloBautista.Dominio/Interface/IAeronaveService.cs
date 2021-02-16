using PruebaCamiloBautista.Dominio.Modelos.Request;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaCamiloBautista.Dominio.Interface
{
   public interface IAeronaveService
    {
        public Reply GetAeronave();

        public Reply AddAeronave(AeronaveRequest model);

        public Reply EditAeronave(AeronaveRequest model);
        public Reply DeleteAeronave(AeronaveRequest model);
        public Reply GetAeronaveComp();

    }
}
