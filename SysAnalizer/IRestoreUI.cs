namespace UI
{
    using System.Windows.Forms;

    public interface IRestoreUI
    {
        Form MdiParent { get; set; }

        void Show();
    }
}