namespace DAL.Imp
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using BE;
    using DAL.Utils;
    using Dapper;

    public class FamiliaDAL : ICRUD<Familia>, IFamiliaDAL
    {
        public bool Actualizar(Familia objUpd)
        {
            ////Revisar no estoy obteniendo los cambios, cambiar y recibir objOld y objNew
            var returnValue = false;

            var familia = ObtenerFamilia(objUpd.Descripcion);

            ////var queryString = $"UPDATE Familia SET Descripcion = '{nuevaDescripcion}' WHERE IdFamilia = {objUpd.IdFamilia}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    ////connection.Execute(queryString);

                    return returnValue = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public bool Borrar(Familia objDel)
        {
            var returnValue = false;

            var familia = ObtenerFamilia(objDel.Descripcion);

            var queryString = $"DELETE FROM Familia WHERE IdFamilia = {familia.IdFamilia}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    connection.Execute(queryString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return returnValue;
        }

        public List<Familia> Cargar()
        {
            var queryString = "SELECT * FROM Familia;";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var familias = (List<Familia>)connection.Query<Familia>(queryString);

                    return familias;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }

        public bool Crear(Familia objAlta)
        {
            var returnValue = false;

            var queryString = string.Format(
                        "INSERT INTO Familia(Descripcion) VALUES ({0})", objAlta.Descripcion);

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

        private Familia ObtenerFamilia(string descripcion)
        {
            var queryString = $"SELECT * from Familia Where Descripcion = {descripcion}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var familia = (List<Familia>)connection.Query<Familia>(queryString);

                    return familia[0];
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
