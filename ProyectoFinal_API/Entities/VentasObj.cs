namespace ProyectoFinal_API.Entities
{
    public class VentasObj
    {
        public int IdFactura { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = default(DateTime);
        public decimal Total { get; set; } = 0;

    }
}
