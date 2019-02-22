namespace BE.Entidades
{
    public class LineaDetalle
    {
        public Producto Producto { get; set; }

        public string DescProducto { get; set; }

        public int Cantidad { get; set; }

        public float Importe { get; set; }
    }
}