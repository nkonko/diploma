namespace DAL
{
    public interface IEncriptador
    {
        string Encriptar(string contraseña);

        string Desencriptar();
    }
}
