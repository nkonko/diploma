namespace BE.Entidades
{
    public class TraduccionFormulario
    {
        public int IdTraduccion { get; set; }

        public string Traduccion { get; set; }

        public Idioma Idioma { get; set; }

        public string ControlName { get; set; }

        public string MensajeCodigo { get; set; }
    }
}
