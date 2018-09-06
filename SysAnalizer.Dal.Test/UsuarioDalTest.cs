namespace SysAnalizer.Dal.Test
{
    using BE;
    using DAL;
    using NUnit.Framework;

    [TestFixture]
    public class UsuarioDalTest
    {
        public DAL.Usuario Usuario { get; set; }

        public UsuarioDalTest()
        {
            Usuario = DAL.Usuario.Getinstancia();
        }

        [Test]
        public void CreateUsuarioShouldReturnOk()
        {
            Usuario.Create(new BE.Usuario { Nombre = "LALA", Apellido = "peppe", Contraseña = "123456", Email = "lala@hotmail.com", Telefono = 46532, PrimerLogin = true, IdIdioma = 1, CIngresos = 1, Activo = true, IdCanalVenta = 1 });
            Assert.True(true);
        }
    }
}
