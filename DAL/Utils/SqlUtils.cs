namespace DAL.Utils
{
    using EasyEncryption;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Xml;

    public class SqlUtils : BaseDao
    {
        public static readonly string AppConfigFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName + "\\App.config";
        public const string Key = "pass";

        public SqlUtils()
        {
        }

        public static SqlConnection Connection()
        {
            //EncriptarConnectionString();
            //var desencripted = DesEncriptarConnectionString();
            var conn = new SqlConnection(ConfigurationManager.AppSettings["connString"]);
            return conn;
        }

        public static List<string> GetTables()
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

        public int GenerarId(string campoId, string entidad)
        {
            var ultimoId = CatchException(() => Exec<int>($"SELECT {campoId} FROM {entidad}"));

            if (ultimoId.Count > 0)
            {
                return ultimoId.Last() + 1;
            }
            else
            {
                return 1;
            }
        }

        private static void SetearConfiguracion()
        {
            ////log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionString = config
                .AppSettings.Settings["connString"]
                .Value;
            var startIndex = connectionString.IndexOf('=');
            var endIndex = connectionString.IndexOf('\\');
            var cambiarNombre = connectionString.Substring(startIndex + 1, endIndex - startIndex - 1);
            var nuevoConnectionString = connectionString.Replace(cambiarNombre, Environment.MachineName);
            config.AppSettings.Settings["connString"].Value = nuevoConnectionString;
            ////log.Logger.Repository.GetAppenders().OfType<AdoNetAppender>().SingleOrDefault().ConnectionString = nuevoConnectionString;
            config.Save(ConfigurationSaveMode.Modified, true);
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

        public static string EncriptarASCII(string input)
        {
           return AesThenHmac.SimpleEncryptWithPassword(input, Key);
        }

        public static string DesencriptarASCII(string input)
        {
            return AesThenHmac.SimpleDecryptWithPassword(input, Key);
        }

        private static void EncriptarConnectionString()
        {
            var connString = ConfigurationManager.AppSettings["connString"];
            var encriptedConnString = EncriptarASCII(connString);

            XmlDocument doc = new XmlDocument();
            doc.Load(AppConfigFilePath);
            XmlNodeList xmlnode;
            xmlnode = doc.GetElementsByTagName("appSettings");
            foreach (XmlNode nodo in xmlnode)
            {
                nodo.FirstChild.Attributes[1].InnerText = encriptedConnString;
            }

            doc.Save(AppConfigFilePath);
        }

        private static string DesEncriptarConnectionString()
        {
            var connString = ConfigurationManager.AppSettings["connString"];
            var decryptedConnString = DesencriptarASCII(connString);

            return decryptedConnString;
        }
    }
}
