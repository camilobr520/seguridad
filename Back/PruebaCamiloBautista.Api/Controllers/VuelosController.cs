using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PruebaCamiloBautista.Dominio.Interface;
using PruebaCamiloBautista.Dominio.Modelos.Request;

namespace PruebaCamiloBautista.Api.Controllers
{
    [ApiController]
    [Authorize]
    public class VuelosController : ControllerBase
    {
        private IVuelosService _vuelos;
        private IPasajerosService _pasajeros;
        public VuelosController(IVuelosService vuelos, IPasajerosService pasajeros)
        {
            this._vuelos = vuelos;
            this._pasajeros = pasajeros;
        }



        [HttpGet]
        [Route("api/vuelos")]
        public IActionResult GetVuelos()
        {
            return Ok(_vuelos.GetVuelos());
        }

        [HttpPost]
        [Route("api/addvuelo")]
        public IActionResult AddVuelo([FromBody] VuelosRequest model)
        {
            return Ok(_vuelos.AddVuelo(model));

        }

        [HttpPost]
        [Route("api/editvuelo")]
        public IActionResult EditVuelo([FromBody] VuelosRequest model)
        {
            return Ok(_vuelos.EditVuelo(model));

        }

        [HttpPost]
        [Route("api/deletevuelo")]
        public IActionResult DeleteVuelo([FromBody] VuelosRequest model)
        {
            return Ok(_vuelos.DeleteVuelo(model));

        }

        [HttpPost]
        [Route("api/getpasajeros")]
        public IActionResult GetPasajeros([FromBody] VuelosRequest model)
        {
            return Ok(_pasajeros.GetPasajeros(model));

        }

    }
}
