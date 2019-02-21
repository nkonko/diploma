namespace BLL
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class VentaBLL : ICRUD<Venta>, ICRUD<DetalleVenta>, IVentaBLL
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

        public bool Actualizar(DetalleVenta objUpd)
        {
            throw new System.NotImplementedException();
        }

        public bool Borrar(Venta objDel)
        {
            return ventaDAL.Borrar(objDel);
        }

        public bool Borrar(DetalleVenta objDel)
        {
            throw new System.NotImplementedException();
        }

        public List<Venta> Cargar()
        {
            return ventaDAL.Cargar();
        }

        public bool Crear(Venta objAlta)
        {
            return ventaDAL.Crear(objAlta);
        }

        public bool Crear(DetalleVenta objAlta)
        {
            throw new System.NotImplementedException();
        }

        List<DetalleVenta> ICRUD<DetalleVenta>.Cargar()
        {
            throw new System.NotImplementedException();
        }
    }
}
