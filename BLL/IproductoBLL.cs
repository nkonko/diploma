namespace BLL
{
    using BE;
    using BE.Entidades;

    public interface IProductoBLL : ICRUD<Producto>
    {
        Producto ObtenerProductoPorCodigo(string codigo);
    }
}
