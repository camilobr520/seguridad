using PruebaCamiloBautista.Dominio.Modelos.Request;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaCamiloBautista.Dominio.Interface
{
    public interface IVuelosService
    {
        public Reply GetVuelos();
        public Reply AddVuelo(VuelosRequest model);
        public Reply EditVuelo(VuelosRequest model);
        public Reply DeleteVuelo(VuelosRequest model);

    }
}
