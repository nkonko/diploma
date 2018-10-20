namespace BLL
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaBLL : ICRUD<Familia>
    {
        List<Patente> ObtenerPatentesFamilia(int familiaId);
    }
}
