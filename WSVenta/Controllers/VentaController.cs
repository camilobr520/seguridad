using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models;
using WSVenta.Models.Request;
using WSVenta.Models.Response;
using WSVenta.Services;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {

        private IVentaService _venta;

        //en el constructor extraigo la inyeccion de VentaService, el framework la trae aotomaticamente, pues ya está registrada en starup 
        public VentaController(IVentaService venta)
        {
            this._venta = venta;
        }


        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                _venta.Add(model);
                respuesta.Success = 1;
            }
            catch (Exception ex)
            {
                respuesta.Message = ex.Message;
            }
            return Ok(respuesta);

        }
    }
}
