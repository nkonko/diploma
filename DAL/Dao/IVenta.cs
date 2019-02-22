namespace DAL.Dao
{
    using BE;
    using BE.Entidades;

    public interface IVentaDAL : ICRUD<Venta>
    {
        int ObtenerUltimoIdVenta();
    }
}