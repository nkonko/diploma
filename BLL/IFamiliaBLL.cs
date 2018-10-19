namespace BLL
{
    using BE;
    using System.Collections.Generic;

    public interface IFamiliaBLL
    {
        List<Patente> ObtenerPatentesFamilia(int familiaId);
    }
}
