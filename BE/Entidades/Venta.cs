namespace BE.Entidades
{
    using System;

    public class Venta
    {
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; }

        public int UsuarioId { get; set; }

        public int EstadoId { get; set; }

        public int TipoVentaId { get; set; }

        public int? ClienteId { get; set; }

        public float Monto { get; set; }
    }
}
