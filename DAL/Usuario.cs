namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class Usuario : BE.ICRUD<BE.Usuario>
    {
        private static Usuario instancia;

        SqlCommand comm = new SqlCommand();

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

        public static SqlConnection Connection()
        {
            var conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=SYSANALIZER2;Integrated Security=True";
            return conn;
        }


        public bool Create(BE.Usuario ObjAlta)
        {
            var queryString = string.Format("INSERT INTO dbo.Usuario(Nombre, Apellido, Password, Email, Telefono, ContadorIngresosIncorrectos, IdCanalVenta, IdIdioma, PrimerLogin) values ({0}{1}{2}{3}{4}{5}{6}{7}{8})",
                ObjAlta.nombre,
                ObjAlta.apellido,
                Encriptar(ObjAlta.contraseña),
                ObjAlta.email,
                ObjAlta.telefono,
                ObjAlta.cIngresos = 0,
                ObjAlta.idCanalVenta,
                ObjAlta.idIdioma,
                ObjAlta.primerLogin = true);

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

        public List<BE.Usuario> Retrive()
        {
            var usuario = new BE.Usuario();
            var queryString = "SELECT * FROM dbo.Usuario;";
            var comm = new SqlCommand();

            using (SqlConnection connection = Connection())
            {
                try
                {

                    comm.CommandText = queryString;
                    comm.Connection = connection;
                    comm.CommandType = CommandType.Text;

                    var Da = new SqlDataAdapter();
                    Da.SelectCommand = comm;

                    DataTable Dt = new DataTable();

                    Da.Fill(Dt);

                    foreach (DataRow dr in Dt.Rows)
                    {
                        usuario.id = Convert.ToInt32(dr["IdUsuario"]);
                        usuario.nombre = Convert.ToString(dr["Nombre"]);
                        usuario.apellido = Convert.ToString(dr["Apellido"]);
                        usuario.contraseña = Convert.ToString(dr["Password"]);
                        usuario.email = Convert.ToString(dr["Email"]);
                        usuario.telefono = Convert.ToInt32(dr["Telefono"]);
                        usuario.cIngresos = Convert.ToInt32(dr["ContadorIngresosIncorrectos"]);
                        usuario.activo = Convert.ToBoolean(dr["Activo"]);
                        usuario.idCanalVenta = Convert.ToInt32(dr["IdCanalVenta"]);
                        usuario.idIdioma = Convert.ToInt32(dr["IdIdioma"]);
                        usuario.primerLogin = Convert.ToBoolean(dr["PrimerLogin"]);
                    }
                    return new List<BE.Usuario>();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Delete(BE.Usuario ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Usuario ObjUpd)
        {
            throw new NotImplementedException();
        }

        public bool LogIn(string email, string contraseña)
        {
            BE.Usuario usu = ObtenerUsuarioConEmail(email);
            if (!usu.primerLogin)
            {
                var cIngresoInc = usu.cIngresos;

                if (cIngresoInc < 3)
                {
                    string contEncriptada = Encriptar(contraseña);
                    bool ingresa = ValidarContraseña(usu, contEncriptada);
                    if (!ingresa)
                    {
                        cIngresoInc++;
                        //AumentarIngresos();
                    }
                }
                return false;
            }
            return true;
        }

        private bool ValidarContraseña(BE.Usuario usuario, string contEncriptada)
        {
            if (usuario.contraseña == contEncriptada)
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

                var Da = new SqlDataAdapter();
                Da.SelectCommand = comm;

                DataTable Dt = new DataTable();

                Da.Fill(Dt);

                foreach (DataRow dr in Dt.Rows)
                {
                    usuario.id = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.nombre = Convert.ToString(dr["Nombre"]);
                    usuario.apellido = Convert.ToString(dr["Apellido"]);
                    usuario.contraseña = Convert.ToString(dr["Password"]);
                    usuario.email = Convert.ToString(dr["Email"]);
                    usuario.telefono = Convert.ToInt32(dr["Telefono"]);
                    usuario.cIngresos = Convert.ToInt32(dr["ContadorIngresosIncorrectos"]);
                    usuario.activo = Convert.ToBoolean(dr["Activo"]);
                    usuario.idCanalVenta = Convert.ToInt32(dr["IdCanalVenta"]);
                    usuario.idIdioma = Convert.ToInt32(dr["IdIdioma"]);
                    usuario.primerLogin = Convert.ToBoolean(dr["PrimerLogin"]);
                }
                return usuario;
            }
        }

        public string Encriptar(string contraseña)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(contraseña));
            byte[] encriptado = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < encriptado.Length; i++)
            {
                str.Append(encriptado[i].ToString("x2"));
            }
            return str.ToString();
        }
    }
}
