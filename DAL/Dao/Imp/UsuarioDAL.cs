namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using Dapper;
    using EasyEncryption;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class UsuarioDAL : BaseDao, ICRUD<Usuario>, IUsuarioDAL
    {
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
                         "INSERT INTO Usuario(Nombre, Apellido, Password, Email, Telefono, ContadorIngresosIncorrectos, IdCanalVenta, IdIdioma, PrimerLogin, DVH, Activo)" +
                         "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8},{9}, {10})",
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

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
        }

        public List<Usuario> Cargar()
        {
            var queryString = "SELECT * FROM Usuario;";

            return Exec<Usuario>(queryString);

            //using (IDbConnection connection = SqlUtils.Connection())
            //{
            //    try
            //    {
            //        connection.Open();
            //        var usuarios = (List<Usuario>)connection.Query<Usuario>(queryString);

            //        return usuarios;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //    return null;
            //}
        }

        public bool Borrar(Usuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("DELETE FROM Usuario WHERE IdUsuario = {0}", usu.IdUsuario);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
        }

        public bool Actualizar(Usuario objUpd)
        {
            var usu = ObtenerUsuarioConEmail(objUpd.Email);

            var queryString = string.Format("UPDATE Usuario SET Nombre = {1}, Apellido = {2}, Password = {3}, Email = {4}, Telefono = {5} WHERE IdUsuario = {0}", usu.IdUsuario, objUpd.Nombre, objUpd.Apellido, objUpd.Contraseña, objUpd.Email, objUpd.Telefono);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
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
                    var ingresa = ValidarContraseña(usu.Contraseña, contEncriptada);
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

        public bool CambiarPassword(Usuario usuario, string nuevaContraseña, bool primerLogin = false)
        {
            var returnValue = false;
            var contEncript = MD5.ComputeMD5Hash(nuevaContraseña);
            var queryString = string.Empty;
            if (primerLogin == true)
            {
                queryString = string.Format("UPDATE Usuario SET Password = '{1}', PrimerLogin = 0 WHERE IdUsuario = {0}", usuario.IdUsuario, contEncript);
            }
            else
            {
                queryString = string.Format("UPDATE Usuario SET Password = '{1}' WHERE IdUsuario = {0}", usuario.IdUsuario, contEncript);
            }

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

        //// Cambiar a cargar y usar linq para devolver el usuario que coincida con la descripcion para no repetir codigo
        public Usuario ObtenerUsuarioConEmail(string email)
        {
            var queryString = string.Format("SELECT * FROM dbo.Usuario WHERE Email = '{0}'", email);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                connection.Open();
                var usuario = (List<Usuario>)connection.Query<Usuario>(queryString);

                return usuario[0];
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Patente> ObtenerPatentesDeUsuario(int usuarioId)
        {
            var queryString = $"SELECT IdPatente FROM UsuarioPatente WHERE IdUsuario = {usuarioId}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var patentes = (List<Patente>)connection.Query<Patente>(queryString);

                    return patentes;
                }
                catch (Exception)
                {
                    throw;
                }
            }
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
