namespace ProyectoFinal_API.Entities
{
    public class FacturaObj
    {
        public string IDUSUARIO { get; set; } = String.Empty;

        public string Producto { get; set; } = String.Empty;

        public int CANTCOMPRADA { get; set; } = 0;

        public decimal Precio { get; set; } = 0;

        public decimal TOTAL_LINEA { get; set; } = 0;

        public int IDPRODUCTO { get; set; } = 0;
    }
}
