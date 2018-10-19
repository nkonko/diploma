namespace BLL
{
    using BE;
    using DAL;
    using System.Collections.Generic;

    public class ProductoBLL : ICRUD<Producto>, IProductoBLL
    {
        private readonly IProductoDAL productoDAL;

        public ProductoBLL(IProductoDAL productoDAL)
        {
            this.productoDAL = productoDAL;
        }

        public bool Crear(Producto objAlta)
        {
            return productoDAL.Crear(objAlta);
        }

        public List<Producto> Cargar()
        {
            return productoDAL.Cargar();
        }

        public bool Borrar(Producto objDel)
        {
            return productoDAL.Borrar(objDel);
        }

        public bool Actualizar(Producto objUpd)
        {
            return productoDAL.Actualizar(objUpd);
        }
    }
}
