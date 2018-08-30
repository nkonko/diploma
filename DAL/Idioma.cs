namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BE;

    public class Idioma : BE.ICRUD<BE.Idioma>
    {

        string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        string queryString = string.Empty;


        private Idioma()
        {
        }

        private static Idioma instancia;

        public static Idioma Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Idioma();
            }
            return instancia;
        }


        public bool Create(BE.Idioma ObjAlta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Idioma ObjDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Idioma> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Idioma ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
