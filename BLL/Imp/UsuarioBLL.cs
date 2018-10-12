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

        public bool Crear(BE.Usuario objAlta)
        {
            return usuarioDAL.Crear(objAlta);
        }

        public List<BE.Usuario> Cargar()
        {
            return usuarioDAL.Cargar();
        }

        public bool Borrar(BE.Usuario objDel)
        {
            return usuarioDAL.Borrar(objDel);
        }

        public bool Actualizar(BE.Usuario objUpd)
        {
            return usuarioDAL.Actualizar(objUpd);
        }
    }
}
