namespace BE
{
    using System;
    using System.Collections.Generic;

    public class FiltrosBitacora
    {
        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public List<string> IdsUsuarios { get; set; }

        public List<string> Criticidades { get; set; }
    }
}
