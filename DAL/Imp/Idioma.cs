namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public class Idioma : BE.ICRUD<BE.Idioma>
    {
        private static Idioma instancia;
        private readonly string connectionString = ConfigurationManager.AppSettings["ConnStirng"];
        private readonly string queryString = string.Empty;

        private Idioma()
        {
        }

        public static Idioma Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Idioma();
            }

            return instancia;
        }

        public bool Create(BE.Idioma objAlta)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BE.Idioma objDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Idioma> Retrive()
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Idioma objUpd)
        {
            throw new NotImplementedException();
        }
    }
}
