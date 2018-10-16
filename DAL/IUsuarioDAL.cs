namespace DAL
{
    using BE;
    using log4net;

    public interface IUsuarioDAL : ICRUD<Usuario>
    {
        bool LogIn(string email, string contraseña);

        bool CambiarPassword(Usuario usuario, string nuevaContraseña, bool primerLogin);

        Usuario ObtenerUsuarioConEmail(string email);
    }
}