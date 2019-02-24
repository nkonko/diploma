namespace DAL.Dao
{
    using BE;
    using BE.Entidades;

    public interface IVentaDAL : ICRUD<Venta>
    {
        int ObtenerUltimoIdVenta();

        string ObtenerEstadoVentaConId(int estadoId);

        string ObtenerTipoVentaConId(int tipoVtaId);

        int ObtenerEstadoVentaConString(string estado);

        int ObtenerTipoVentaConString(string tipoVta);
    }
}