namespace BE.Entidades
{
    using System;

    public class LineaVenta
    {
        public DateTime Fecha { get; set; }

        public string NombreUsuario { get; set; }

        public string Estado { get; set; }

        public string TipoVenta { get; set; }

        public string Cliente { get; set; }

        public float Monto { get; set; }
    }
}
