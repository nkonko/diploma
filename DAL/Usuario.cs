namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data;
    public class Usuario : BE.ICRUD<BE.Usuario>
    {
        SqlCommand comm = new SqlCommand();
        string connectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog = SYSANALIZER2; Integrated Security = True";
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


        public bool Create(BE.Usuario ObjAlta)
        {

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

            bool returnValue = false;

            return returnValue;
        }

        public List<BE.Usuario> Retrive()
        {
            throw new NotImplementedException();
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
