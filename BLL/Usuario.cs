namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Usuario : BE.ICRUD<BE.Usuario>
    {

        private Usuario()
        {
        }

        private static Usuario instancia;

        public static Usuario Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Usuario();
            }
            return instancia;
        }

        public void logIn()
        {

        }


        public bool Create(BE.Usuario ObjAlta)
        {
            return DAL.Usuario.Getinstancia().Create(ObjAlta);
        }

        public List<BE.Usuario> Retrive()
        {
            return DAL.Usuario.Getinstancia().Retrive();
        }

        public bool Delete(BE.Usuario ObjDel)
        {
            return DAL.Usuario.Getinstancia().Delete(ObjDel);
        }

        public bool Update(BE.Usuario ObjUpd)
        {
            return DAL.Usuario.Getinstancia().Update(ObjUpd);
        }
    }
}
