using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaCamiloBautista.Dominio.Interface;
using PruebaCamiloBautista.Dominio.Modelos.Request;
using PruebaCamiloBautista.Dominio.Modelos.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models.Request;
using Microsoft.AspNetCore.Authorization;

namespace PruebaCamiloBautista.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Reply respuesta = new Reply();
            var userresponse = _userService.Auth(model);
            if (userresponse == null)
            {
                respuesta.Message = "Usuario o contraseña incorrecto";
                respuesta.Success = 0;
                return Ok(respuesta);
            }
            respuesta.Success = 1;
            respuesta.Data = userresponse;
            return Ok(respuesta);
        }

        
    }
}

