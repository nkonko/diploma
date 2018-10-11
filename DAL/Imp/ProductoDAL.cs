namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public class ProductoDAL : BE.ICRUD<BE.Producto>
    {
        private static ProductoDAL instancia;
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        private readonly string queryString = string.Empty;

        private ProductoDAL()
        {
        }

        public static ProductoDAL Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new ProductoDAL();
            }

            return instancia;
        }

        public bool Crear(BE.Producto objAlta)
        {
            throw new NotImplementedException();
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
