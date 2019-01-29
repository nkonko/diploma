﻿namespace DAL.Utils
{
    using log4net.Appender;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class SqlUtils
    {
        //private static log4net.ILog log;

        public static List<string> Tables { get; set; } = GetTables();

        public SqlUtils()
        {
        }

        public static SqlConnection Connection()
        {
            SetearConfiguracion();
            var conn = new SqlConnection(ConfigurationManager.AppSettings["connString"]);
            return conn;
        }

        private static void SetearConfiguracion()
        {
            //log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionString = config
                .AppSettings.Settings["connString"]
                .Value;
            var startIndex = connectionString.IndexOf('=');
            var endIndex = connectionString.IndexOf('\\');
            var cambiarNombre = connectionString.Substring(startIndex + 1, endIndex - startIndex - 1);
            var nuevoConnectionString = connectionString.Replace(cambiarNombre, Environment.MachineName);
            config.AppSettings.Settings["connString"].Value = nuevoConnectionString;
            //log.Logger.Repository.GetAppenders().OfType<AdoNetAppender>().SingleOrDefault().ConnectionString = nuevoConnectionString;
            config.Save(ConfigurationSaveMode.Modified , true);
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
            string returnValue = "not implemented";

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
