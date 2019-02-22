namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;

    public class DetalleVentaDAL : BaseDao, IDetalleVentaDAL, ICRUD<DetalleVenta>
    {
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
            var queryString = "SELECT * FROM DetalleVenta;";

            return CatchException(() =>
            {
                return Exec<DetalleVenta>(queryString);
            });
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
