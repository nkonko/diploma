namespace DAL.Dao.Imp
{
    using BE.Entidades;
    using DAL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
            var optQuery = "SELECT * FROM UsuarioPatente";
            var patentesUsuarios = new List<UsuarioPatente>();

            CatchException(() =>
            {
                patentesUsuarios = Exec<UsuarioPatente>(optQuery);
            });

            if (!patentesUsuarios.Exists(x => x.IdPatente == patentesId[0] && x.UsuarioId == usuarioId))
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
        }

        public bool NegarPatenteUsuario(int patenteId, int usuarioId)
        {
            var optQuery = "SELECT * FROM UsuarioPatente";
            var patentesUsuarios = new List<UsuarioPatente>();
            var queryString = string.Empty;

            CatchException(() =>
             {
                 patentesUsuarios = Exec<UsuarioPatente>(optQuery);
             });

            if (patentesUsuarios.Exists(x => x.IdPatente == patenteId && x.UsuarioId == usuarioId))
            {
                queryString = $"UPDATE UsuarioPatente SET Negada = 1 WHERE UsuarioId = @usuarioId AND IdPatente = @patenteId";
            }
            else
            {
                var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { patenteId, usuarioId });
                queryString = $"INSERT INTO UsuarioPatente(IdPatente, UsuarioId, Negada, DVH) VALUES ({patenteId},{usuarioId}, 1, {digitoVH})";
            }

            return CatchException(() =>
             {
                 return Exec(queryString, new { @usuarioId = usuarioId, @patenteId = patenteId });
             });
        }

        public bool HabilitarPatenteUsuario(int patenteId, int usuarioId)
        {
            var queryString = $"UPDATE UsuarioPatente SET Negada = 0 WHERE UsuarioId = @usuarioId AND IdPatente = @patenteId";

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

        public bool CheckeoDePatentesParaBorrar(Usuario usuario)
        {
            var returnValue = false;

            var usuariopatente = ConsultarPatenteUsuario(usuario.UsuarioId).Select(x => x.IdPatente).ToList();

            var familiasUsuarioIds = usuario.Familia.Select(x => x.FamiliaId).ToList();

            foreach (var pat in usuariopatente)
            {
                returnValue = EsPatenteEnUso(pat, usuario.UsuarioId);
                if (!returnValue)
                {
                    break;
                }
            }

            foreach (var familiaId in familiasUsuarioIds)
            {
                returnValue = EsPatenteFamiliaEnUso(familiaId, usuario.UsuarioId);
            }

            return returnValue;
        }

        public bool EsPatenteEnUso(int patenteId, int usuarioId)
        {
            var queryUsuarios = string.Format("SELECT UsuarioId FROM UsuarioPatente WHERE IdPatente = {0}", patenteId);
            var usuarios = new List<int>();
            var returnValue = false;

            CatchException(() =>
            {
                usuarios = Exec<int>(queryUsuarios);
            });

            if (usuarios.Count > 1)
            {
                returnValue = true;
            }
            else if (!usuarios.Any(x => x == usuarioId))
            {
                returnValue = true;
            }

            return returnValue;
        }

        private bool EsPatenteFamiliaEnUso(int familiaId, int usuarioId)
        {
            var returnValue = false;
            var queryPatFamilia = string.Format("SELECT IdPatente FROM FamiliaPatente WHERE FamiliaId = {0}", familiaId);

            var patentesFamilia = new List<int>();

            CatchException(() =>
            {
                patentesFamilia = Exec<int>(queryPatFamilia);
            });

            var idsPat = string.Join(",", patentesFamilia);

            ///Buscar como checkear que esa familia pertenezca a ese usuario SI otro usuario tiene la misma familia pero 
            ///no tiene asignada la patente si la recibe por la familia puedo eliminar al usuario
            var familiasIds = new List<int>();
            var queryFamilias = string.Format("SELECT DISTINCT FamiliaId FROM FamiliaPatente WHERE IdPatente IN ({0})", idsPat);
            var usuariosConFamilia = new List<int>();

            CatchException(() =>
            {
                familiasIds = Exec<int>(queryFamilias);

                var idsFam = string.Join(",", familiasIds);

                var queryFamiliaUsuario = string.Format("SELECT DISTINCT UsuarioId FROM FamiliaUsuario WHERE FamiliaId IN ({0})", idsFam);

                usuariosConFamilia = Exec<int>(queryFamiliaUsuario);
            });

            ///si hay mas de un usuario con la familia que tiene la patente entonces si me la puedo sacar sin importar si yo soy el que tiene esa familia
            if (usuariosConFamilia.Count > 1)
            {
                returnValue = true;
            }

            ////si otro tiene esa familia entonces yo me la puedo sacar

            else if (usuariosConFamilia[0] != usuarioId)
            {
                returnValue = true;
            }

            ///falta validacion 29 pasos hay un usuario con todas las patentes pero no me deja eliminar uno que tiene una familia y hereda las 
            ///patentes

            return returnValue;
        }
    }
}