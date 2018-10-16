namespace DAL.Imp
{
    using BE;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class BitacoraDAL : IBitacoraDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public BitacoraDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public void FiltrarBitacora(Filtros filtros)
        {
            var queryString = new StringBuilder();

            var baseQuery = string.Format("SELECT * FROM Bitacora WHERE Fecha >= {0} AND Fecha <= {1} ", filtros.FechaDesde, filtros.FechaHasta);

            queryString.Append(baseQuery);

            if (filtros.IdsUsuarios.Count > 0)
            {
                queryString.Append(string.Format("AND IdUsuario IN ({0})", filtros.IdsUsuarios));
            }

            if (filtros.Criticidades.Count > 0)
            {
                queryString.Append(string.Format("AND Criticidad IN ({0})", filtros.Criticidades));
            }

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Bitacora LeerBitacoraConId(int bitacoraId)
        {
            var queryString = $"SELECT * FROM Bitacora WHERE IdLog = {bitacoraId}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var bitacora = (Bitacora)connection.Query<Bitacora>(queryString);
                    return bitacora;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }
        public string ObtenerUltimoIdBitacora()
        {
            ////Cambiar Log por Bitacora
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Log]') AS Current_Identity;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var bitacoraId = connection.Query<int>(queryString).ToString();
                    return bitacoraId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public int GenerarDVH(Usuario usu)
        {
            var bitacoraId = ObtenerUltimoIdBitacora();
            LeerBitacoraConId(Int16.Parse(bitacoraId));
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { usu.IdUsuario });
            return 0;
        }

    }
}
