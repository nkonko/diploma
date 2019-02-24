namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;

    public class DetalleVentaDAL : BaseDao, IDetalleVentaDAL, ICRUD<DetalleVenta>
    {
        private readonly IProductoDAL productoDAL;

        public DetalleVentaDAL(IProductoDAL productoDAL)
        {
            this.productoDAL = productoDAL;
        }

        public bool Actualizar(DetalleVenta objUpd)
        {
            var queryString = string.Format("UPDATE  FROM DetalleVenta WHERE DetalleId = {0}", objUpd.VentaId);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Borrar(DetalleVenta objDel)
        {
            var queryString = $"DELETE FROM DetalleVenta WHERE VentaId = {objDel.VentaId}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<DetalleVenta> Cargar()
        {
            var detalleVenta = new List<DetalleVenta>();

            var queryString = "SELECT * FROM DetalleVenta;";

            var detalleBd = CatchException(() => Exec<DetalleVentaBd>(queryString));

            foreach (var detalle in detalleBd)
            {
                var producto = productoDAL.ObtenerProductoPorCodigo(detalle.ProductoId.ToString());

                detalleVenta.Add(
                    new DetalleVenta()
                    {
                        DetalleId = detalle.DetalleId,
                        VentaId = detalle.VentaId,
                        LineasDetalle = new List<LineaDetalle>()
                        {
                            new LineaDetalle()
                            {
                                Cantidad = detalle.Cantidad,
                                Importe = detalle.Importe,
                                Producto = producto ,
                                DescProducto = producto.Descripcion
                            }
                        }
                    });
            };

            return detalleVenta;
        }

        public bool Crear(DetalleVenta objAlta)
        {
            var queryString = "INSERT INTO DetalleVenta ([VentaId] ,[ProductoId] ,[Importe] ,[Cantidad]) VALUES (@ventaId, @productoId, @importe, @cantidad)";

            CatchException(() =>
            {
                foreach (var linea in objAlta.LineasDetalle)
                {
                    Exec(
                        queryString,
                        new
                        {
                            @ventaId = objAlta.VentaId,
                            @productoId = linea.Producto.ProductoId,
                            @importe = linea.Importe,
                            @cantidad = linea.Cantidad
                        });
                }
            });

            return true;
        }
    }
}
