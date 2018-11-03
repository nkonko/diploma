namespace DAL.Dao.Imp
{
    using BE.Entidades;
    using DAL.Utils;
    using System.Collections.Generic;

    public class FormControlDAL : BaseDao, IFormControlDAL
    {
        public List<Patente> ObtenerPermisosFormularios()
        {
            var query = "SELECT IdPatente FROM FormularioPatente";

            return CatchException(() =>
            {
                return Exec<Patente>(query);
            });
        }
    }
}
