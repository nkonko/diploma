﻿namespace BLL
{
    using BE;
    using DAL;
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
                log.Info("Usuario logueado correctamente");
                return ingresa;
            }

            if (usu.CIngresos < 3)
            {
                log.Info("Login Incorrecto");
            }
            else
            {
                log.Info("Login Incorrecto, Cuenta bloqueada");
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
    }
}
