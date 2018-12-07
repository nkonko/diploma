namespace SysAnalizer.Dal.Test
{
    using BE.Entidades;
    using BLL;
    using BLL.Imp;
    using DAL.Dao;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UI;

    [TestFixture]
    public class UsuarioDalTest
    {
        private List<int> todasLasPatentes = new List<int>() { 33, 331, 332, 333 };
        private IUsuarioBLL usuarioBLL;
        private IPatenteBLL patenteBLL;
        public Usuario usuario { get; set; } = new Usuario();
        public List<Usuario> usuariosBD { get; set; } = new List<Usuario>();

        [SetUp]
        public void Setup()
        {
            CrearInstancias();
        }

        private void CrearInstancias()
        {
            usuarioBLL = new UsuarioBLL(IoCContainer.Resolve<IUsuarioDAL>(), IoCContainer.Resolve<IBitacoraBLL>());
            patenteBLL = new PatenteBLL(IoCContainer.Resolve<IPatenteDAL>());
            usuario = usuarioBLL.Cargar().Where(usuarioItem => usuarioItem.Nombre == "Nunit").FirstOrDefault();
            usuario.Patentes = new List<Patente>();
            usuario.Familia = new List<Familia>();
            usuario.Patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(usuario.UsuarioId));
            usuariosBD = usuarioBLL.TraerUsuariosConPatentesYFamilias();
        }

        [Test]
        public void Reinicio()
        {
            usuarioBLL.Borrar(usuario);
            patenteBLL.BorrarPatentesUsuario(todasLasPatentes, usuario.UsuarioId);
        }

        [Test]
        public void CreateUsuarioShouldReturnOk()
        {
            usuarioBLL.Crear(new Usuario { Nombre = "Nunit", Apellido = "Nunit", Contraseña = "123456", Email = "Nunit", Telefono = 46532, PrimerLogin = true, IdIdioma = 1, ContadorIngresosIncorrectos = 0, Activo = true, IdCanalVenta = 1, Familia = new List<Familia>(), Patentes = new List<Patente>(), Domicilio = "Nunint", DVH = 1 });
            Assert.AreEqual(true, usuarioBLL.Cargar().Exists(usuario => usuario.Nombre == "Nunit"));
        }

        [Test]
        public void DeleteAllUsersShouldNotReturnOk()
        {
            Assert.AreEqual(false, patenteBLL.CheckeoUsuarioParaBorrar(usuario, usuariosBD));
        }

        [Test]
        public void AssignAllPatentesToUserShouldReturnOk()
        {
            patenteBLL.GuardarPatentesUsuario(todasLasPatentes, usuario.UsuarioId);
            Assert.AreEqual(todasLasPatentes.Count, usuario.Patentes.Count);
        }

        [Test]
        public void DeleteAllOtherUsersShouldReturnOK()
        {
            Assert.AreEqual(true, patenteBLL.CheckeoUsuarioParaBorrar(usuario, usuariosBD));
        }
    }
}
