namespace UI
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IProvIdioma
    {
        void LeerRecursos(Control.ControlCollection controls);

        void LlenarRecursos(IDictionary<string, string> traducciones, int idiomaSeleccionado, string nombreFormulario);
    }
}