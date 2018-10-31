namespace UI
{
    using BE.Entidades;
    using System.Windows.Forms;

    public interface IProductos
    {
        void Show();

        DialogResult ShowDialog();

        Producto GetProductoSeleccionado();
    }
}
