﻿namespace DAL.Dao.Imp
{
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;

    public class ClienteDAL : BaseDao, IClienteDAL
    {
        public bool Actualizar(Cliente objUpd)
        {
            var queryString = $"UPDATE Cliente SET NombreCompleto = @nombre, Email = @email, Telefono = @telefono, Domicilio = @domicilio WHERE ClienteId = @ClienteId";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @nombre = objUpd.NombreCompleto,
                        @email = objUpd.Email,
                        @telefono = objUpd.Telefono,
                        @domicilio = objUpd.Domicilio,
                        @ClienteId = objUpd.ClienteId
                    });
            });
        }

        public void ActualizarSaldo(int Saldo)
        {
        }

        public bool Borrar(Cliente objDel)
        {
            var queryString = string.Format("UPDATE Cliente SET Activo = 0 WHERE ClienteId = {0}", objDel.ClienteId);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<Cliente> Cargar()
        {
            var queryString = "SELECT * FROM Cliente INNER JOIN CuentaCorriente ON Cliente.CuentaCorrienteId = CuentaCorriente.CuentaId WHERE Activo = 1";

            return CatchException(() =>
            {
                return Exec<Cliente>(queryString);
            });
        }

        public bool Crear(Cliente objAlta)
        {
            var cuentaQueryString = "INSERT INTO CuentaCorriente (Saldo) Values (5000)";
            var idCuenta = 0;
            CatchException(() =>
            {
                Exec(cuentaQueryString);
            });

            var lastIndexString = "SELECT IDENT_CURRENT ('[dbo].[CuentaCorriente]') AS Current_Identity;";

            CatchException(() =>
            {
                idCuenta = Exec<int>(lastIndexString)[0];
            });

            var queryString = "INSERT INTO Cliente(CuentaCorrienteId, NombreCompleto, Email, Telefono, Domicilio, Activo) VALUES (" + idCuenta + ", @nombre, @email, @telefono," +
                " @domicilio, @activo)";

            return CatchException(() =>
            {
                return Exec(
                    queryString,
                    new
                    {
                        @nombre = objAlta.NombreCompleto,
                        @email = objAlta.Email,
                        @telefono = objAlta.Telefono,
                        @domicilio = objAlta.Domicilio,
                        @activo = 1
                    });
            });
        }
    }
}
