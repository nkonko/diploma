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
            ////Cambiar por los datos de venta
            var queryString = string.Format(
                        "INSERT INTO Venta() VALUES ()",
                       ////objAlta.Nombre,
                       ////objAlta.Apellido,
                       ////contEncript,
                       ////objAlta.Email,
                       ////objAlta.Telefono,
                       ////objAlta.CIngresos = 0,
                       ////objAlta.IdCanalVenta,
                       ////objAlta.IdIdioma,
                       ////Convert.ToByte(objAlta.PrimerLogin = true),
                       digitoVH,
                       0);
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

        public bool Borrar(Venta objDel)
        {
            var queryString = $"DELETE FROM Venta WHERE IdVenta = {objDel.Id}";

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
            var queryString = string.Format("UPDATE Venta SET Descripcion = {1} WHERE IdVenta = {0}", objUpd.Id, objUpd.Descripcion);

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
