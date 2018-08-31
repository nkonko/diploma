namespace BE
{
    public class Usuario 
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contraseña { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public int cIngresos { get; set; }
        public bool activo { get; set; }
        public int idCanalVenta { get; set; }
        public int idIdioma { get; set; }
        public bool primerLogin { get; set; }
    }
}
