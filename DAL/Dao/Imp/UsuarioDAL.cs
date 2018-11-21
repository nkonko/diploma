namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using EasyEncryption;
    using System;
    using System.Collections.Generic;

    public class UsuarioDAL : BaseDao, ICRUD<Usuario>, IUsuarioDAL
    {
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        private readonly IDigitoVerificador digitoVerificador;

        public UsuarioDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Crear(Usuario objAlta)
        {
            var contEncript = MD5.ComputeMD5Hash(new Random().Next().ToString());
            var emailEncript = DES.Encrypt(objAlta.Email, Key, Iv);

            objAlta.UsuarioId = ObtenerUltimoIdUsuario() + 1;
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { objAlta.Nombre, emailEncript, contEncript }, new List<int> { objAlta.UsuarioId });

            var queryString = "INSERT INTO Usuario(Nombre, Apellido, Contraseña, Email, Telefono, Domicilio, ContadorIngresosIncorrectos, " +
                "IdCanalVenta, IdIdioma, PrimerLogin, DVH, Activo) " +
                "VALUES (@nombre, @apellido, @contraseña, @email, @telefono, @domicilio, @contadorIngresos, @idCanalVenta, @idIdioma, " +
                "@primerLogin, @dvh, @activo)";

            return CatchException(() =>
              {
                  return Exec(
                      queryString,
                      new
                      {
                          @nombre = objAlta.Nombre,
                          @apellido = objAlta.Apellido,
                          @contraseña = contEncript,
                          @email = emailEncript,
                          @telefono = objAlta.Telefono,
                          @domicilio = objAlta.Domicilio,
                          @contadorIngresos = objAlta.CIngresos = 0,
                          @idCanalVenta = objAlta.IdCanalVenta,
                          @idIdioma = objAlta.IdIdioma,
                          @primerLogin = Convert.ToByte(objAlta.PrimerLogin = true),
                          @dvh = digitoVH,
                          @activo = 0
                      });
              });
        }

        public List<Usuario> Cargar()
        {
            var queryString = "SELECT * FROM Usuario;";

            return CatchException(() =>
            {
                return Exec<Usuario>(queryString);
            });
        }

        public bool Borrar(Usuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("DELETE FROM Usuario WHERE UsuarioId = {0}", usu.UsuarioId);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Actualizar(Usuario objUpd)
        {
            var usu = ObtenerUsuarioConEmail(objUpd.Email);
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { objUpd.Nombre, usu.Email }, new List<int> { usu.UsuarioId });

            var queryString = $"UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, Email = @email, Telefono = @telefono, Domicilio = @domicilio, DVH = @dvh WHERE UsuarioId = @usuarioId";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @usuarioId = usu.UsuarioId,
                        @nombre = objUpd.Nombre,
                        @apellido = objUpd.Apellido,
                        @email = usu.Email,
                        @telefono = objUpd.Telefono,
                        @domicilio = objUpd.Domicilio,
                        @dvh = digitoVH
                    });
            });
        }

        public bool LogIn(string email, string contraseña)
        {
            var ingresa = false;

            var usu = ObtenerUsuarioConEmail(email);

            if (usu.Email != null)
            {
                if (!usu.PrimerLogin)
                {
                    var cingresoInc = usu.CIngresos;

                    if (cingresoInc < 3)
                    {
                        var contEncriptada = MD5.ComputeMD5Hash(contraseña);

                        ingresa = ValidarContraseña(usu.Contraseña, contEncriptada);
                        if (!ingresa)
                        {
                            cingresoInc++;

                            AumentarIngresos(usu, cingresoInc);

                            return false;
                        }

                        return true;
                    }

                    return false;
                }

                return true;
            }

            return false;
        }

        public bool CambiarContraseña(Usuario usuario, string nuevaContraseña, bool primerLogin = false)
        {
            var contEncript = MD5.ComputeMD5Hash(nuevaContraseña);
            var queryString = string.Empty;
            if (primerLogin == true)
            {
                queryString = "UPDATE Usuario SET Contraseña = @contraseña, PrimerLogin = 0 WHERE UsuarioId = @usuarioId";
            }
            else
            {
                queryString = "UPDATE Usuario SET Contraseña = @contraseña WHERE UsuarioId = @usuarioId";
            }

            return CatchException(() =>
            {
                return Exec(queryString, new { @usuarioId = usuario.UsuarioId, @contraseña = contEncript });
            });
        }

        public Usuario ObtenerUsuarioConEmail(string email)
        {
            var usuario = new List<Usuario>();
            var queryString = string.Format("SELECT * FROM dbo.Usuario WHERE Email = '{0}'", DES.Encrypt(email, Key, Iv));

            CatchException(() =>
            {
                usuario = Exec<Usuario>(queryString);
            });

            if (usuario.Count > 0)
            {
                return usuario[0];
            }
            else
            {
                return new Usuario();
            }
        }

        public List<Patente> ObtenerPatentesDeUsuario(int usuarioId)
        {
            var queryString = $"SELECT IdPatente FROM UsuarioPatente WHERE UsuarioId = {usuarioId}";

            return CatchException(() =>
            {
                return Exec<Patente>(queryString);
            });
        }

        private bool ValidarContraseña(string contraseña, string contEncriptada)
        {
            if (contraseña == contEncriptada)
            {
                return true;
            }

            return false;
        }

        private void AumentarIngresos(Usuario usuario, int ingresos)
        {
            var queryString = string.Format("UPDATE Usuario SET Contraseña = {1} WHERE UsuarioId = {0}", usuario.UsuarioId, ingresos);

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        private int ObtenerUltimoIdUsuario()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Usuario]') AS Current_Identity;";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }
    }
}
