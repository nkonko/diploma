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
    }
}
