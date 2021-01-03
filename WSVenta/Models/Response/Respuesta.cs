using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.Models.Response
{
    public class Respuesta
    {
        public int Success { set; get; }
        public object Data { set; get; }
        public string Message { set; get; }

        public Respuesta()
        {
            // se inicializa en 0, solo se pasa a 1 cuando la consulta del api es exitoso
            this.Success = 0;
        }
    }
}
