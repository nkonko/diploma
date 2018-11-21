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

        public void CheckeoDePatentesParaBorrar(Usuario usuario)
        {
            var queryselect = "SELECT * FROM UsuarioPatente";
            var listaUsuariosPatentes = new List<UsuarioPatente>();

            CatchException(() =>
            {
                listaUsuariosPatentes = Exec<UsuarioPatente>(queryselect);
            });

            var patentesUsuarios = listaUsuariosPatentes.ToList();

            //Todas las patentes en patentesUsuarios
            var todasLaspatentes = patentesUsuarios.Select(x => x.IdPatente);
            //Las patentes que tiene asignada el usuario
            var patUsu = patentesUsuarios.Where(u => u.UsuarioId == usuario.UsuarioId).Select(x => x.IdPatente).OrderBy(x => x).ToList();

            //Deberiamos verificar que las patentes asignadas al usuario sigan existiendo en la tabla cruzada
            // 1 - Borramos de la lista original el usuario seleccionado
            patentesUsuarios.RemoveAll(x => x.UsuarioId == usuario.UsuarioId);
            // 2 - Chequear que sigan existiendo sus patentes, es decir, que sigan estando asignadas
            var existen = patentesUsuarios.FindAll(x => patUsu.Any(y => y == x.IdPatente)).Distinct().Count() == patUsu.Count;


            var listapatente = Cargar().Select(x => x.IdPatente).ToList();
            //patForm.Exists(item => patUsu.Patentes.Select(item2 => item2.IdPatente).Contains(item.IdPatente)

            var pete = todasLaspatentes.Intersect(listapatente);
            var check = pete.Count() == listapatente.Count();



            //var queryUsuariosPatentes = "SELECT COUNT(*) FROM (SELECT IdPatente from UsuarioPatente group by IdPatente) AS UsuarioPatente";
            //var queryPatentes = "SELECT COUNT(IdPatente) FROM Patente";
            //var queryUsuarios = "SELECT UsuarioId FROM Usuarios";

            //var usuarioPatentes = 0;
            //var patentes = 0;
            //var usuarios = new List<int>();

            //CatchException(() =>
            //{
            //    usuarioPatentes = Exec<int>(queryUsuariosPatentes)[0];
            //});

            //CatchException(() =>
            //{
            //    patentes = Exec<int>(queryPatentes)[0];
            //});




            //CatchException(() =>
            //{
            //    usuarios = Exec<int>(queryUsuarios);
            //});

            //if (usuarioPatentes <= patentes)
            //{

            //}
        }
    }
}
