namespace BE.Entidades
{
    using System.Collections.Generic;

    public class Familia
    {
        public int FamiliaId { get; set; }

        public string Descripcion { get; set; }

        public List<Patente> Patentes { get; set; }
    }
}
