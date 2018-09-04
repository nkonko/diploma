namespace SysAnalizer.Dal.Test
{
    using System;
    using DAL;
    using BE;
    using NUnit.Framework;

    [TestFixture]
    public class UsuarioDalTest
    {
        public DAL.Usuario Usuario { get; set; }

        [Test]
        private bool CreateUsuarioShouldReturnOk()
        {
            Usuario.Create(new BE.Usuario { Nombre = "LALA",
                                            Apellido = "peppe",
                                            Contraseña = "123456",
                                            Email = "lala@hotmail.com",
                                            Telefono = 46532,
                                            PrimerLogin = true,
                                            IdIdioma = 1,
                                            CIngresos = 1,
                                            Activo = true,
                                            IdCanalVenta = 1 });
            return true;
        }
    }
}
