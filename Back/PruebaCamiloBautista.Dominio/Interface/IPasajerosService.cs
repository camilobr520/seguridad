using PruebaCamiloBautista.Dominio.Modelos.Request;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaCamiloBautista.Dominio.Interface
{
    public interface IPasajerosService
    {
        public Reply GetPasajeros(VuelosRequest model);
    }
}
