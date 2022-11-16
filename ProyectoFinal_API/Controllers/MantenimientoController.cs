using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProyectoFinal_API.Entities;
using ProyectoFinal_API.Models;

namespace ProyectoFinal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : Controller
    {
        private readonly IConfiguration _configuration;

        BitacoraModel bitacoraM = new BitacoraModel();
        MantenimientoModel mantenimientoM = new MantenimientoModel();

        public MantenimientoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("OlvidoContrasenia")]
        public ActionResult<int> OlvidoContrasenia(LoginObj2 dato)
        {
            try
            {
                return Ok(mantenimientoM.OlvidoContrasenia(dato, _configuration));
            }
            catch (Exception ex)
            {

                return BadRequest("Se presentó un inconveniente");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ConsultarUsuario")]
        public ActionResult<UsuarioObj> ConsultarUsuario(UsuarioObj usuario)
        {
            try
            {
                return Ok(mantenimientoM.ConsultarUsuario(usuario, _configuration));
            }
            catch (Exception ex)
            {

                bitacoraM.RegistrarErrores(usuario.Cedula, ex, ControllerContext.ActionDescriptor.ActionName, _configuration);
                return BadRequest("Se presentó un inconveniente");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("ConsultarUsuarioPorCorreo")]
        public ActionResult<UsuarioObj> ConsultarUsuarioPorCorreo(UsuarioObj usuario)
        {
            try
            {
                return Ok(mantenimientoM.ConsultarUsuarioPorCorreo(usuario, _configuration));
            }
            catch (Exception ex)
            {

                bitacoraM.RegistrarErrores(usuario.Cedula, ex, ControllerContext.ActionDescriptor.ActionName, _configuration);
                return BadRequest("Se presentó un inconveniente");
            }

        }


        [AllowAnonymous]
        [HttpPost]
        [Route("RegistarProducto")]
        public ActionResult<int> RegistrarProducto(ProductoObj producto)
        {
            try
            {
                return Ok(mantenimientoM.RegistrarProducto(producto, _configuration));
            }
            catch (Exception ex)
            {
                return BadRequest("Se presentó un inconveniente");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CambiarContrasenia")]
        public ActionResult<int> CambiarContrasenia(LoginObj3 login)
        {
            try
            {
                return Ok(mantenimientoM.CambiarContrasenia(login, _configuration));
            }
            catch (Exception ex)
            {
                return BadRequest("Se presentó un inconveniente");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("EditarUsuario")]
        public ActionResult<int> EditarUsuario(UsuarioObj usuario)
        {
            try
            {
                return Ok(mantenimientoM.EditarUsuario(usuario, _configuration));
            }
            catch (Exception ex)
            {
                return BadRequest("Se presentó un inconveniente");
            }

        }
        [AllowAnonymous]
        [HttpGet]
        [Route("MostrarProductos")]
        public ActionResult<List<ProductoObj2>> MostrarProductos()
        {
            try
            {
                return Ok(mantenimientoM.MostrarProductos(_configuration));
            }
            catch (Exception ex)
            {

                return BadRequest("Se presentó un inconveniente");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("MostrarVentas")]
        public ActionResult<List<VentasObj>> MostrarVentas()
        {
            try
            {
                return Ok(mantenimientoM.MostrarVentas(_configuration));
            }
            catch (Exception ex)
            {

                return BadRequest("Se presentó un inconveniente");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("MostrarUnProducto")]
        public ActionResult<ProductoObj2> MostrarUnProducto(ProductoObj2 producto)
        {
            try
            {
                return Ok(mantenimientoM.MostrarUnProducto(producto, _configuration));
            }
            catch (Exception ex)
            {
                return BadRequest("Se presentó un inconveniente");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("EditarProducto")]
        public ActionResult<int> EditarProducto(ProductoObj2 producto)
        {
            try
            {
                return Ok(mantenimientoM.EditarProducto(producto, _configuration));
            }
            catch (Exception ex)
            {
                return BadRequest("Se presentó un inconveniente");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("EliminarProducto")]
        public ActionResult<int> EliminarProducto(ProductoObj2 producto)
        {
            try
            {
                return Ok(mantenimientoM.EliminarProducto(producto, _configuration));
            }
            catch (Exception ex)
            {
                return BadRequest("Se presentó un inconveniente");
            }
        }

    }
}
