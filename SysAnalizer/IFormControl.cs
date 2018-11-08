namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFormControl
    {
        List<Patente> ObtenerPermisosFormularios();

        List<Patente> ObtenerPermisosFormulario(int formId);

        void GuardarDatosSesionUsuario(Usuario usuario);

        Usuario ObtenerInfoUsuario();

        Usuario ObtenerPermisosUsuario();

        ////Dictionary<string, bool> AccesosUsuario();
    }
}