namespace BLL
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IProductoBLL : ICRUD<Producto>
    {
        Producto ObtenerProductoPorCodigo(string codigo);

        List<Producto> CargarInactivos();

        bool ActivarProducto(string descripcion);

        bool DesactivarProducto(string descripcion);
    }
}
