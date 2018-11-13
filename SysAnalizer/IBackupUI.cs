namespace UI
{
    using System.Windows.Forms;

    public interface IBackupUI
    {
        Form MdiParent { get; set; }

        void Show();
    }
}