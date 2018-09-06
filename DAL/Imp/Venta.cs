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
        private static Venta instancia;
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        private readonly string queryString = string.Empty;

        private Venta()
        {
        }

        public static Venta Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Venta();
            }

            return instancia;
        }

        public bool Create(BE.Venta objAlta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Venta objDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Venta> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Venta objUpd)
        {
            throw new NotImplementedException();
        }
    }
}
