namespace UI
{
    using System.Windows.Forms;

    public interface IBitacora
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
