namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Idioma : BE.ICRUD<BE.Idioma>
    {

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

        public void logIn()
        {

        }


        public bool Create(BE.Idioma ObjAlta)
        {
            return DAL.Idioma.Getinstancia().Create(ObjAlta);
        }

        public List<BE.Idioma> Retrive()
        {
            return DAL.Idioma.Getinstancia().Retrive();
        }

        public bool Delete(BE.Idioma ObjDel)
        {
            return DAL.Idioma.Getinstancia().Delete(ObjDel);
        }

        public bool Update(BE.Idioma ObjUpd)
        {
            return DAL.Idioma.Getinstancia().Update(ObjUpd);
        }
    }
}
