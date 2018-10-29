namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFormControl
    {
       List<Patente> ObtenerPermisosFormularios();

        void GuardarDatosSesionUsuario(Usuario usuario);

        Usuario ObtenerInfoUsuario();

        Usuario ObtenerPermisosUsuario();

        ////Dictionary<string, bool> AccesosUsuario();
    }
}