namespace UI
{
    using System.Windows.Forms;

    public interface IBitacoraUI
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
