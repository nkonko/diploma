namespace BLL
{
    using BE;
    using BE.Entidades;
    using DAL;
    using DAL.Dao;
    using log4net;
    using System.Collections.Generic;

    public class UsuarioBLL : ICRUD<Usuario>, IUsuarioBLL
    {
        private readonly IUsuarioDAL usuarioDAL;
        private readonly IBitacoraBLL bitacoraBLL;
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UsuarioBLL(IUsuarioDAL usuarioDAL, IBitacoraBLL bitacoraBLL)
        {
            this.bitacoraBLL = bitacoraBLL;
            this.usuarioDAL = usuarioDAL;
        }

        public bool LogIn(string email, string contraseña)
        {
            var ingresa = usuarioDAL.LogIn(email, contraseña);
            var usu = usuarioDAL.ObtenerUsuarioConEmail(email);
            bitacoraBLL.RegistrarEnBitacora(usu);

            if (ingresa)
            {
                Log4netExtensions.Baja(log, "Usuario logueado correctamente");
                return ingresa;
            }

            if (usu.ContadorIngresosIncorrectos < 3)
            {
                Log4netExtensions.Baja(log, "Login Incorrecto");
            }
            else
            {
                Log4netExtensions.Media(log, "Login Incorrecto, Cuenta bloqueada");
            }

            return ingresa;
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

        public Usuario ObtenerUsuarioConEmail(string email)
        {
            return usuarioDAL.ObtenerUsuarioConEmail(email);
        }

        public List<Patente> ObtenerPatentesDeUsuario(int usuarioId)
        {
            return usuarioDAL.ObtenerPatentesDeUsuario(usuarioId);
        }

        public List<Usuario> CargarInactivos()
        {
            return usuarioDAL.CargarInactivos();
        }

        public bool ActivarUsuario(string email)
        {
            return usuarioDAL.ActivarUsuario(email);
        }

        public bool DesactivarUsuario(string email)
        {
            return usuarioDAL.DesactivarUsuario(email);
        }

        public Usuario ObtenerUsuarioConId(int usuarioId)
        {
            return usuarioDAL.ObtenerUsuarioConId(usuarioId);
        }

        public List<Usuario> TraerUsuariosConPatentesYFamilias()
        {
            return usuarioDAL.TraerUsuariosConPatentesYFamilias();
        }
    }
}
