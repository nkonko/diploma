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
        private readonly IFamiliaDAL familiaDAL;

        public PatenteDAL(IDigitoVerificador digitoVerificador, IFamiliaDAL familiaDAL)
        {
            this.digitoVerificador = digitoVerificador;
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

        public List<Patente> ObtenerPatentesUsuario(int usuarioId)
        {
            return ConsultarPatenteUsuarioJOIN(usuarioId);
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

        public Patente ObtenerPatentePorDescripcion(string descripcion, int usuarioId)
        {
            var queryString = $"SELECT Patente.IdPatente, Patente.Descripcion, (SELECT negada FROM UsuarioPatente WHERE UsuarioId = {usuarioId} AND IdPatente = Patente.IdPatente) as Negada FROM Patente WHERE Descripcion = '{descripcion}'";

            return CatchException(() =>
            {
                return Exec<Patente>(queryString).FirstOrDefault();
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
            var queryString = "SELECT FamiliaPatente.FamiliaId, IdPatente FROM FamiliaPatente WHERE FamiliaId = @idFamilia";

            return CatchException(() =>
            {
                return Exec<FamiliaPatente>(queryString, new { @idFamilia = familiaId });
            });
        }

        public List<FamiliaPatente> ConsultarPatenteFamiliaJOIN(int familiaId)
        {
            var queryString = "SELECT FamiliaPatente.IdPatente, Descripcion FROM FamiliaPatente INNER JOIN Patente ON FamiliaPatente.IdPatente = Patente.IdPatente WHERE FamiliaId = @familiaId";

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

        public List<Patente> ConsultarPatenteUsuarioJOIN(int usuarioId)
        {
            var queryString = "SELECT UsuarioPatente.IdPatente, Descripcion FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE UsuarioId = @usuarioId";

            return CatchException(() =>
            {
                return Exec<Patente>(queryString, new { @usuarioId = usuarioId });
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

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, List<Usuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int quitarId = 0)
        {
            CheckeoUsuarioParaBorrar(usuario, usuariosGlobales);

            ///Si ningun usuario tiene patentes no se puede borrar ningun usuario
            if (!ComprobarTablaUsuarioPatente())
            {
                return false;
            }

            ////Si hay usuarios en la tabla de familias no puedo borrar a todas las familias paso 5
            ////NO SE ESTA IDENTIFICANDO QUE FAMILIA NO SE PUEDE BORRAR
            ////if (ComprobarUsuarioFamilia())
            ////{
            ////    return false;
            ////}

            ////CheckeoFamiliaParaBorrar(familiaABorrar);

            var diccionarioPatentes = new Dictionary<int, int>();
            List<Usuario> usuariosGlobal = usuariosGlobales;
            List<int> familiasIds = usuario.Familia.Select(familia => familia.FamiliaId).ToList();

            CargaUsuario(usuario, requestFamiliaUsuario, quitarId, usuariosGlobal);

            ////Revisar metodo que obtiene las patentes de las familias, que trae???? las patentes de una familia sola o de todas
            ////if (!esBorrado)
            ////{
            ////    if (usuarioDAL.ObtenerPatentesDeUsuario(usuario.UsuarioId).Count == familiaDAL.ObtenerPatentesDeFamilias(familiasIds).Count)
            ////    {
            ////        if (usuario.Patentes.Count == familiaDAL.ObtenerPatentesDeFamilias(familiasIds).Count)
            ////        {
            ////            return true;
            ////        }
            ////    }
            ////}

            CargarUsuariosGlobales(usuario, requestFamilia, usuariosGlobal);

            CargarDiccionario(usuario, diccionarioPatentes, usuariosGlobal);
            //// Uno de los problemas esta en este metodo no checkea una a una las patentes sino todo el diccionario y encima tiene un and habria que
            //// Separar las condiciones para hacer dos comprobaciones 
            if (diccionarioPatentes.Count > 0 && diccionarioPatentes.All(x => x.Value > 0))
            {
                return true;
            }

            return false;
        }

        public bool CheckeoUsuarioParaBorrar(Usuario usuarioABorrar, List<Usuario> usuariosGlobales)
        {
            var patentesSinUsuarios = new List<Patente>();

            if (usuarioABorrar.Patentes.Count <= 0)
            {
                if (usuarioABorrar.Familia.Count > 0)
                {
                    return CheckeoDeFamiliasEnUsuariosSinPatentes(usuarioABorrar, usuariosGlobales);
                }

                return true;
            }

            ///si no tiene familia estoy permitiendo que se borre esta mal
            if (usuarioABorrar.Familia.Count <= 0 && usuarioABorrar.Patentes.Count <= 0)
            {
                return true;
            }

            foreach (var familia in usuarioABorrar.Familia)
            {
                patentesSinUsuarios.AddRange(ComprobarPatentesDeUsuariosPropiosYGlobales(familia, usuariosGlobales));
            }

            patentesSinUsuarios.AddRange(usuarioABorrar.Patentes);

            usuariosGlobales.RemoveAll(usu => usu.UsuarioId == usuarioABorrar.UsuarioId);

            CargarPatentesUsuariosGloables(usuariosGlobales);

            foreach (var usuarioG in usuariosGlobales)
            {
                if (usuarioG.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(pat => usuarioG.Patentes.Any(patU => patU.IdPatente == pat.IdPatente));
                }
            }

            if (patentesSinUsuarios.Count <= 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckeoFamiliaParaBorrar(Familia familiaABorrar, List<Usuario> usuariosGlobales)
        {
            if (familiaABorrar.Patentes.Count <= 0)
            {
                return true;
            }

            if (!(familiaDAL.ObtenerUsuariosPorFamilia(familiaABorrar.FamiliaId).Count > 0))
            {
                return true;
            }

            if (familiaDAL.ObtenerUsuariosPorFamilia(familiaABorrar.FamiliaId).Count > 1)
            {
                return true;
            }

            var patentesSinUsuarios = ComprobarPatentesDeUsuariosPropiosYGlobales(familiaABorrar, usuariosGlobales);

            if (patentesSinUsuarios.Count <= 0)
            {
                return true;
            }

            return false;
        }

        public bool CheckeoPatenteParaBorrar(Patente patente, Usuario usuario, List<Usuario> usuariosGlobales, bool paraNegarOquitarDeFamilia = false)
        {
            if (!paraNegarOquitarDeFamilia)
            {
                ////si tiene la patente en su familia puedo borrarsela sin problema
                if (usuario.Familia.Select(fam => fam.Patentes.Any(patFU => patFU.IdPatente == patente.IdPatente)).FirstOrDefault())
                {
                    return true;
                }
            }

            var patentesSinUsuarios = new List<Patente>
            {
                patente
            };

            usuariosGlobales.RemoveAll(usu => usu.UsuarioId == usuario.UsuarioId);

            CargarPatentesUsuariosGloables(usuariosGlobales);

            foreach (var usuarioG in usuariosGlobales)
            {
                if (usuarioG.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(pat => usuarioG.Patentes.Any(patU => patU.IdPatente == pat.IdPatente));
                }
            }

            if (patentesSinUsuarios.Count <= 0)
            {
                return true;
            }

            return false;
        }

        private static void CargarDiccionario(Usuario usuario, Dictionary<int, int> diccionarioPatentes, List<Usuario> usuariosGlobal)
        {
            ////Si el usuario no tiene patentes no esta cargando ninguna al diccionario no deberia ser asi.
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

        private static void RemoverIdsFamilias(bool requestFamiliaUsuario, int quitarId, List<Familia> familias)
        {
            if (requestFamiliaUsuario)
            {
                familias.RemoveAll(x => x.FamiliaId != quitarId);
            }
        }

        private static void CargarFamilias(Usuario usuario, List<int> familiaId)
        {
            foreach (var idfam in familiaId)
            {
                usuario.Familia.Add(new Familia() { FamiliaId = idfam });
            }
        }

        private List<Patente> ComprobarPatentesDeUsuariosPropiosYGlobales(Familia familiaABorrar, List<Usuario> usuariosGlobales)
        {
            var usuarios = familiaDAL.ObtenerUsuariosPorFamilia(familiaABorrar.FamiliaId);

            usuarios.ForEach(usuario => usuario.Patentes = ObtenerPatentesUsuario(usuario.UsuarioId));

            var patentesSinUsuarios = new List<Patente>();

            foreach (var usuario in usuarios)
            {
                patentesSinUsuarios.AddRange(familiaABorrar.Patentes
                    .Where(patente => !usuario.Patentes
                    .Select(patenteUsu => patenteUsu.IdPatente)
                    .Contains(patente.IdPatente)).ToList());

                patentesSinUsuarios = patentesSinUsuarios.Distinct().ToList();
            }

            foreach (var usuario in usuarios)
            {
                if (usuario.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(patSinU => usuario.Patentes.Any(patU => patU.IdPatente == patSinU.IdPatente));
                }

                ////SE ESTAN BORRANDO TODOS LOS USUARIOS DE UNA FAMILIA POR ESO NO PERMITE BORRAR UNA FAMILIA QUE TIENEN 2 USUARIOS

                usuariosGlobales.RemoveAll(usu => usu.UsuarioId == usuario.UsuarioId);
            }

            CargarPatentesUsuariosGloables(usuariosGlobales);

            foreach (var usuario in usuariosGlobales)
            {
                if (usuario.Patentes.Where(pat => patentesSinUsuarios.Select(paten => paten.IdPatente).Contains(pat.IdPatente)).ToList().Count > 0)
                {
                    patentesSinUsuarios.RemoveAll(pat => usuario.Patentes.Any(patU => patU.IdPatente == pat.IdPatente));
                }
            }

            return patentesSinUsuarios;
        }

        private bool ComprobarUsuarioFamilia()
        {
            return familiaDAL.ObtenerTodasLasFamiliasYUsuarios().Count > 0;
        }

        private bool ComprobarTablaUsuarioPatente()
        {
            return ObtenerTodasLasPatentesYUsuarios().Count > 0;
        }

        private void CargaUsuario(Usuario usuario, bool requestFamiliaUsuario, int quitarId, List<Usuario> usuariosGlobal)
        {
            usuariosGlobal.RemoveAll(x => x.UsuarioId == usuario.UsuarioId);

            RemoverIdsFamilias(requestFamiliaUsuario, quitarId, usuario.Familia);

            SetearPatentesUsuario(usuario, usuario.Familia.Select(familia => familia.FamiliaId).ToList());
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
            }
        }

        private void CargarPatentesUsuariosGloables(List<Usuario> usuariosGlobal)
        {
            foreach (var usuarioAComparar in usuariosGlobal)
            {
                var familiasId = familiaDAL.ObtenerIdsFamiliasPorUsuario(usuarioAComparar.UsuarioId);
                foreach (var idfam in familiasId)
                {
                    usuarioAComparar.Patentes.AddRange(familiaDAL.ObtenerPatentesFamilia(idfam));
                    usuarioAComparar.Patentes = usuarioAComparar.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
                }
            }
        }

        private void SetearPatentesUsuario(Usuario usuario, List<int> familiaId)
        {
            ////usuario.Patentes.AddRange(usuarioDAL.ObtenerPatentesDeUsuario(usuario.UsuarioId));

            usuario.Patentes.AddRange(familiaDAL.ObtenerPatentesDeFamilias(familiaId));

            usuario.Patentes = usuario.Patentes.GroupBy(p => p.IdPatente).Select(grp => grp.First()).ToList();
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

        private bool CheckeoDeFamiliasEnUsuariosSinPatentes(Usuario usuarioABorrar, List<Usuario> usuariosGlobales)
        {
            usuariosGlobales.Remove(usuarioABorrar);

            if (usuariosGlobales.Any(usuarioG => usuarioG.Familia.Any(fam => usuarioABorrar.Familia.Any(uFam => uFam.FamiliaId == fam.FamiliaId))))
            {
                return true;
            }

            var patentesUsuario = usuarioABorrar.Familia.Select(fam => fam.Patentes).FirstOrDefault();
            var patentesUsuariosGlobales = usuariosGlobales.Select(ug => ug.Patentes).ToList();

            if (patentesUsuario.All(upat => patentesUsuariosGlobales.All(pats => pats.Any(pat => pat.IdPatente == upat.IdPatente))))
            {
                return true;
            }

            return false;
        }
    }
}