using Dapper;
using ProyectoFinal_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal_API.Models
{
    public class LoginModel
    {
        public LoginObj? ValidarUsuario(LoginObj usuario, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                var datos = connection.Query<LoginObj>("ValidarUsuario",
                    new { usuario.Correo, usuario.Contrasenia }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (datos != null)
                {
                    usuario.Cedula = datos.Cedula;
                    usuario.Nombre = datos.Nombre;
                    usuario.PApellido = datos.PApellido;
                    usuario.SApellido = datos.SApellido;
                    usuario.IdRol = datos.IdRol;
                    usuario.Correo = datos.Correo;
                    usuario.Contrasenia = String.Empty;
                    usuario.Direccion = datos.Direccion;
                    usuario.Telefono = datos.Telefono;
                    return usuario;
                }
                
                return null;

            }
        }

    }
}
