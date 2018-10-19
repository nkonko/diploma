namespace BLL
{
    using System.Collections.Generic;
    using BE;
    using DAL;

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
