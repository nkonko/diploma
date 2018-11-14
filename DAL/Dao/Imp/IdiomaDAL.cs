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
            var query = "SELECT Traduccion FROM Traduccion " +
                        "INNER JOIN Formularios ON Formularios.IdFormulario = Traduccion.IdFormulario " +
                        "INNER JOIN Idioma ON Idioma.IdIdioma = Traduccion.IdIdioma " +
                        "WHERE Idioma.IdIdioma = @idiomaId AND Formularios.NombreFormulario = '@nombreForm'";

            return CatchException(() =>
            {
                return Exec<TraduccionFormulario>(query, new { @idiomaId = idiomaId, @nombreForm = nombreForm });
            });
        }
    }
}