namespace UI
{
    using System.Windows.Forms;

    public interface IVtaProd
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
