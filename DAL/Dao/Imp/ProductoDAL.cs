namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;

    public class ProductoDAL : BaseDao, ICRUD<Producto>, IProductoDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        private readonly string queryString = string.Empty;

        public ProductoDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Crear(Producto objAlta)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string>() { objAlta.Descripcion,  }, new List<int>() { int.Parse(objAlta.CodigoProducto) });

            var queryString = string.Format(
                                "INSERT INTO Producto(Descripcion ,PUnitario, PVenta ,Stock ,DVH) " +
                                "VALUES({0}, {1}, {2}, {3}, {4})",
                                objAlta.Descripcion,
                                objAlta.PUnitario,
                                objAlta.PVenta,
                                objAlta.Stock,
                                digitoVH);

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public bool Borrar(Producto objDel)
        {
            var queryString = $"DELETE FROM Producto WHERE IdProducto = {objDel.IdProducto}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public List<Producto> Cargar()
        {
            var queryString = "SELECT * FROM Producto;";

            return CatchException(() =>
            {
                return Exec<Producto>(queryString);
            });
        }

        public bool Actualizar(Producto objUpd)
        {
            ////Cambiar por columnas de producto
            var queryString = $"UPDATE Producto SET Nombre = , Apellido = , Password = , Email = , Telefono = WHERE IdProducto = ";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public Producto ObtenerProductoPorCodigo(string codigo)
        {
            var queryString = $"SELECT * FROM Producto WHERE IdProducto = @codigo";

            return CatchException(() =>
            {
                return Exec<Producto>(queryString, new { @codigo = codigo})[0];
            });
        }
    }
}
