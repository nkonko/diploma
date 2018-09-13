namespace DAL
{
    public interface IEncriptador
    {
        Encriptador ObtenerEncriptador();

        string Encriptar(string contraseña);

        string Desencriptar();
    }
}
