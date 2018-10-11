namespace DAL
{
    using BE;
    using log4net;

    public interface IUsuarioDAL : ICRUD<Usuario>
    {
        ILog Log { get; }

        bool LogIn(string email, string contraseña);
    }
}