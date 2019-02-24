namespace BLL.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class DetalleVentaBLL : IDetalleVentaBLL, ICRUD<DetalleVenta>
    {
        private readonly IDetalleVentaDAL detalleVentaDAL;

        public DetalleVentaBLL(IDetalleVentaDAL detalleVentaDAL)
        {
            this.detalleVentaDAL = detalleVentaDAL;
        }

        public bool Actualizar(DetalleVenta objUpd)
        {
            return detalleVentaDAL.Actualizar(objUpd);
        }

        public bool Borrar(DetalleVenta objDel)
        {
            return detalleVentaDAL.Borrar(objDel);
        }

        public List<DetalleVenta> Cargar()
        {
            return detalleVentaDAL.Cargar();
        }

        public bool Crear(DetalleVenta objAlta)
        {
            return detalleVentaDAL.Crear(objAlta);
        }
    }
}
