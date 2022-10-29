using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_API.Entities;
using ProyectoFinal_API.Models;

namespace ProyectoFinal_API.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        LoginModel loginM = new LoginModel();
        BitacoraModel bitacoraM = new BitacoraModel();

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("ValidarUsuario")]
        public ActionResult<LoginObj> ValidarUsuario(LoginObj usuario)
        {
            try
            {
                return Ok(loginM.ValidarUsuario(usuario, _configuration));
            }
            catch (Exception ex)
            {

                bitacoraM.RegistrarErrores(usuario.Correo, ex, ControllerContext.ActionDescriptor.ActionName, _configuration);
                return BadRequest("Se presentó un inconveniente");
            }

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("RegistarUsuarioCliente")]
        public ActionResult<int> CrearUsuarioCliente(LoginObj usuario)
        {
            try
            {
                return Ok(loginM.RegistrarUsuarioCliente(usuario, _configuration));
            }
            catch (Exception ex)
            {
                bitacoraM.RegistrarErrores(usuario.Correo, ex, ControllerContext.ActionDescriptor.ActionName, _configuration);
                return BadRequest("Se presentó un inconveniente");
            }

        }

    }
}
