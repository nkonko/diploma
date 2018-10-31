namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class FamiliaDAL : BaseDao, ICRUD<Familia>, IFamiliaDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public FamiliaDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

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
            var familia = ObtenerFamiliaConDescripcion(objDel.Descripcion);

            var queryString = $"DELETE FROM Familia WHERE IdFamilia = {familia.IdFamilia}";

            CatchException(() =>
            {
                return Exec<Familia>(queryString);
            });

            return false;
        }

        public List<Familia> Cargar()
        {
            var queryString = "SELECT * FROM Familia;";

            return CatchException(() =>
            {
                return Exec<Familia>(queryString);
            });
        }

        public bool Crear(Familia objAlta)
        {
            var queryString = $"INSERT INTO Familia(Descripcion) VALUES ({objAlta.Descripcion})";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public void GuardarFamiliaUsuario(int familiaId, int usuarioId)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { familiaId, usuarioId });
            var queryString = $"INSERT INTO FamiliaUsuario(IdFamilia, IdUsuario, DVH) VALUES({familiaId},{usuarioId},{digitoVH})";

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public string ObtenerDescripcionFamiliaPorId(int familiaId)
        {
            var queryString = $"SELECT Descripcion FROM Familia WHERE IdFamilia = {familiaId}";

            return CatchException(() =>
            {
                return Exec<string>(queryString)[0];
            });
        }

        //// Cambiar a cargar y usar linq para devolver la familia que coincida con la descripcion para no repetir codigo
        public Familia ObtenerFamiliaConDescripcion(string descripcion)
        {
            var queryString = $"SELECT * from Familia Where Descripcion = {descripcion}";

            return CatchException(() =>
            {
                return Exec<Familia>(queryString)[0];
            });
        }

        public int ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            var queryString = "SELECT IdFamilia FROM Familia";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public int ObtenerIdFamiliaPorUsuario(int usuarioId)
        {
            var queryString = $"SELECT IdFamilia FROM FamiliaUsuario WHERE IdUsuario = {usuarioId}";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public List<Patente> ObtenerPatentesFamilia(int familiaId)
        {
            var queryString = $"SELECT IdPatente FROM FamiliaPatente WHERE idFamilia = {familiaId}";

            return CatchException(() =>
            {
                return Exec<Patente>(queryString);
            });
        }
    }
}
