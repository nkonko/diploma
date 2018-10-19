namespace DAL.Dao
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IUsuarioDAL : ICRUD<Usuario>
    {
        bool LogIn(string email, string contraseña);

        bool CambiarPassword(Usuario usuario, string nuevaContraseña, bool primerLogin);

        Usuario ObtenerUsuarioConEmail(string email);

        List<Patente> ObtenerPatentesDeUsuario(int usuarioId);
    }
}