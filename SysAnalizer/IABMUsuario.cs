namespace UI
{
    using BE.Entidades;
    using System.Windows.Forms;

    public interface IABMUsuario
    {
        Form MdiParent { get; set; }

        void Show();

        Usuario ObtenerUsuarioSeleccionado();
    }
}
