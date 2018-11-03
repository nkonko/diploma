namespace DAL.Dao.Imp
{
    using System.Collections.Generic;
    using BE.Entidades;

    public interface IFormControlDAL
    {
        List<Patente> ObtenerPermisosFormularios();
    }
}