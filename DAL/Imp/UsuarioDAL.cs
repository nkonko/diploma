namespace DAL
{
    using BE;
    using DAL.Utils;
    using Dapper;
    using EasyEncryption;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class UsuarioDAL : ICRUD<Usuario>, IUsuarioDAL
    {
        public ILog Log { get; set; }

        private readonly IDigitoVerificador digitoVerificador;

        public UsuarioDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Crear(Usuario objAlta)
        {
            var contEncript = MD5.ComputeMD5Hash(new Random().Next().ToString());
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { objAlta.Nombre, objAlta.Email, contEncript });

            var queryString = string.Format(
                         "INSERT INTO Usuario(Nombre, Apellido, Password, Email, Telefono, ContadorIngresosIncorrectos, IdCanalVenta, IdIdioma, PrimerLogin, DigitoVerificadorH, Activo)" +
                         "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8},{9}, {10})",
                        objAlta.Nombre,
                        objAlta.Apellido,
                        contEncript,
                        objAlta.Email,
                        objAlta.Telefono,
                        objAlta.CIngresos = 0,
                        objAlta.IdCanalVenta,
                        objAlta.IdIdioma,
                        Convert.ToByte(objAlta.PrimerLogin = true),
                        digitoVH,
                        0);

            bool returnValue = false;

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);

                    return returnValue = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Log.Info("Usuario Creado");
            return returnValue;
        }

        public List<Usuario> Cargar()
        {
            var usuario = new Usuario();
            var queryString = "SELECT * FROM Usuario;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var usuarios = (List<Usuario>)connection.Query<Usuario>(queryString);

                    return usuarios;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public bool Borrar(Usuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("DELETE FROM Usuario WHERE IdUsuario = {0}", usu.IdUsuario);
            bool returnValue = false;

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public bool Actualizar(Usuario objUpd)
        {
            var usu = ObtenerUsuarioConEmail(objUpd.Email);

            var queryString = string.Format("UPDATE Usuario SET Nombre = {1}, Apellido = {2}, Password = {3}, Email = {4}, Telefono = {5} WHERE IdUsuario = {0}", usu.IdUsuario, objUpd.Nombre, objUpd.Apellido, objUpd.Contraseña, objUpd.Email, objUpd.Telefono);
            bool returnValue = false;

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public bool LogIn(string email, string contraseña)
        {
            var usu = ObtenerUsuarioConEmail(email);
            if (!usu.PrimerLogin)
            {
                var cingresoInc = usu.CIngresos;

                if (cingresoInc < 3)
                {
                    var contEncriptada = MD5.ComputeMD5Hash(contraseña);
                    bool ingresa = ValidarContraseña(usu, contEncriptada);
                    if (!ingresa)
                    {
                        cingresoInc++;

                        AumentarIngresos(usu, cingresoInc);
                        Log.Info("Login Incorrecto de usuario");
                        RegistrarEnBitacora(usu);

                        return false;
                    }

                    Log.Info("Login Correcto de usuario");
                    RegistrarEnBitacora(usu);

                    return true;
                }

                Log.Info("Usuario bloqueado");
                RegistrarEnBitacora(usu);

                return false;
            }

            return true;
        }

        public bool CambiarPassword(Usuario usuario, string nuevaContraseña)
        {
            var returnValue = false;

            var queryString = string.Format("UPDATE Usuario SET Password = '{1}' WHERE IdUsuario = {0}", usuario.IdUsuario, nuevaContraseña);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                    returnValue = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public Usuario ObtenerUsuarioConEmail(string email)
        {
            var queryString = string.Format("SELECT * FROM dbo.Usuario WHERE Email = '{0}'", email);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                var usuario = (List<Usuario>)connection.Query<Usuario>(queryString);

                return usuario[0];
            }
        }

        private bool ValidarContraseña(Usuario usuario, string contEncriptada)
        {
            if (usuario.Contraseña == contEncriptada)
            {
                return true;
            }

            return false;
        }

        private void RegistrarEnBitacora(Usuario usu)
        {
            GlobalContext.Properties["IdUsuario"] = usu.IdUsuario;
            GlobalContext.Properties["DVH"] = usu.DVH;
        }

        private void AumentarIngresos(Usuario usuario, int ingresos)
        {
            var queryString = string.Format("UPDATE Usuario SET Password = {1} WHERE IdUsuario = {0}", usuario.IdUsuario, ingresos);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
