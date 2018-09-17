namespace DAL
{
    using BE;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DigitoVerificador : IDigitoVerificador
    {

        public static SqlConnection Connection()
        {
            var conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=SYSANALIZER2;Integrated Security=True";
            return conn;
        }

        public static int CalcularDVHorizontal(List<string> columnas, string entidad)
        {
            var sqlUtils = new SqlUtils();
            var lalal = sqlUtils.Tables;

            int cantCol = ObtenerColumnas(entidad);

            StringBuilder sB = new StringBuilder();

            var subQuery = "SELECT ASCII(Substring(Concat())";
            sB.Append(subQuery);
            for (var i = 0; i < cantCol; i++)
            {
                //string.Format("LEN({" + i + "}), ", columnas[i]).Length();
                sB.Insert(30, string.Format("LEN({" + i + "}), ", columnas[i]));
            }

            var query = string.Format(@"SELECT ASCII(Substring(Concat(LEN(IdUsuario), LEN(Email), LEN(Password), LEN(Activo)), 1, 1)) * 1 +
                                        ASCII(Substring(Concat(LEN(IdUsuario), LEN(Email), LEN(Password), LEN(Activo)), 2, 2)) * 2 FROM Usuario");


            return 0;
        }

        public BE.DigitoVerificador ObtenerDigito(int id_Entidad)
        {
            var sqlQuery = string.Format(@"SELECT valor FROM DigitoVerificadorVertical WHERE IdEntidad = {0}", id_Entidad);

            var comm = new SqlCommand();

            using (SqlConnection connection = Connection())
            {
                var digitoVerificador = new BE.DigitoVerificador();
                try
                {
                    comm.CommandText = sqlQuery;
                    comm.Connection = connection;
                    comm.CommandType = CommandType.Text;

                    var da = new SqlDataAdapter();
                    da.SelectCommand = comm;

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        digitoVerificador.ValorDigito = Convert.ToInt32(dr["ValorDigitoVerificador"]);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                return digitoVerificador;
            }
        }

        private static int ObtenerColumnas(string entidad)
        {
            int cantCol = 0;
            var queryColumns = "SELECT count(*) as cantidad FROM information_schema.columns WHERE table_name = '" + entidad + "'";

            using (SqlConnection connection = Connection())
            {
                SqlCommand command = new SqlCommand(queryColumns, connection);
                try
                {
                    connection.Open();
                    cantCol = int.Parse(command.ExecuteScalar().ToString());

                    return cantCol;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return cantCol;
            }
        }
    }
}
