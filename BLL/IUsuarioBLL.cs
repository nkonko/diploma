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

        List<Usuario> CargarInactivos();

        bool ActivarUsuario(string email);

        bool DesactivarUsuario(string email);

        List<Usuario> TraerUsuariosConPatentesYFamilias();
    }
}