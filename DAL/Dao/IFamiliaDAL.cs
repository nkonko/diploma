namespace DAL.Dao
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaDAL : ICRUD<Familia>
    {
        List<Patente> ObtenerPatentesFamilia(int familiaId);

        List<Patente> ObtenerPatentesDeFamilias(List<int> familiaId);

        void GuardarFamiliasUsuario(List<int> familiasId, int usuarioId);

        int ObtenerIdFamiliaPorDescripcion(string descripcion);

        int ObtenerIdFamiliaPorUsuario(int usuarioId);

        string ObtenerDescripcionFamiliaPorId(int familiaId);

        bool ComprobarUsoFamilia(int familiaId);

        Familia ObtenerFamiliaConDescripcion(string descripcion);

        List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId);

        List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId);

        void BorrarFamiliaDeFamiliaPatente(int familiaId);

        void BorrarFamiliasUsuario(List<Familia> familias, int usuarioId);

        List<Familia> ObtenerFamiliasUsuario(int usuarioId);

        List<Usuario> ObtenerUsuariosPorFamilia(int familiaId);

        List<FamiliaUsuario> ObtenerTodasLasFamiliasYUsuarios();
    }
}