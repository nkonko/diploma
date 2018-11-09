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
                "Select trad.* from traduccion trad inner join formulario form on form.IdFormulario = trad.IdFormulario" +
                "inner join idioma id on id.IdIdioma = trad.IdIdioma" +
                "where id.IdIdioma = @idiomaId and form.NombreFormulario = @nombreForm");

            return CatchException(() =>
            {
                return Exec<TraduccionFormulario>(query, new { @idiomaId = idiomaId, @nombreForm = nombreForm });
            });
        }
    }
}