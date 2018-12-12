namespace BE.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Telefono { get; set; }

        public string NombreCompleto { get; set; }

        public string Email { get; set; }

        public string Domicilio { get; set; }

        public float Saldo { get; set; }

        public bool Activo { get; set; }
    }
}
