namespace UI
{
    using System.Windows.Forms;

    public interface IABMUsuario
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
