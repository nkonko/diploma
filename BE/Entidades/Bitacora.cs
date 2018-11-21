namespace BE.Entidades
{
    using System.Data.SqlTypes;

    public class Bitacora
    {
        public int IdLog { get; set; }

        public SqlDateTime Fecha { get; set; }

        public string Criticidad { get; set; }

        public string Actividad { get; set; }

        public string InformacionAsociada { get; set; }

        public string Usuario { get; set; }

        public int DVH { get; set; }
    }
}
