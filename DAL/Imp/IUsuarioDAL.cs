namespace DAL
{
    using BE;
    using log4net;

    public interface IUsuarioDAL : ICRUD<Usuario>
    {
        ILog Logger { get; }

        bool LogIn(string email, string contraseña);
    }
}