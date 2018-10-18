﻿namespace DAL.Imp
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
                    var bitacora = (List<Bitacora>)connection.Query<Bitacora>(queryString);
                    return bitacora[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public int ObtenerUltimoIdBitacora()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Bitacora]') AS Current_Identity;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var bitacoraId = connection.Query<int>(queryString).AsList();
                    return bitacoraId[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return 0;
            }
        }

        public int GenerarDVH(Usuario usu)
        {
            var bitacoraId = ObtenerUltimoIdBitacora();
            var bitacora = LeerBitacoraConId(bitacoraId);
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { bitacora.InformacionAsociada, bitacora.Actividad, bitacora.Criticidad }, new List<int> { usu.IdUsuario, bitacoraId });
            return digitoVH;
        }
    }
}
