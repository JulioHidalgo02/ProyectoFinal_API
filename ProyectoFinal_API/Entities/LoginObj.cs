namespace ProyectoFinal_API.Entities
{
    public class LoginObj
    {
        public string Cedula { get; set; } = String.Empty;
        public string Correo { get; set; } = String.Empty;
        public string Contrasenia { get; set; } = String.Empty;
        public string Nombre { get; set; } = String.Empty;
        public string PApellido { get; set; } = String.Empty;
        public string SApellido { get; set; } = String.Empty;
        public string Telefono { get; set; } = String.Empty;
        public string Direccion { get; set; } = String.Empty;
        public int IdRol { get; set; } = 0;
    }
}
