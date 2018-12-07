namespace BLL
{
    using BE;
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFamiliaBLL : ICRUD<Familia>
    {
        List<Patente> ObtenerPatentesFamilia(List<int> familiaId);

        List<Patente> ObtenerPatentesFamilia(int familiaId);

        int ObtenerIdFamiliaPorDescripcion(string descripcion);

        void GuardarFamiliasUsuario(List<int> familiaId, int usuarioId);

        int ObtenerIdFamiliaPorUsuario(int usuarioId);

        List<int> ObtenerIdsFamiliasPorUsuario(int usuarioId);

        Familia ObtenerFamiliaConDescripcion(string descripcion);

        string ObtenerDescripcionFamiliaPorId(int familiaId);

        List<string> ObtenerDescripcionFamiliaPorId(List<int> familiaId);

        bool ComprobarUsoFamilia(int familiaId);

        void BorrarFamiliasUsuario(List<Familia> familias, int usuarioId);

        List<Familia> ObtenerFamiliasUsuario(int usuarioId);

        List<Usuario> ObtenerUsuariosPorFamilia(int familiaId);
    }
}
