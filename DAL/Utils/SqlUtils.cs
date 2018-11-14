namespace DAL.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlUtils
    {
        public static List<string> Tables { get; set; } = GetTables();

        public SqlUtils()
        {
        }

        public static SqlConnection Connection()
        {
            var conn = new SqlConnection(ConfigurationManager.AppSettings["connString"]);
            return conn;
        }

        private static List<string> GetTables()
        {
            using (SqlConnection connection = Connection())
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> tableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    tableNames.Add(row[2].ToString());
                }

                return tableNames;
            }
        }

        private static string GetStringsFromRegister(string table, string connectionString)
        {
            string returnValue  = "not implemented";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
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
