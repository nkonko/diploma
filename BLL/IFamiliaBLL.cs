namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaBLL
    {
        List<Patente> ObtenerPatentesFamilia(int familiaId);
    }
}
