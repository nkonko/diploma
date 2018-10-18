namespace BLL
{
    using BE;
    using DAL;
    using System.Collections.Generic;

    public class UsuarioBLL : ICRUD<Usuario>, IUsuarioBLL
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

        public bool Crear(Usuario objAlta)
        {
            return usuarioDAL.Crear(objAlta);
        }

        public List<Usuario> Cargar()
        {
            return usuarioDAL.Cargar();
        }

        public bool Borrar(Usuario objDel)
        {
            return usuarioDAL.Borrar(objDel);
        }

        public bool Actualizar(Usuario objUpd)
        {
            return usuarioDAL.Actualizar(objUpd);
        }
    }
}
