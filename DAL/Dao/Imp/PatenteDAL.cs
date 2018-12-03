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
        private readonly IUsuarioDAL usuarioDAL;
        private readonly IFamiliaDAL familiaDAL;

        public PatenteDAL(IDigitoVerificador digitoVerificador, IUsuarioDAL usuarioDAL, IFamiliaDAL familiaDAL)
        {
            this.digitoVerificador = digitoVerificador;
            this.usuarioDAL = usuarioDAL;
            this.familiaDAL = familiaDAL;
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
            List<UsuarioPatente> patentesUsuarios = ObtenerTodasLasPatentesYUsuarios();

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

        private List<UsuarioPatente> ObtenerTodasLasPatentesYUsuarios()
        {
            var optQuery = "SELECT * FROM UsuarioPatente";
            var patentesUsuarios = new List<UsuarioPatente>();

            CatchException(() =>
            {
                patentesUsuarios = Exec<UsuarioPatente>(optQuery);
            });
            return patentesUsuarios;
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

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool esBorrado = false, int idAQuitar = 0)
        {
            ///Si ningun usuario tiene patentes no se puede borrar ningun usuario
            if(!ComprobarTablaUsuarioPatente())
            {
                return false;
            }

            var diccionarioPatentes = new Dictionary<int, int>();
            List<Usuario> usuariosGlobal;
            List<int> familiasIds = usuario.Familia.Select(familia => familia.FamiliaId).ToList();

            CargaUsuario(usuario, requestFamiliaUsuario, idAQuitar, out usuariosGlobal);

            //Revisar metodo que obtiene las patentes de las familias, que trae???? las patentes de una familia sola o de todas
            if (!esBorrado)
            {
                if (usuarioDAL.ObtenerPatentesDeUsuario(usuario.UsuarioId).Count == familiaDAL.ObtenerPatentesDeFamilias(familiasIds).Count)
                {
                    if (usuario.Patentes.Count == familiaDAL.ObtenerPatentesDeFamilias(familiasIds).Count)
                    {
                        return true;
                    }
                }
            }

            CargarUsuariosGlobales(usuario, requestFamilia, usuariosGlobal);

            CargarDiccionario(usuario, diccionarioPatentes, usuariosGlobal);
            // Uno de los problemas esta en este metodo no checkea una a una las patentes sino todo el diccionario y encima tiene un and habria que
            // Separar las condiciones para hacer dos comprobaciones 
            if (diccionarioPatentes.Count > 0 && diccionarioPatentes.All(x => x.Value > 0))
            {
                return true;
            }

            return false;
        }

        private bool ComprobarTablaUsuarioPatente()
        {
            List<UsuarioPatente> patentesUsuarios = ObtenerTodasLasPatentesYUsuarios();

            return patentesUsuarios.Count > 0;
        }

        private void CargaUsuario(Usuario usuario, bool requestFamiliaUsuario, int idAQuitar, out List<Usuario> usuariosGlobal)
        {
            usuariosGlobal = usuarioDAL.Cargar();
            usuariosGlobal.RemoveAll(x => x.UsuarioId == usuario.UsuarioId);

            RemoverIdsFamilias(requestFamiliaUsuario, idAQuitar, usuario.Familia);

            SetearPatentesUsuario(usuario, usuario.Familia.Select(familia => familia.FamiliaId).ToList());
        }

        private static void CargarDiccionario(Usuario usuario, Dictionary<int, int> diccionarioPatentes, List<Usuario> usuariosGlobal)
        {
            //Si el usuario no tiene patentes no esta cargando ninguna al diccionario no deberia ser asi.
            foreach (var patenteUsuario in usuario.Patentes)
            {
                diccionarioPatentes.Add(patenteUsuario.IdPatente, 0);
                var contador = 0;

                foreach (var usuarioAComparar in usuariosGlobal)
                {
                    foreach (var patenteAComparar in usuarioAComparar.Patentes)
                    {
                        if (patenteUsuario.IdPatente == patenteAComparar.IdPatente)
                        {
                            contador++;
                            diccionarioPatentes[patenteUsuario.IdPatente] = contador;
                        }
                    }
                }
            }
        }

        private void CargarUsuariosGlobales(Usuario usuario, bool requestFamilia, List<Usuario> usuariosGlobal)
        {
            foreach (var usuarioAComparar in usuariosGlobal)
            {
                var familiasId = familiaDAL.ObtenerIdsFamiliasPorUsuario(usuarioAComparar.UsuarioId);

                usuarioAComparar.Familia = new List<Familia>();
                usuarioAComparar.Patentes = new List<Patente>();

                foreach (var idfam in familiasId)
                {
                    usuarioAComparar.Familia.Add(new Familia() { FamiliaId = idfam });

                    if (requestFamilia)
                    {
                        if (usuarioAComparar.Familia.Exists(a => usuario.Familia.All(x => a.FamiliaId == x.FamiliaId)))
                        {
                            usuarioAComparar.Familia.RemoveAll(x => x.FamiliaId == idfam);
                        }
                        else
                        {
                            usuarioAComparar.Patentes.AddRange(familiaDAL.ObtenerPatentesFamilia(idfam));
                        }
                    }
                    else
                    {
                        usuarioAComparar.Patentes.AddRange(familiaDAL.ObtenerPatentesFamilia(idfam));
                    }
                }

                CargarPatentesUsuariosGloables(usuarioAComparar);
            }
        }

        private void CargarPatentesUsuariosGloables(Usuario usuarioAComparar)
        {
            usuarioAComparar.Patentes.AddRange(usuarioDAL.ObtenerPatentesDeUsuario(usuarioAComparar.UsuarioId));

            usuarioAComparar.Patentes = usuarioAComparar.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
        }

        private static void RemoverIdsFamilias(bool requestFamiliaUsuario, int idAQuitar, List<Familia> familias)
        {
            if (requestFamiliaUsuario)
            {
                familias.RemoveAll(x => x.FamiliaId != idAQuitar);
            }
        }

        private static void CargarFamilias(Usuario usuario, List<int> familiaId)
        {
            foreach (var idfam in familiaId)
            {
                usuario.Familia.Add(new Familia() { FamiliaId = idfam });
            }
        }

        private void SetearPatentesUsuario(Usuario usuario, List<int> familiaId)
        {
            usuario.Patentes.AddRange(usuarioDAL.ObtenerPatentesDeUsuario(usuario.UsuarioId));

            usuario.Patentes.AddRange(familiaDAL.ObtenerPatentesDeFamilias(familiaId));

            usuario.Patentes = usuario.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
        }
    }
}