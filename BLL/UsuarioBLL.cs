namespace BLL
{
    using DAL;
    using System.Collections.Generic;

    public class UsuarioBLL : BE.ICRUD<BE.Usuario>, IUsuarioBLL
    {
        private readonly IUsuarioDAL usuarioDAL;

        public UsuarioBLL(IUsuarioDAL usuarioDal)
        {
            usuarioDAL = usuarioDal;
        }

        public bool LogIn(string email, string contraseña)
        {
            return usuarioDAL.LogIn(email, contraseña);
        }

        public bool Create(BE.Usuario objAlta)
        {
            return usuarioDAL.Create(objAlta);
        }

        public List<BE.Usuario> Retrive()
        {
            return usuarioDAL.Retrive();
        }

        public bool Delete(BE.Usuario objDel)
        {
            return usuarioDAL.Delete(objDel);
        }

        public bool Update(BE.Usuario objUpd)
        {
            return usuarioDAL.Update(objUpd);
        }
    }
}
