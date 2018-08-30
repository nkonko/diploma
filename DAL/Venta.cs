namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class Venta : BE.ICRUD<BE.Venta>
    {

        string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        string queryString = string.Empty;


        private Venta()
        {
        }

        private static Venta instancia;

        public static Venta Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Venta();
            }
            return instancia;
        }


        public bool Create(BE.Venta ObjAlta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Venta ObjDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Venta> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Venta ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
