﻿namespace BE
{
    using System.Collections.Generic;

    public class Usuario
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Contraseña { get; set; }

        public string Email { get; set; }

        public int Telefono { get; set; }

        public int CIngresos { get; set; }

        public bool Activo { get; set; }

        public int IdCanalVenta { get; set; }

        public int DVH { get; set; }

        public int IdIdioma { get; set; }

        public bool PrimerLogin { get; set; }

        public Familia Familia { get; set; }

        public List<Patente> Patentes { get; set; }
    }
}
