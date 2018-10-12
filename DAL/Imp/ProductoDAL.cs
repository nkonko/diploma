namespace DAL
{
    using DAL.Utils;
    using Dapper;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class ProductoDAL : BE.ICRUD<BE.Producto>
    {
        public ILog Log { get; set; }

        private readonly IDigitoVerificador digitoVerificador;

        private readonly string queryString = string.Empty;

        public ProductoDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Crear(BE.Producto objAlta)
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

            Log.Info("Producto Creado");
            return returnValue;
        }

        public bool Borrar(BE.Producto objDel)
        {
            throw new NotImplementedException();
        }

        public List<BE.Producto> Cargar()
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(BE.Producto objUpd)
        {
            throw new NotImplementedException();
        }
    }
}
