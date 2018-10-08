namespace DAL
{
    using DAL.Utils;
    using Dapper;
    using EasyEncryption;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class Usuario : BE.ICRUD<BE.Usuario>
    {
        public ILog Logger { get; set; }

        private static Usuario instancia;

        private Usuario()
        {
        }

        public static Usuario Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Usuario();
            }

            return instancia;
        }

        public bool Create(BE.Usuario objAlta)
        {
            Random random = new Random();
            string nuevoPass = random.Next().ToString();
            var contEncript = MD5.ComputeMD5Hash(objAlta.Contraseña = nuevoPass);
            string clase = "Usuario";
            var digitoVH = CalcularDigitoVerificador(clase, objAlta.Nombre, objAlta.Email, contEncript, 1);

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
                        1);

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
            Logger.Info("Usuario Creado");
            return returnValue;
        }

        public List<BE.Usuario> Retrive()
        {
            var usuario = new BE.Usuario();
            var queryString = "SELECT * FROM Usuario;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var usuarios = (List<BE.Usuario>)connection.Query<BE.Usuario>(queryString);

                    return usuarios;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public bool Delete(BE.Usuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("DELETE FROM Usuario WHERE IdUsuario = {0}", usu.Id);
            bool returnValue = false;

            using (SqlConnection connection = SqlUtils.Connection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public bool Update(BE.Usuario objUpd)
        {
            var usu = ObtenerUsuarioConEmail(objUpd.Email);

            var queryString = string.Format("UPDATE Usuario SET Nombre = {1}, Apellido = {2}, Password = {3}, Email = {4}, Telefono = {5} WHERE IdUsuario = {0}", usu.Id, objUpd.Nombre, objUpd.Apellido, objUpd.Contraseña, objUpd.Email, objUpd.Telefono);
            bool returnValue = false;

            using (SqlConnection connection = SqlUtils.Connection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
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
            BE.Usuario usu = ObtenerUsuarioConEmail(email);
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
                        return false;
                    }

                    return true;
                }

                return false;
            }

            CambiarPassword(usu);
            return true;
        }

        private int CalcularDigitoVerificador(string entidad, string nombre, string email, string password, int activo)
        {
            DigitoVerificador digitoVerificador = new DigitoVerificador();
            var digito = digitoVerificador.CalcularDVHorizontal(entidad, new List<string> { nombre, email, password }, new List<int> { activo });
            return digito;
        }

        private void CambiarPassword(BE.Usuario usuario)
        {
            var queryString = string.Format("UPDATE Usuario SET Password = {1} WHERE IdUsuario = {0}", usuario.Id, usuario.Contraseña);

            using (SqlConnection connection = SqlUtils.Connection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AumentarIngresos(BE.Usuario usuario, int ingresos)
        {
            var queryString = string.Format("UPDATE Usuario SET Password = {1} WHERE IdUsuario = {0}", usuario.Id, ingresos);

            using (SqlConnection connection = SqlUtils.Connection())
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private bool ValidarContraseña(BE.Usuario usuario, string contEncriptada)
        {
            if (usuario.Contraseña == contEncriptada)
            {
                return true;
            }

            return false;
        }

        private BE.Usuario ObtenerUsuarioConEmail(string email)
        {
            var usuario = new BE.Usuario();
            var queryString = string.Format("SELECT * FROM dbo.Usuario WHERE Email = '{0}'", email);
            var comm = new SqlCommand();

            using (SqlConnection connection = SqlUtils.Connection())
            {
                comm.CommandText = queryString;
                comm.Connection = connection;
                comm.CommandType = CommandType.Text;

                var da = new SqlDataAdapter(comm);

                DataTable dt = new DataTable();

                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    usuario.Id = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.Nombre = Convert.ToString(dr["Nombre"]);
                    usuario.Apellido = Convert.ToString(dr["Apellido"]);
                    usuario.Contraseña = Convert.ToString(dr["Password"]);
                    usuario.Email = Convert.ToString(dr["Email"]);
                    usuario.Telefono = Convert.ToInt32(dr["Telefono"]);
                    usuario.CIngresos = Convert.ToInt32(dr["ContadorIngresosIncorrectos"]);
                    usuario.Activo = Convert.ToBoolean(dr["Activo"]);
                    usuario.IdCanalVenta = Convert.ToInt32(dr["IdCanalVenta"]);
                    usuario.IdIdioma = Convert.ToInt32(dr["IdIdioma"]);
                    usuario.PrimerLogin = Convert.ToBoolean(dr["PrimerLogin"]);
                }

                return usuario;
            }
        }
    }
}
