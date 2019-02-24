namespace UI
{
    using System.Windows.Forms;

    public interface ITraductor
    {
        void Traduccir(Control control, string nombreForm);

        string ObtenerPathRecursos();
    }
}