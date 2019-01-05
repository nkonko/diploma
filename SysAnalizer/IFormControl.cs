namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFormControl
    {
        IDictionary<string, string> Traducciones { get; set; }

        Idioma LenguajeSeleccionado { get; set; }

        List<Patente> ObtenerPermisosFormularios();

        List<Patente> ObtenerPermisosFormulario(int formId);

        void GuardarDatosSesionUsuario(Usuario usuario);

        Usuario ObtenerInfoUsuario();

        Usuario ObtenerPermisosUsuario();

        IDictionary<string, string> ObtenerTraducciones();

        Idioma ObtenerIdioma();
    }
}