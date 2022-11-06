namespace ProyectoFinal_API.Entities
{
    public class VentasObj
    {
        public int Idventa { get; set; } = 0;
        public int IdFactura { get; set; } = 0;
        public DateTime FechaReporte { get; set; } = default(DateTime);
        public string Detalle { get; set; } = String.Empty;
        public int Total { get; set; } = 0;

    }
}
