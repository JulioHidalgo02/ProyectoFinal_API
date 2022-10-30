using Dapper;
using ProyectoFinal_API.Entities;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinal_API.Models
{
    public class BitacoraModel
    {
        public void RegistrarErrores(string cedula, Exception ex, string Accion, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {

                
                int Codigo = ex.HResult;
                string Mensaje = ex.Message;

                connection.Execute("RegistrarErrores",
                    new {cedula, Codigo, Mensaje, Accion }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
