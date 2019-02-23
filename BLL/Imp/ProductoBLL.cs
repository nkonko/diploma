namespace BLL
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ProductoBLL : ICRUD<Producto>, IProductoBLL
    {
        private readonly IProductoDAL productoDAL;

        private Regex obtenerInt = new Regex("\\d+");

        public ProductoBLL(IProductoDAL productoDAL)
        {
            this.productoDAL = productoDAL;
        }

        public bool Crear(Producto objAlta)
        {
            return productoDAL.Crear(objAlta);
        }

        public List<Producto> Cargar()
        {
            return productoDAL.Cargar();
        }

        public bool Borrar(Producto objDel)
        {
            return productoDAL.Borrar(objDel);
        }

        public bool Actualizar(Producto objUpd)
        {
            return productoDAL.Actualizar(objUpd);
        }

        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            return productoDAL.ObtenerProductoPorCodigo(codigo);
        }

        public List<Producto> CargarInactivos()
        {
            return productoDAL.CargarInactivos();
        }

        public bool ActivarProducto(string descripcion)
        {
            var productoId = obtenerInt.Match(descripcion).Value;

            return productoDAL.ActivarProducto(productoId);
        }

        public bool DesactivarProducto(string descripcion)
        {
            var productoId = obtenerInt.Match(descripcion).Value;

            return productoDAL.DesactivarProducto(productoId);
        }
    }
}
