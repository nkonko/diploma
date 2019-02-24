namespace UI
{
    using BE.Entidades;
    using System.Windows.Forms;

    public interface IFamilias
    {
        Form MdiParent { get; set; }

        void Show();

        Familia ObtenerFamiliaSeleccionada();
    }
}
