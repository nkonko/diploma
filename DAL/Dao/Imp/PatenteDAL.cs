namespace DAL.Dao.Imp
{
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class PatenteDAL : BaseDao, IPatenteDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public PatenteDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool AsignarPatente(int familiaId, int patenteId)
        {
            var asignado = false;
            var digitoVerificadorHorizontal = digitoVerificador.CalcularDVHorizontal(new List<string>(), new List<int>() { familiaId, patenteId });
            CatchException(() =>
              {
                  asignado = Exec($"INSERT INTO FamiliaPatente (FamiliaId, IdPatente, DVH) VALUES ({familiaId}, {patenteId}, {digitoVerificadorHorizontal})");
              });

            return asignado;
        }

        public bool BorrarPatente(int familiaId, int patenteId)
        {
            var borrada = false;

            CatchException(() =>
            {
                borrada = Exec($"DELETE FROM FamiliaPatente WHERE FamiliaId = {familiaId} AND IdPatente = {patenteId}");
            });

            return borrada;
        }

        public List<Patente> Cargar()
        {
            var queryString = "SELECT * FROM Patente";

            return CatchException(() =>
            {
                return Exec<Patente>(queryString);
            });
        }

        public void GuardarPatentesUsuario(List<int> patentesId, int usuarioId)
        {
            foreach (var id in patentesId)
            {
                var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { id, usuarioId });
                var queryString = $"INSERT INTO UsuarioPatente(IdPatente, UsuarioId, Negada, DVH) VALUES ({id},{usuarioId}, 0, {digitoVH})";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
        }

        public bool NegarPatenteUsuario(int patenteId, int usuarioId)
        {
            var queryString = $"UPDATE UsuarioPAtente SET Negada = 1 WHERE UsuarioId = @usuarioId AND IdPatente = @patenteId";

            return CatchException(() =>
             {
                 return Exec(queryString, new { @usuarioId = usuarioId, @patenteId = patenteId });
             });
        }

        public bool HabilitarPatenteUsuario(int patenteId, int usuarioId)
        {
            var queryString = $"UPDATE UsuarioPAtente SET Negada = 0 WHERE UsuarioId = @usuarioId AND IdPatente = @patenteId";

            return CatchException(() =>
            {
                return Exec(queryString, new { @usuarioId = usuarioId, @patenteId = patenteId });
            });
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            var queryString = $"SELECT IdPatente FROM Patente WHERE Descripcion = '{descripcion}'";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public bool ComprobarPatentesUsuario(int usuarioId)
        {
            var query = string.Format("SELECT UsuarioId FROM UsuarioPatente WHERE UsuarioId = '{0}'", usuarioId);
            var ids = new List<int>();

            CatchException(() =>
            {
                ids = Exec<int>(query);
            });

            if (ids.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId)
        {
            var queryString = "SELECT FamiliaId, IdPatente FROM FamiliaPatente WHERE FamiliaId = @idFamilia";

            return CatchException(() =>
            {
                return Exec<FamiliaPatente>(queryString, new { @idFamilia = familiaId });
            });
        }

        public List<UsuarioPatente> ConsultarPatenteUsuario(int usuarioId)
        {
            var queryString = "SELECT UsuarioId, IdPatente, Negada FROM USuarioPatente WHERE UsuarioId = @usuarioId";

            return CatchException(() =>
            {
                return Exec<UsuarioPatente>(queryString, new { @usuarioId = usuarioId });
            });
        }

        public void BorrarPatentesUsuario(List<int> patentesId, int usuarioId)
        {
            foreach (var id in patentesId)
            {
                var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { id, usuarioId });
                var queryString = $"DELETE FROM UsuarioPatente WHERE IdPatente = {id} AND UsuarioId = {usuarioId}";

                CatchException(() =>
                {
                    return Exec(queryString);
                });
            }
        }
    }
}
