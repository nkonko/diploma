namespace BLL
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class VentaBLL : ICRUD<Venta>, IVentaBLL
    {
        private readonly IVentaDAL ventaDAL;

        public VentaBLL(IVentaDAL ventaDAL)
        {
            this.ventaDAL = ventaDAL;
        }

        public bool Actualizar(Venta objUpd)
        {
            return ventaDAL.Actualizar(objUpd);
        }

        public bool Borrar(Venta objDel)
        {
            return ventaDAL.Borrar(objDel);
        }

        public List<Venta> Cargar()
        {
            return ventaDAL.Cargar();
        }

        public bool Crear(Venta objAlta)
        {
            return ventaDAL.Crear(objAlta);
        }

        public string ObtenerEstadoVenta(int estadoId)
        {
            return ventaDAL.ObtenerEstadoVentaConId(estadoId);
        }

        public int ObtenerEstadoVentaConString(string estado)
        {
            return ventaDAL.ObtenerEstadoVentaConString(estado);
        }

        public string ObtenerTipoVenta(int tipoVtaId)
        {
            return ventaDAL.ObtenerTipoVentaConId(tipoVtaId);
        }

        public int ObtenerTipoVentaConString(string tipoVta)
        {
            return ventaDAL.ObtenerTipoVentaConString(tipoVta);
        }

        public int ObtenerUltimoIdVenta()
        {
            return ventaDAL.ObtenerUltimoIdVenta();
        }
    }
}
