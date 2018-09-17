namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class Usuario : BE.ICRUD<BE.Usuario>
    {
        private static Usuario instancia;

        private readonly IEncriptador encriptador;

        private SqlCommand comm = new SqlCommand();

        private Usuario(IEncriptador encriptador)
        {
            this.encriptador = encriptador;
        }

        public static Usuario Getinstancia()
        {
            if (instancia == null)
            {
                instancia = new Usuario(new Encriptador());
            }

            return instancia;
        }

        public static SqlConnection Connection()
        {
            var conn = new SqlConnection(@"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=SYSANALIZER2;Integrated Security=True");
            return conn;
        }

        public bool Create(BE.Usuario objAlta)
        {
            Random random = new Random();
            string nuevoPass = random.Next().ToString();
            string contEncript = encriptador.Encriptar(objAlta.Contraseña = nuevoPass);

            var queryString = string.Format(
                                     "INSERT INTO Usuario(Nombre, Apellido, Password, Email, Telefono, ContadorIngresosIncorrectos, IdCanalVenta, IdIdioma, PrimerLogin, DigitoVerificadorH) " +
                                     "values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9})",
                                    objAlta.Nombre,
                                    objAlta.Apellido,
                                    contEncript,
                                    objAlta.Email,
                                    objAlta.Telefono,
                                    objAlta.CIngresos = 0,
                                    objAlta.IdCanalVenta,
                                    objAlta.IdIdioma,
                                    Convert.ToByte(objAlta.PrimerLogin = true),
                                    CalcularDigitoVerificador(objAlta.DVH));

            bool returnValue = false;

            using (SqlConnection connection = Connection())
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

        private object CalcularDigitoVerificador(int dVH)
        {
            throw new NotImplementedException();
        }

        public List<BE.Usuario> Retrive()
        {
            var usuario = new BE.Usuario();
            var queryString = "SELECT * FROM Usuario;";
            var comm = new SqlCommand();

            using (SqlConnection connection = Connection())
            {
                try
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

                    return new List<BE.Usuario>();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Delete(BE.Usuario objDel)
        {
            var usu = ObtenerUsuarioConEmail(objDel.Email);

            var queryString = string.Format("DELETE FROM Usuario WHERE IdUsuario = {0}", usu.Id);
            bool returnValue = false;

            using (SqlConnection connection = Connection())
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

            using (SqlConnection connection = Connection())
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
                    string contEncriptada = encriptador.Encriptar(contraseña);
                    bool ingresa = ValidarContraseña(usu, contEncriptada);
                    if (!ingresa)
                    {
                        cingresoInc++;

                        AumentarIngresos();
                        return false;
                    }

                    return true;
                }

                return false;
            }

            CambiarPassword();
            return true;
        }

        private void CambiarPassword()
        {
            throw new NotImplementedException();
        }

        private void AumentarIngresos()
        {
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

            using (SqlConnection connection = Connection())
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
