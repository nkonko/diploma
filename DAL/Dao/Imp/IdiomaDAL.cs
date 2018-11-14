namespace DAL.Dao.Imp
{
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;

    public class IdiomaDAL : BaseDao, IIdiomaDAL
    {
        public List<Idioma> ObtenerTodosLosIdiomas()
        {
            var query = "Select * from Idioma";

            return CatchException(() =>
            {
                return Exec<Idioma>(query);
            });
        }

        public List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idiomaId, string nombreForm)
        {
            var query = string.Format(
                "SELECT trad.* FROM Traduccion trad " +
                 "INNER JOIN Formularios ON Formularios.IdFormulario = trad.IdFormulario " +
                 "INNER JOIN Idioma ON Idioma.IdIdioma = trad.IdIdioma " +
                 "WHERE Idioma.IdIdioma = {0} AND Formularios.NombreFormulario = '{1}'",
                idiomaId,
                nombreForm);

            return CatchException(() =>
           {
               return Exec<TraduccionFormulario>(query);
           });
        }
    }
}