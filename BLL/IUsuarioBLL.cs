namespace BLL
{
    using BE;

    public interface IUsuarioBLL : ICRUD<Usuario>
    {
        bool LogIn(string email, string contraseña);
    }
}