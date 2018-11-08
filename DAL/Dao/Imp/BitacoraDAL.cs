namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Dao;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    public class BitacoraDAL : BaseDao, IBitacoraDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public BitacoraDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public void FiltrarBitacora(FiltrosBitacora filtros)
        {
            var queryString = new StringBuilder();

            var baseQuery = string.Format("SELECT * FROM Bitacora WHERE Fecha >= {0} AND Fecha <= {1} ", filtros.FechaDesde, filtros.FechaHasta);

            queryString.Append(baseQuery);

            if (filtros.IdsUsuarios.Count > 0)
            {
                queryString.Append(string.Format("AND UsuarioId IN ({0})", filtros.IdsUsuarios));
            }

            if (filtros.Criticidades.Count > 0)
            {
                queryString.Append(string.Format("AND Criticidad IN ({0})", filtros.Criticidades));
            }

            CatchException(() =>
            {
                return Exec(queryString.ToString());
            });
        }

        public Bitacora LeerBitacoraConId(int bitacoraId)
        {
            var queryString = $"SELECT * FROM Bitacora WHERE IdLog = {bitacoraId}";

            return CatchException(() =>
             {
                 return Exec<Bitacora>(queryString.ToString())[0];
             });
        }

        public int ObtenerUltimoIdBitacora()
        {
            var queryString = "SELECT IDENT_CURRENT ('[dbo].[Bitacora]') AS Current_Identity;";

            return CatchException(() =>
            {
                return Exec<int>(queryString.ToString())[0];
            });
        }

        public int GenerarDVH(Usuario usu)
        {
            var bitacora = new Bitacora();
            var bitacoraId = ObtenerUltimoIdBitacora();

            if (bitacoraId == 1)
            {
                bitacora.InformacionAsociada = "primer login";
                bitacora.Actividad = "Login";
                bitacora.Criticidad = "primer Login";
            }

            bitacora = LeerBitacoraConId(bitacoraId);
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { bitacora.InformacionAsociada, bitacora.Actividad, bitacora.Criticidad }, new List<int> { usu.UsuarioId, bitacoraId });
            return digitoVH;
        }
    }
}
