namespace UI
{
    using BE.Entidades;
    using System.Windows.Forms;

    public interface IClientes
    {
        DialogResult ShowDialog();

        Cliente ObtenerClienteSeleccionado();
    }
}
