namespace UI
{
    using System.Windows.Forms;

    public interface IClientes
    {
        DialogResult ShowDialog();
        object ObtenerClienteSeleccionado();
    }
}
