namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class FamiliaDAL : ICRUD<Familia>, IFamiliaDAL
    {
        public bool Actualizar(Familia objUpd)
        {
            ////Revisar no estoy obteniendo los cambios, cambiar y recibir objOld y objNew
            var returnValue = false;

            var familia = ObtenerFamiliaConDescripcion(objUpd.Descripcion);

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

            var familia = ObtenerFamiliaConDescripcion(objDel.Descripcion);

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
            var queryString = "SELECT Descripcion FROM Familia;";

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

            var queryString = $"INSERT INTO Familia(Descripcion) VALUES ({objAlta.Descripcion})";

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
        //// Cambiar a cargar y usar linq para devolver la familia que coincida con la descripcion para no repetir codigo
        public Familia ObtenerFamiliaConDescripcion(string descripcion)
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

        public List<Patente> ObtenerPatentesFamilia(int familiaId)
        {
            var queryString = $"SELECT IdPatente FROM FamiliaPatente WHERE idFamilia = {familiaId}";

            using (IDbConnection connection = SqlUtils.Connection())
            {
                try
                {
                    connection.Open();
                    var patentes = (List<Patente>)connection.Query<Patente>(queryString);

                    return patentes;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
