namespace DAL.Dao.Imp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using BE.Entidades;
    using DAL.Utils;

    public class PatenteDAL : BaseDao, IPatenteDAL
    {
        private readonly IDigitoVerificador digitoVerificador;

        public PatenteDAL(IDigitoVerificador digitoVerificador)
        {
            this.digitoVerificador = digitoVerificador;
        }

        public bool AsignarPatente(int familiaId, int patenteId)
        {
            ////var queryString = $"INSERT INTO FamiliaPatente (IdFamilia, IdPatente) VALUES (@familiaId, @patentesId)";
            var asignado = false;

            CatchException(() =>
              {
                      asignado = Exec($"INSERT INTO FamiliaPatente (FamiliaId, IdPatente) VALUES ({familiaId}, {patenteId})");
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

        public void GuardarPatenteUsuario(int patenteId, int usuarioId)
        {
            var digitoVH = digitoVerificador.CalcularDVHorizontal(new List<string> { }, new List<int> { patenteId, usuarioId });
            var queryString = $"INSERT INTO UsuarioPatente(IdPatente, IdUsuario, Negada, DVH) VALUES ({patenteId},{usuarioId}, 0, {digitoVH})";

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public void NegarPatenteUsuario(List<int> patentesId, int usuarioId)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId)
        {
            var queryString = "SELECT FamiliaId, IdPatente FROM FamiliaPatente WHERE FamiliaId = @idFamilia";

            return CatchException(() =>
            {
                return Exec<FamiliaPatente>(queryString, new { @idFamilia = familiaId });
            });
        }
    }
}
