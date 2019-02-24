namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VentaDAL : BaseDao, ICRUD<Venta>, IVentaDAL
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

        public int ObtenerUltimoIdVenta()
        {
            var queryString = "SELECT ISNULL(IDENT_CURRENT ('[dbo].[Venta]'), 0) as current_identity";

            var id = CatchException(() => Exec<int>(queryString.ToString()).FirstOrDefault());

            return (id != 0) ? id : 1;
        }

        public string ObtenerEstadoVentaConId(int estadoId)
        {
            switch (estadoId)
            {
                case 1: return EstadoVenta.Pendiente.ToString();
                case 2: return EstadoVenta.Aprobada.ToString();
                case 3: return EstadoVenta.Rechazada.ToString();
                case 4: return EstadoVenta.Cancelada.ToString();
            }

            return "Estado inexistente";
        }

        public string ObtenerTipoVentaConId(int tipoVtaId)
        {
            switch (tipoVtaId)
            {
                case 1: return TipoVenta.Seña.ToString();
                case 2: return TipoVenta.VentaSimple.ToString();
                case 3: return TipoVenta.Cliente.ToString();
                case 4: return TipoVenta.Devolucion.ToString();
            }

            return "Tipo inexistente";
        }

        public int ObtenerTipoVentaConString(string tipoVta)
        {
            switch (tipoVta)
            {
                case "Seña": return 1;
                case "VentaSimple": return 2;
                case "Cliente": return 3;
                case "Devolucion": return 4;
            }

            return 0;
        }

        public int ObtenerEstadoVentaConString(string estado)
        {
            switch (estado)
            {
                case "Pendiente": return 1;
                case "Aprobada": return 2;
                case "Rechazada": return 3;
                case "Cancelada": return 4;
            }

            return 0;
        }

        public enum TipoVenta
        {
            Seña = 1,
            VentaSimple,
            Cliente,
            Devolucion,
        }

        public enum EstadoVenta
        {
            Pendiente = 1,
            Aprobada,
            Rechazada,
            Cancelada,
        }
    }
}
