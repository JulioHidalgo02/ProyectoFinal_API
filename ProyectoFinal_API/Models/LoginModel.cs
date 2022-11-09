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
                    
                    return datos;
                }
                
                return null;

            }
        }

        public int RegistrarUsuarioCliente(LoginObj2 usuario, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Execute("CrearUsuarioCliente",
                    new { usuario.Cedula, usuario.Nombre, usuario.PApellido, usuario.SApellido, usuario.Telefono, usuario.Correo, usuario.Contrasenia, usuario.Direccion },
                    commandType: CommandType.StoredProcedure);

            }
        }

        public int RegistrarUsuarioAdministrador(LoginObj2 usuario, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Execute("CrearUsuarioAdministrador",
                    new { usuario.Cedula, usuario.Nombre, usuario.PApellido, usuario.SApellido, usuario.Telefono, usuario.Correo, usuario.Contrasenia, usuario.Direccion },
                    commandType: CommandType.StoredProcedure);

            }
        }

    }
}
