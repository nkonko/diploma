namespace SysAnalizer.Dal.Test
{
    using BE;
    using DAL.Imp;
    using NUnit.Framework;

    [TestFixture]
    public class UsuarioDalTest
    {
        public UsuarioDAL Usuario { get; set; }

        public UsuarioDalTest()
        {
        }

        [Test]
        public void CreateUsuarioShouldReturnOk()
        {
            Usuario.Crear(new Usuario { Nombre = "LALA", Apellido = "peppe", Contraseña = "123456", Email = "lala@hotmail.com", Telefono = 46532, PrimerLogin = true, IdIdioma = 1, CIngresos = 1, Activo = true, IdCanalVenta = 1 });
            Assert.True(true);
        }
    }
}
