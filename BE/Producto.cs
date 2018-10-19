namespace BE
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public int NroProd { get; set; }

        public string Descripcion { get; set; }

        public float PUnitario { get; set; }

        public float PVenta { get; set; }

        public int Stock { get; set; }

        public int MinStock { get; set; }
    }
}
