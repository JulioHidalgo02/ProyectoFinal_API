﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_API.Entities;
using ProyectoFinal_API.Models;

namespace ProyectoFinal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                var datos = loginM.ValidarUsuario(usuario, _configuration);
                if (datos != null)
                    return Ok(datos);
                else
                    return BadRequest();
                
                
            }
            catch (Exception ex)
            {

                bitacoraM.RegistrarErrores(usuario.Cedula, ex, ControllerContext.ActionDescriptor.ActionName, _configuration);
                return BadRequest("Se presentó un inconveniente");
            }

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("RegistarUsuarioCliente")]
        public ActionResult<int> CrearUsuarioCliente(LoginObj2 usuario)
        {
            try
            {
                return Ok(loginM.RegistrarUsuarioCliente(usuario, _configuration));
            }
            catch (Exception ex)
            {
                
                return BadRequest("Se presentó un inconveniente");
            }

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("RegistarUsuarioAdministrador")]
        public ActionResult<int> CrearUsuarioAdministrador(LoginObj2 usuario)
        {
            try
            {
                return Ok(loginM.RegistrarUsuarioAdministrador(usuario, _configuration));
            }
            catch (Exception ex)
            {

                return BadRequest("Se presentó un inconveniente");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CrearContacto")]
        public ActionResult<int> CrearContacto(Contacto contacto)
        {
            try
            {
                return Ok(loginM.CrearContacto(contacto, _configuration));
            }
            catch (Exception ex)
            {
                return BadRequest("Se presentó un inconveniente");
            }

        }
    }
}
