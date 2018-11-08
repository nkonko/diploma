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

            var queryString = $"DELETE FROM Familia WHERE FamiliaId = {familia.FamiliaId}";

            return CatchException(() =>
             {
                 return Exec(queryString);
             });
        }

        public List<Familia> Cargar()
        {
            var queryString = "SELECT * FROM Familia;";

            return CatchException(() =>
            {
                return Exec<Familia>(queryString);
            });
        }

        public bool ComprobarUsoFamilia(int familiaId)
        {
            var result = new List<int>();
            var queryString = "SELECT FamiliaId FROM FamiliaUsuario WHERE FamiliaId = @idfamilia";

            CatchException(() =>
           {
               result = Exec<int>(queryString, new { @idfamilia = familiaId });
           });

            if (result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Crear(Familia objAlta)
        {
            var queryString = $"INSERT INTO Familia(Descripcion) VALUES ('{objAlta.Descripcion}')";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public void GuardarFamiliaUsuario(int familiaId, int usuarioId)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { familiaId, usuarioId });
            var queryString = $"INSERT INTO FamiliaUsuario(FamiliaId, UsuarioId, DVH) VALUES('{familiaId}','{usuarioId}','{digitoVH}')";

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public string ObtenerDescripcionFamiliaPorId(int familiaId)
        {
            var queryString = $"SELECT Descripcion FROM Familia WHERE FamiliaId = {familiaId}";

            return CatchException(() =>
            {
                return Exec<string>(queryString)[0];
            });
        }

        public List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId)
        {
            var famsdesc = new List<string>();

            foreach (var id in familiaId)
            {
                var queryString = $"SELECT Descripcion FROM Familia WHERE FamiliaId = {id}";

                CatchException(() =>
                {
                    famsdesc.Add(Exec<string>(queryString)[0]);
                });
            }

            return famsdesc;
        }

        //// Cambiar a cargar y usar linq para devolver la familia que coincida con la descripcion para no repetir codigo
        public Familia ObtenerFamiliaConDescripcion(string descripcion)
        {
            var queryString = $"SELECT * from Familia Where Descripcion = '{descripcion}'";

            return CatchException(() =>
            {
                return Exec<Familia>(queryString)[0];
            });
        }

        public int ObtenerIdFamiliaPorDescripcion(string descripcion)
        {
            var queryString = "SELECT FamiliaId FROM Familia WHERE Descripcion = @descripcion";

            return CatchException(() =>
            {
                return Exec<int>(queryString, new { @descripcion = descripcion })[0];
            });
        }

        public int ObtenerIdFamiliaPorUsuario(int usuarioId)
        {
            var queryString = $"SELECT FamiliaId FROM FamiliaUsuario WHERE UsuarioId = {usuarioId}";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId)
        {
            var famIds = new List<int>();

            var queryString = $"SELECT FamiliaId FROM FamiliaUsuario WHERE UsuarioId = {usuarioId}";

             famIds = CatchException(() =>
            {
                return Exec<int>(queryString);
            });
            return famIds;
        }

        public List<Patente> ObtenerPatentesFamilia(int familiaId)
        {
            var queryString = $"SELECT IdPatente FROM FamiliaPatente WHERE FamiliaId = {familiaId}";

            return CatchException(() =>
            {
                return Exec<Patente>(queryString);
            });
        }

        public List<Patente> ObtenerPatentesFamilia(List<int> familiaId)
        {
            var patentes = new List<Patente>();

            foreach (var id in familiaId)
            {
                var queryString = $"SELECT IdPatente FROM FamiliaPatente WHERE FamiliaId = {id}";

                patentes = CatchException(() =>
                {
                    return Exec<Patente>(queryString);
                });
            }

            return patentes;
        }
    }
}
