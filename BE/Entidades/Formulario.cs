namespace BE.Entidades
{
    using System.Collections.Generic;

    public class Formulario
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public List<Patente> IdPatente { get; set; }
    }
}
