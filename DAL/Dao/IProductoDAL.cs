namespace DAL.Dao
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IProductoDAL
    {
        bool Actualizar(Producto objUpd);

        bool Borrar(Producto objDel);

        List<Producto> Cargar();

        bool Crear(Producto objAlta);

        Producto ObtenerProductoPorCodigo(string codigo);

        List<Producto> CargarInactivos();

        bool ActivarProducto(string descripcion);

        bool DesactivarProducto(string descripcion);
    }
}