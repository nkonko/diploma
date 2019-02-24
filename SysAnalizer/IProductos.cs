namespace UI
{
    using BE.Entidades;
    using System.Windows.Forms;

    public interface IProductos
    {
        Form MdiParent { get; set; }

        void Show();

        DialogResult ShowDialog();

        Producto ObtenerProductoSeleccionado();
    }
}
