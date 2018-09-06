namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public class Producto : BE.ICRUD<BE.Producto>
    {
        private static Producto instancia;
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        private readonly string queryString = string.Empty;

        private Producto()
        {
        }

        public static Producto Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Producto();
            }

            return instancia;
        }

        public bool Create(BE.Producto objAlta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Producto objDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Producto> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Producto objUpd)
        {
            throw new NotImplementedException();
        }
    }
}
