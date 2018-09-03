namespace BLL
{
    using System.Collections.Generic;

    public class Idioma : BE.ICRUD<BE.Idioma>
    {
        private static Idioma instancia;

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
            return DAL.Idioma.Getinstancia().Create(objAlta);
        }

        public List<BE.Idioma> Retrive()
        {
            return DAL.Idioma.Getinstancia().Retrive();
        }

        public bool Delete(BE.Idioma objDel)
        {
            return DAL.Idioma.Getinstancia().Delete(objDel);
        }

        public bool Update(BE.Idioma objUpd)
        {
            return DAL.Idioma.Getinstancia().Update(objUpd);
        }
    }
}
