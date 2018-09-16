namespace DAL.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlUtils
    {
        public List<string> tables { get; set; }

        public SqlUtils()
        {
            tables = GetTables(@"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=SYSANALIZER2;Integrated Security=True");
        }

        private static List<string> GetTables(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }

        private static string GetStringsFromRegister(string table, string connectionString)
        {
            string returnValue;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string aux;
                var queryString = "SELECT * FROM Usuario;";

                SqlCommand command = new SqlCommand(queryString, connection);
                DataTable dt = new DataTable();

                var da = new SqlDataAdapter(command);
                

                try
                {
                    connection.Open();

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {

                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return returnValue;
        }
    }
}
