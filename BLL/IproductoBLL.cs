namespace BLL
{
    using BE;

    public interface IProductoBLL : ICRUD<Producto>
    {
        void CargarProductos();
    }
}
