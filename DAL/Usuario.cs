namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class Usuario : BE.ICRUD<BE.Usuario>
    {
        SqlCommand comm = new SqlCommand();
        string connectionString = ConfigurationManager.AppSettings["connString"];
        string queryString;

        private Usuario()
        {
        }

        private static Usuario instancia;

        public static Usuario Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Usuario();
            }
            return instancia;
        }

        public bool LogIn(string email, string contraseña)
        {
            BE.Usuario usu = ObtenerUsuario(email);
            int cIngresoInc = ObtenerIngresos(usu.id);

            if (cIngresoInc < 3)
            {
                string contEncriptada = Encriptar(contraseña);
                bool ingresa = ValidarContraseña(contEncriptada);
                if (!ingresa)
                {
                    cIngresoInc++;
                }

            }
            return true;
        }

        private bool ValidarContraseña(string contEncriptada)
        {
            ///TODO
            return true;
        }

        private BE.Usuario ObtenerUsuario(string email)
        {
            List<BE.Usuario> usuarios = Retrive();

            var usu = usuarios.Where(s => s.email == email);

            return usu.FirstOrDefault();
        }

        private int ObtenerIngresos(int id)
        {
            int cIngresos = 0;
            string queryString = ConfigurationManager.AppSettings["GetUserLoginAttemptQ"] + id;

            using (SqlConnection connection = new SqlConnection(connectionString))
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

            return cIngresos;
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

        public bool Create(BE.Usuario ObjAlta)
        {
            bool returnValue = false;

            queryString = ConfigurationManager.AppSettings["CreateUserQ"];
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            queryString = ConfigurationManager.AppSettings["GetUserQ"];

            using (SqlConnection connection = new SqlConnection(connectionString))
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
            return new List<BE.Usuario>(); ///TODO
        }

        public bool Delete(BE.Usuario ObjDel)
        {
            throw new NotImplementedException();
        }

        public bool Update(BE.Usuario ObjUpd)
        {
            throw new NotImplementedException();
        }
    }
}
