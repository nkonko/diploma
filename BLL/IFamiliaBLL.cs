namespace BLL
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaBLL : ICRUD<Familia>
    {
        List<Patente> ObtenerPatentesFamilia(int familiaId);

        int ObtenerIdFamiliaPorDescripcion(string descripcion);

        void GuardarFamiliaUsuario(int familiaId, int usuarioId);

        int ObtenerIdFamiliaPorUsuario(int usuarioId);

        string ObtenerDescripcionFamiliaPorId(int familiaId);
    }
}
