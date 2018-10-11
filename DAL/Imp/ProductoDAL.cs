namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public class ProductoDAL : BE.ICRUD<BE.Producto>
    {
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        private readonly string queryString = string.Empty;

        public bool Crear(BE.Producto objAlta)
        {
            var queryString = string.Format(
                                ""
        }

        public bool Borrar(BE.Producto objDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Producto> Cargar()
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(BE.Producto objUpd)
        {
            throw new NotImplementedException();
        }
    }
}
