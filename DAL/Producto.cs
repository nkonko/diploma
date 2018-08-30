namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class Producto : BE.ICRUD<BE.Producto>
    {

        string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        string queryString = string.Empty;


        private Producto()
        {
        }

        private static Producto instancia;

        public static Producto Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Producto();
            }
            return instancia;
        }


        public bool Create(BE.Producto ObjAlta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Producto ObjDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Producto> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Producto ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
