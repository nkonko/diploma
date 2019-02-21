namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;
    using DAL.Utils;

    public class VentaDAL : BaseDao, ICRUD<Venta>, ICRUD<DetalleVenta>, IVentaDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public VentaDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Crear(Venta objAlta)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string>() { }, new List<int>() { });

            var queryString = "INSERT INTO Venta(Fecha, UsuarioId, EstadoId,TipoVentaId,ClienteId,Monto,DVH) VALUES (@fecha, @usuarioId, @estado, @tipoVenta, @cliente, @monto, @dvh)";
            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @fecha = objAlta.Fecha,
                        @estado = objAlta.EstadoId,
                        @usuarioId = objAlta.UsuarioId,
                        @tipoVenta = objAlta.TipoVentaId,
                        @cliente = objAlta.ClienteId,
                        @monto = objAlta.Monto,
                        @dvh = digitoVH
                    });
            });
        }

        public bool Borrar(Venta objDel)
        {
            var queryString = $"DELETE FROM Venta WHERE VentaId = {objDel.VentaId}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<Venta> Cargar()
        {
            var queryString = "SELECT * FROM Venta;";

            return CatchException(() =>
             {
                 return Exec<Venta>(queryString);
             });
        }

        public bool Actualizar(Venta objUpd)
        {
            var queryString = string.Format("UPDATE  WHERE IdVenta = {0}", objUpd.VentaId);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Crear(DetalleVenta objAlta)
        {
            foreach (var producto in objAlta.Productos)
            {
                var queryString = "INSERT INTO DetalleVenta ([DetalleId] ,[VentaId] ,[ProductoId] ,[Importe] ,[Cantidad]) VALUES (@detalleId, @ventaId, @productoId, @importe, @cantidad)";

                return CatchException(() =>
                {
                    return Exec(
                        queryString,
                        new
                        {
                            @detalleID = objAlta.VentaId,
                            @ventaId = objAlta.VentaId,
                            @productoId = producto.ProductoId,
                            @importe = objAlta.Importe,
                            @cantidad = objAlta.Cantidad
                        });
                });
            }

            return true;
        }

        List<DetalleVenta> ICRUD<DetalleVenta>.Cargar()
        {
            throw new System.NotImplementedException();
        }

        public bool Borrar(DetalleVenta objDel)
        {
            throw new System.NotImplementedException();
        }

        public bool Actualizar(DetalleVenta objUpd)
        {
            throw new System.NotImplementedException();
        }
    }
}
