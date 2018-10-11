namespace DAL
{
    using BE;

    public interface IProductoDAL : ICRUD<Producto>
    {
        void CargarProductos();
    }
}
