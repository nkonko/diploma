namespace BLL
{
    using BE;
    using BE.Entidades;

    public interface IVentaBLL : ICRUD<Venta>
    {
        int ObtenerUltimoIdVenta();
    }
}