namespace ProyectoFinal_API.Entities
{
    public class ProductoObj
    {
        public string NOMPRODUCTO { get; set; } = String.Empty;
        public int PRECIO { get; set; } = 0;
        public int CANTDISPO { get; set; } = 0;
        public string DESCRIP { get; set; } = String.Empty;
        public string URL { get; set; } = String.Empty;
    }

    public class ProductoObj2
    {
        public int IdInventario { get; set; } = 0;
        public string NombreProducto { get; set; } = String.Empty;
        public int Precio { get; set; } = 0;
        public int CantDisponible { get; set; } = 0;
        public string DescripcionProducto { get; set; } = String.Empty;
        public string URLimagen { get; set; } = String.Empty;
    }
}
