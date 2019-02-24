namespace BLL
{
    using BE;
    using BE.Entidades;

    public interface IVentaBLL : ICRUD<Venta>
    {
        int ObtenerUltimoIdVenta();

        string ObtenerEstadoVenta(int estadoId);

        string ObtenerTipoVenta(int tipoVtaId);

        int ObtenerEstadoVentaConString(string estado);

        int ObtenerTipoVentaConString(string tipoVta);
    }
}