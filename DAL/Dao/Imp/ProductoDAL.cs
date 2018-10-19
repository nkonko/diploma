namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ProductoDAL : ICRUD<Producto>, IProductoDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        private readonly string queryString = string.Empty;

        public ProductoDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Crear(Producto objAlta)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string>() { objAlta.Descripcion }, new List<int>() { objAlta.NroProd });

            var queryString = string.Format(
                                "INSERT INTO Producto(Descripcion ,PUnitario, PVenta ,Stock ,DVH) " +
                                "VALUES({0}, {1}, {2}, {3}, {4})",
                                objAlta.Descripcion,
                                objAlta.PUnitario,
                                objAlta.PVenta,
                                objAlta.Stock,
                                digitoVH);

            bool returnValue = false;

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);

                    return returnValue = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public bool Borrar(Producto objDel)
        {
            var queryString = $"DELETE FROM Producto WHERE IdProducto = {objDel.IdProducto}";

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

        public List<Producto> Cargar()
        {
            var queryString = "SELECT * FROM Producto;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var productos = (List<Producto>)connection.Query<Producto>(queryString);

                    return productos;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public bool Actualizar(Producto objUpd)
        {
            ////Cambiar por columnas de producto
            var queryString = $"UPDATE Producto SET Nombre = , Apellido = , Password = , Email = , Telefono = WHERE IdProducto = ";

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
