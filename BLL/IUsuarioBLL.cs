namespace BLL
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IUsuarioBLL : ICRUD<Usuario>
    {
        bool LogIn(string email, string contraseña);

        Usuario ObtenerUsuarioConEmail(string email);

        List<Patente> ObtenerPatentesDeUsuario(int usuarioId);
    }
}