using Dapper;
using ProyectoFinal_API.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace ProyectoFinal_API.Models
{
    public class MantenimientoModel
    {

        public LoginObj2? OlvidoContrasenia(LoginObj2 dato, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                var datos = connection.Query<LoginObj2>("OlvidoContrasenia",
                    new { dato.Correo}, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (datos != null)
                {
                    dato.Contrasenia = datos.Contrasenia;

                    EnviarCorreo(dato);
                    dato.Contrasenia = String.Empty;

                    return dato;
                }

                return null;

            }
        }

        public void EnviarCorreo(LoginObj2 correo)
        {
            string servidor = "smtp.office365.com";
            int puerto = 587;
            string correoElectronico = "pharmacr506@outlook.com";
            string contrasenia = "Pharma123";

            SmtpClient client = new SmtpClient(servidor, puerto);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential(correoElectronico, contrasenia);

            MailAddress from = new MailAddress(correoElectronico, String.Empty, System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(correo.Correo);
            MailMessage message = new MailMessage(from, to);

            message.Body = "Su contraseña se actualizó exitosamente, su nueva contraseña es: " +correo.Contrasenia;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "Restrablecimiento de contraseña";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            client.Send(message);
        }


        public UsuarioObj? ConsultarUsuario(UsuarioObj usuario, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                var datos = connection.Query<UsuarioObj>("ConsultarUsuario",
                    new { usuario.Cedula}, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (datos != null)
                {
                    usuario.Cedula = datos.Cedula;
                    usuario.Nombre = datos.Nombre;
                    usuario.PApellido = datos.PApellido;
                    usuario.SApellido = datos.SApellido;
                    usuario.Correo = datos.Correo;
                    usuario.Direccion = datos.Direccion;
                    usuario.Telefono = datos.Telefono;
                    return usuario;
                }

                return null;

            }
        }

        public UsuarioObj? ConsultarUsuarioPorCorreo(UsuarioObj usuario, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                var datos = connection.Query<UsuarioObj>("ConsultarUsuarioPorCorreo",
                    new { usuario.Correo }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (datos != null)
                {
                    usuario.Cedula = datos.Cedula;
                    return usuario;
                }

                return null;

            }
        }


        public int RegistrarProducto(ProductoObj producto, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
               return connection.Execute("InsertarProducto",
                    new { producto.NOMPRODUCTO, producto.PRECIO, producto.CANTDISPO, producto.DESCRIP, producto.URL},
                    commandType: CommandType.StoredProcedure);
               

            }
        }

        public int CambiarContrasenia(LoginObj3 login, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Execute("CambiarContrasenia",
                     new { login.Cedula,login.Contrasenia},
                     commandType: CommandType.StoredProcedure);


            }
        }

        public int EditarUsuario(UsuarioObj usuario, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Execute("EditarUsuario",
                     new { usuario.Correo,usuario.Nombre,usuario.PApellido,usuario.SApellido,usuario.Telefono,usuario.Direccion},
                     commandType: CommandType.StoredProcedure);


            }
        }


        public List<ProductoObj2>? MostrarProductos(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                ProductoObj2 productos = new ProductoObj2();
                var datos = connection.Query<ProductoObj2>("MostrarProductos",
                    new { }, commandType: CommandType.StoredProcedure).ToList();
                List<ProductoObj2> list = new List<ProductoObj2>();
                if (datos != null)
                {
                    foreach (var item in datos)
                    {
                        list.Add(new ProductoObj2
                        {
                            IdInventario = item.IdInventario,
                            NombreProducto = item.NombreProducto,
                            Precio = item.Precio,
                            CantDisponible = item.CantDisponible,
                            DescripcionProducto = item.DescripcionProducto,
                            URLimagen = item.URLimagen
                        });
                    }

                    return list;
                }

                return null;

            }

        }

        public List<VentasObj>? MostrarVentas(IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                VentasObj productos = new VentasObj();
                var datos = connection.Query<VentasObj>("MostrarVentas",
                    new { }, commandType: CommandType.StoredProcedure).ToList();
                List<VentasObj> list = new List<VentasObj>();
                if (datos != null)
                {
                    foreach (var item in datos)
                    {
                        list.Add(new VentasObj
                        {
                            Idventa = item.Idventa,
                            IdFactura = item.IdFactura,
                            FechaReporte = item.FechaReporte,
                            Detalle = item.Detalle,
                            Total = item.Total
                        });
                    }

                    return list;
                }

                return null;

            }

        }
        public ProductoObj2? MostrarUnProducto(ProductoObj2 producto, IConfiguration stringConnection)
            {
             using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
             {
               var IDPRODUCTO = producto.IdInventario;
                 var datos = connection.Query<ProductoObj2>("MostrarUnProducto",
                     new { IDPRODUCTO }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                 if (datos != null)
                 {
                    producto.IdInventario = datos.IdInventario;
                    producto.NombreProducto = datos.NombreProducto;
                    producto.Precio = datos.Precio;
                    producto.CantDisponible = datos.CantDisponible;
                    producto.DescripcionProducto = datos.DescripcionProducto;
                    producto.URLimagen = datos.URLimagen;
                     return producto;
                 }

                return null;

           }
        }

        public int EditarProducto(ProductoObj2 producto, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
                return connection.Execute("EditarProducto",
                     new { producto.IdInventario, producto.NombreProducto, producto.Precio, producto.CantDisponible, producto.DescripcionProducto, producto.URLimagen },
                     commandType: CommandType.StoredProcedure);


            }
        }

        public int EliminarProducto(ProductoObj2 producto, IConfiguration stringConnection)
        {
            using (var connection = new SqlConnection(stringConnection.GetSection("ConnectionStrings:Connection").Value))
            {
               
                return connection.Execute("EliminarProducto",
                     new { producto.IdInventario },
                     commandType: CommandType.StoredProcedure);


            }
        }
    }
}

