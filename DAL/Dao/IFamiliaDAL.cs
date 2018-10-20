namespace DAL.Dao
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaDAL : ICRUD<Familia>
    {
        List<Patente> ObtenerPatentesFamilia(int familiaId);
    }
}