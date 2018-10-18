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
            var returnValue = false;
        }

        public bool Borrar(Familia objDel)
        {
            var returnValue = false;
        }

        public List<Familia> Cargar()
        {
            throw new System.NotImplementedException();
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
    }
}
