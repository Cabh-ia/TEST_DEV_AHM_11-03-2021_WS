using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceCRUDTokaMVC.Models.Request;
using WebServiceCRUDTokaMVC.Models.Response;
using WebServiceCRUDTokaMVC.Services;

namespace WebServiceCRUDTokaMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta<object> oRespuesta = new Respuesta<object>();
            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                oRespuesta.Exito = 0;
                oRespuesta.Mensaje = "Usuario o contraseña incorrectos";
                return BadRequest(oRespuesta);
            }

            oRespuesta.Exito = 1;
            oRespuesta.Data = userResponse;


            return Ok(oRespuesta);
        }
    }
}
