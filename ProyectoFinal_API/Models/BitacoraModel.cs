using Dapper;
using ProyectoFinal_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal_API.Models
{
    public class BitacoraModel
    {
        public void RegistrarErrores(string Correo, Exception ex, string Accion, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {

                var datos = connection.Query<LoginObj>("ValidarUsuario",
                    new { Correo }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                int Codigo = ex.HResult;
                string Mensaje = ex.Message;

                connection.Execute("RegistrarErrores",
                    new { datos?.Cedula, Codigo, Mensaje, Accion }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
