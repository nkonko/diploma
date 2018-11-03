namespace DAL.Dao.Imp
{
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

        public bool AsignarPatentes(int idFamilia, List<int> patentesId)
        {
            throw new System.NotImplementedException();
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

        public bool NegarPatentes(int idFamilia, List<int> patentesId)
        {
            throw new System.NotImplementedException();
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
    }
}
