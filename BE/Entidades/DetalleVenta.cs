namespace BE.Entidades
{
    using System.Collections.Generic;

    public class DetalleVenta
    {
        public int DetalleId { get; set; }

        public int VentaId { get; set; }

        public Venta Venta { get; set; }

        public List<Producto> Productos { get; set; }

        public float Importe { get; set; }

        public int Cantidad { get; set; }
    }
}
