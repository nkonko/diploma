namespace SysAnalizer.Dal.Test
{
    using BE.Entidades;
    using BLL;
    using BLL.Imp;
    using DAL.Dao;
    using DAL.Utils;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UI;

    [TestFixture]
    public class UsuarioDalTest
    {
        private Mock<IUsuarioDAL> usuarioMock;
        private List<int> todasLasPatentes = new List<int>() { 33, 331, 332, 333 };
        private IUsuarioBLL usuarioBLL;
        private IPatenteBLL patenteBLL;

        public Usuario Usuario { get; set; } = new Usuario();

        public List<Usuario> UsuariosBD { get; set; } = new List<Usuario>();

        [SetUp]
        public void Setup()
        {
            CrearInstancias();
            SetMockUtils();
        }

        [Test]
        public void Reinicio()
        {
            usuarioBLL.Borrar(Usuario);
            patenteBLL.BorrarPatentesUsuario(todasLasPatentes, Usuario.UsuarioId);
        }

        [Test]
        public void CreateUsuarioShouldReturnOk()
        {
            usuarioMock
                .Setup(u => u.Cargar())
                .Returns(new List<Usuario>() { new Usuario() { Nombre = "ALF", Apellido = "DE la LUNA" } });

            var puto = usuarioBLL.Cargar();

            usuarioBLL.Crear(new Usuario { Nombre = "Nunit", Apellido = "Nunit", Contraseña = "123456", Email = "Nunit", Telefono = 46532, PrimerLogin = true, IdIdioma = 1, ContadorIngresosIncorrectos = 0, Activo = true, IdCanalVenta = 1, Familia = new List<Familia>(), Patentes = new List<Patente>(), Domicilio = "Nunint", DVH = 1 });
            Assert.AreEqual(true, usuarioBLL.Cargar().Exists(usuario => usuario.Nombre == "Nunit"));
        }

        [Test]
        public void DeleteAllUsersShouldNotReturnOk()
        {
            Assert.AreEqual(false, patenteBLL.CheckeoUsuarioParaBorrar(Usuario, UsuariosBD));
        }

        [Test]
        public void AssignAllPatentesToUserShouldReturnOk()
        {
            patenteBLL.GuardarPatentesUsuario(todasLasPatentes, Usuario.UsuarioId);
            Assert.AreEqual(todasLasPatentes.Count, Usuario.Patentes.Count);
        }

        [Test]
        public void DeleteAllOtherUsersShouldReturnOK()
        {
            Assert.AreEqual(true, patenteBLL.CheckeoUsuarioParaBorrar(Usuario, UsuariosBD));
        }

        private void SetMockUtils()
        {
            usuarioMock = new Mock<IUsuarioDAL>();
        }

        private void CrearInstancias()
        {
            usuarioBLL = new UsuarioBLL(IoCContainer.Resolve<IUsuarioDAL>(), IoCContainer.Resolve<IBitacoraBLL>());
            patenteBLL = new PatenteBLL(IoCContainer.Resolve<IPatenteDAL>());
            Usuario = usuarioBLL.Cargar().Where(usuarioItem => usuarioItem.Nombre == "Nunit").FirstOrDefault();
            Usuario.Patentes = new List<Patente>();
            Usuario.Familia = new List<Familia>();
            Usuario.Patentes.AddRange(usuarioBLL.ObtenerPatentesDeUsuario(Usuario.UsuarioId));
            UsuariosBD = usuarioBLL.TraerUsuariosConPatentesYFamilias();
        }
    }
}
