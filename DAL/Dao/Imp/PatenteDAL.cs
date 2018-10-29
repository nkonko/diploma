namespace DAL.Dao.Imp
{
    using System.Collections.Generic;
    using BE.Entidades;
    using DAL.Utils;

    public class PatenteDAL : BaseDao, IPatenteDAL
    {
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
            var queryString = $"INSERT INTO PatenteUsuario(IdPatente, IdUsuario) VALUE ({patenteId},{usuarioId})";

            CatchException(() =>
            {
                return Exec(queryString);
            });
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            var queryString = $"SELECT IdPatente FROM Patente WHERE Descripcion = {descripcion}";

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }
    }
}
