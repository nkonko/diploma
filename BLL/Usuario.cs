namespace BLL
{
    using System.Collections.Generic;

    public class Usuario : BE.ICRUD<BE.Usuario>
    {
        private Usuario()
        {
        }

        private static Usuario instancia;

        public static Usuario Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Usuario();
            }

            return instancia;
        }

        public bool LogIn(string email, string contraseña)
        {
            return DAL.Usuario.Getinstancia().LogIn(email, contraseña);
        }

        public bool Create(BE.Usuario objAlta)
        {
            return DAL.Usuario.Getinstancia().Create(objAlta);
        }

        public List<BE.Usuario> Retrive()
        {
            return DAL.Usuario.Getinstancia().Retrive();
        }

        public bool Delete(BE.Usuario objDel)
        {
            return DAL.Usuario.Getinstancia().Delete(objDel);
        }

        public bool Update(BE.Usuario objUpd)
        {
            return DAL.Usuario.Getinstancia().Update(objUpd);
        }
    }
}
