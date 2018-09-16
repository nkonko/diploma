namespace DAL
{
    using DAL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class DigitoVerificador : IDigitoVerificador
    {

        public static SqlConnection Connection()
        {
            var conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=SYSANALIZER2;Integrated Security=True";
            return conn;
        }

        public int CalcularDVHorizontal(List<string> registros)
        {
            var sqlUtils = new SqlUtils();
            var lalal = sqlUtils.tables;
            return 0;
        }

        public BE.DigitoVerificador ObtenerDigito(int id_Entidad)
        {
            var sqlQuery = string.Format("SELECT valor FROM DigitoVerificadorVertical WHERE IdEntidad = {0}", id_Entidad);

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
    }
}
