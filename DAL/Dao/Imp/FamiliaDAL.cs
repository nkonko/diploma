namespace DAL.Dao.Imp
{
    using BE;
    using BE.Entidades;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    public class FamiliaDAL : BaseDao, ICRUD<Familia>, IFamiliaDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public FamiliaDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool Actualizar(Familia objUpd)
        {
            var queryString = $"UPDATE Familia SET Descripcion = '{objUpd.Descripcion}' WHERE FamiliaId = {objUpd.FamiliaId}";

            return CatchException(() =>
            {
                return Exec(queryString);
            });
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

        public void BorrarFamiliasUsuario(List<Familia> familias, int usuarioId)
        {
            foreach (var familia in familias)
            {
                var queryString = $"DELETE FROM FamiliaUsuario WHERE FamiliaId = {familia.FamiliaId} and UsuarioId = {usuarioId}";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
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

        public void GuardarFamiliasUsuario(List<int> familiasId, int usuarioId)
        {
            foreach (var id in familiasId)
            {
                var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { id, usuarioId });
                var queryString = $"INSERT INTO FamiliaUsuario(FamiliaId, UsuarioId, DVH) VALUES('{id}','{usuarioId}','{digitoVH}')";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
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

        public Familia ObtenerFamiliaConDescripcion(string descripcion)
        {
            var queryString = $"SELECT * from Familia Where Descripcion = '{descripcion}'";
            var familia = new Familia();

            CatchException(() =>
            {
                familia = Exec<Familia>(queryString)[0];
            });

            familia.Patentes = ObtenerPatentesFamilia(familia.FamiliaId);

            return familia;
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

        public List<Familia> ObtenerFamiliasUsuario(int usuarioId)
        {
            var familiasDb = Cargar();
            var familiaUsuario = ObtenerIdsFamiliasPorUsuario(usuarioId);

            return familiasDb.FindAll(x => familiaUsuario.Any(y => y == x.FamiliaId));
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
            var patentes = new List<Patente>();
            var queryString = $"SELECT distinct IdPatente FROM FamiliaPatente WHERE FamiliaId = {familiaId}";

            CatchException(() =>
            {
                patentes = Exec<Patente>(queryString);
            });

            foreach (var patente in patentes)
            {
                var queryPatente = $"SELECT Descripcion FROM Patente WHERE IdPatente = {patente.IdPatente}";
                patente.Descripcion = Exec<string>(queryPatente).FirstOrDefault();
            }

            return patentes;
        }

        public List<Patente> ObtenerPatentesDeFamilias(List<int> familiaId)
        {
            var patentes = new List<Patente>();

            foreach (var id in familiaId)
            {
                var queryString = $"SELECT * FROM FamiliaPatente WHERE FamiliaId = {id}";

                patentes = CatchException(() =>
                {
                    return Exec<Patente>(queryString);
                });
            }

            return patentes;
        }

        public void BorrarFamiliaDeFamiliaPatente(int familiaId)
        {
            var queryString = string.Format("DELETE FROM FamiliaPatente WHERE FamiliaId = {0}", familiaId);

            CatchException(() =>
            {
                Exec(queryString);
            });
        }

        public List<Usuario> ObtenerUsuariosPorFamilia(int familiaId)
        {
            var listaUsuarios = new List<Usuario>();
            var queryString = string.Format("SELECT DISTINCT UsuarioId FROM FamiliaUsuario WHERE FamiliaId = {0}", familiaId);

            var ids = Exec<int>(queryString);

            if (ids.Count > 0)
            {
                var stringIds = string.Join<int>(",", ids);

                CatchException(() =>
                {
                    var queryUsuario = string.Format("SELECT * FROM Usuario WHERE Activo = 1 AND UsuarioId IN ({0})", stringIds);

                    listaUsuarios = Exec<Usuario>(queryUsuario);
                });

                foreach (var usuario in listaUsuarios)
                {
                    usuario.Familia = new List<Familia>();
                    usuario.Patentes = new List<Patente>();

                    usuario.Familia = ObtenerFamiliasUsuario(usuario.UsuarioId);
                }
            }

            return listaUsuarios;
        }

        public List<FamiliaUsuario> ObtenerTodasLasFamiliasYUsuarios()
        {
            var query = "SELECT * FROM FamiliaUsuario";
            var familiasUsuarios = new List<FamiliaUsuario>();

            CatchException(() =>
            {
                familiasUsuarios = Exec<FamiliaUsuario>(query);
            });

            return familiasUsuarios;
        }
    }
}
