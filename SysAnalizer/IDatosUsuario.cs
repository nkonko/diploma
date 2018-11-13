namespace UI
{
    using System.Windows.Forms;

    public interface IDatosUsuario
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
