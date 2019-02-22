namespace UI
{
    using System.Windows.Forms;

    public interface IDetalleVenta
    {
        Form MdiParent { get; set; }

        void Show();
    }
}
