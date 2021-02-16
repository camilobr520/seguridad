using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PruebaCamiloBautista.Dominio.Interface;
using PruebaCamiloBautista.Dominio.Modelos.Request;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PruebaCamiloBautista.Api.Controllers
{
    
    [ApiController]
    [Authorize]
    public class PruebaController : Controller
    {
        private IAeronaveService _aeronave;
        private IUserService _userService;


        public PruebaController(IAeronaveService aeronave, IUserService userService)
        {
            this._aeronave = aeronave;
            _userService = userService;
        }

        [HttpGet]
        [Route("api/aeronave")]
        public IActionResult GetAeronave()
        {
            return Ok(_aeronave.GetAeronave());

        }

        [HttpGet]
        [Route("api/aeronavecomp")]
        public IActionResult GetAeronaveComp()
        {
            return Ok(_aeronave.GetAeronaveComp());

        }

        [HttpPost]
        [Route("api/addaeronave")]
        public IActionResult AddAeronave([FromBody] AeronaveRequest model)
        {
            return Ok(_aeronave.AddAeronave(model));

        }

        [HttpPost]
        [Route("api/editaeronave")]
        public IActionResult EditAeronave([FromBody] AeronaveRequest model)
        {
            return Ok(_aeronave.EditAeronave(model));

        }

        [HttpPost]
        [Route("api/deleteaeronave")]
        public IActionResult DeleteAeronave([FromBody] AeronaveRequest model)
        {
            return Ok(_aeronave.DeleteAeronave(model));

        }

        [HttpGet]
        [Route("api/getusuarios")]

        public IActionResult GetUser()
        {
            return Ok(_userService.GetUser());
        }

        [HttpGet]
        [Route("api/getroll")]
        public IActionResult GetRol()
        {
            return Ok(_userService.GetRol());
        }

        [HttpPost]
        [Route("api/addusuarios")]
        public IActionResult AddUsuarios([FromBody] UserRequest model)
        {
            return Ok(_userService.AddUser(model));

        }

        [HttpPost]
        [Route("api/editusuarios")]
        public IActionResult EditUsuarios([FromBody] UserRequest model)
        {
            return Ok(_userService.EditUser(model));

        }

        [HttpPost]
        [Route("api/deleteusuarios")]
        public IActionResult DeleteUsuarios([FromBody] UserRequest model)
        {
            return Ok(_userService.DeleteUser(model));

        }

    }
}

