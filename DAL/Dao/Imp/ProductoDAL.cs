namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductoDAL : BaseDao, ICRUD<Producto>, IProductoDAL
    {
        public ProductoDAL()
        {
        }

        public bool Crear(Producto objAlta)
        {
            var queryString = "INSERT INTO Producto(Descripcion ,PUnitario, PVenta ,Stock ,MinStock, Activo) VALUES( @descripcion, @pUnitario,  @pVenta,  @stock, @minStock, @activo)";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @descripcion = objAlta.Descripcion,
                        @pUnitario = objAlta.PUnitario,
                        @pVenta = objAlta.PVenta,
                        @stock = objAlta.Stock,
                        @minStock = objAlta.MinStock,
                        @activo = 1
                    });
            });
        }

        public bool Borrar(Producto objDel)
        {
            var queryString = $"UPDATE Producto SET Activo = 0 WHERE ProductoId = @codigo";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @codigo = objDel.ProductoId
                    });
            });
        }

        public List<Producto> Cargar()
        {
            var queryString = "SELECT * FROM Producto WHERE Activo = 1;";

            return CatchException(() =>
            {
                return Exec<Producto>(queryString);
            });
        }

        public bool Actualizar(Producto objUpd)
        {
            var queryString = $"UPDATE Producto SET Descripcion = @descripcion, PUnitario = @pUnitario, PVenta = @pVenta, Stock = @stock, MinStock = @minStock WHERE ProductoId = @codigo";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @descripcion = objUpd.Descripcion,
                        @pUnitario = objUpd.PUnitario,
                        @pVenta = objUpd.PVenta,
                        @stock = objUpd.Stock,
                        @minStock = objUpd.MinStock,
                        @codigo = objUpd.ProductoId
                    });
            });
        }

        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            var queryString = $"SELECT * FROM Producto WHERE ProductoId = @codigo";

            return CatchException(() =>
            {
                return Exec<Producto>(queryString, new { @codigo = codigo }).FirstOrDefault();
            });
        }

        public List<Producto> CargarInactivos()
        {
            var queryString = "SELECT * FROM Producto WHERE Activo = 0;";

            return CatchException(() =>
            {
                return Exec<Producto>(queryString);
            });
        }

        public bool ActivarProducto(string productoId)
        {
            var queryString = $"UPDATE Producto SET Activo = 1 WHERE ProductoId = {productoId} ;";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool DesactivarProducto(string productoId)
        {
            var queryString = $"UPDATE Producto SET Activo = 0 WHERE ProductoId = {productoId} ;";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }
    }
}
