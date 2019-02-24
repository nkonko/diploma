namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IIdiomaBLL
    {
        List<Idioma> ObtenerTodosLosIdiomas();

        List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idiomaId, string nombreForm);

        void LlenarRecursos(IDictionary<string, string> traducciones, int idiomaSeleccionado, string nombreFormulario);

        void LeerRecursos(Control.ControlCollection controls);

        string ObtenerDirectorioRecursos();
    }
}
