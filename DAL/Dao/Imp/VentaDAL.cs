namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class VentaDAL : ICRUD<Venta>, IVentaDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public VentaDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Crear(Venta objAlta)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string>() { }, new List<int>() { });

            var queryString = "INSERT INTO Venta(Fecha, EstadoId,TipoVentaId,ClienteId,Monto,DVH) VALUES (@fecha, @estado, @tipoVenta, @cliente, @monto, @dvh)";
            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(
                        queryString,
                        new
                        {
                            @fecha = objAlta.Fecha,
                            @estado = objAlta.EstadoId,
                            @tipoVenta = objAlta.TipoVentaId,
                            @cliente = objAlta.ClienteId,
                            @monto = objAlta.Monto,
                            @dvh = digitoVH
                        });

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
        }

        public bool Borrar(Venta objDel)
        {
            var queryString = $"DELETE FROM Venta WHERE VentaId = {objDel.VentaId}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
        }

        public List<Venta> Cargar()
        {
            var queryString = "SELECT * FROM Venta;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var ventas = (List<Venta>)connection.Query<Venta>(queryString);

                    return ventas;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public bool Actualizar(Venta objUpd)
        {
            ////terminar query
            var queryString = string.Format("UPDATE  WHERE IdVenta = {0}", objUpd.VentaId);

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return false;
        }
    }
}
