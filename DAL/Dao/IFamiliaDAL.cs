namespace DAL.Dao
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaDAL : ICRUD<Familia>
    {
        List<Patente> ObtenerPatentesFamilia(int familiaId);

        List<Patente> ObtenerPatentesFamilia(List<int> familiaId);

        void GuardarFamiliaUsuario(int familiaId, int usuarioId);

        int ObtenerIdFamiliaPorDescripcion(string descripcion);

        int ObtenerIdFamiliaPorUsuario(int usuarioId);

        string ObtenerDescripcionFamiliaPorId(int familiaId);

        bool ComprobarUsoFamilia(int familiaId);

        List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId);

        List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId);
    }
}