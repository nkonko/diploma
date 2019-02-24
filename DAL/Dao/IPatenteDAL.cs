namespace DAL.Dao
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IPatenteDAL
    {
        void GuardarPatentesUsuario(List<int> patenteId, int usuarioId);

        bool NegarPatenteUsuario(int patentesId, int usuarioId);

        bool HabilitarPatenteUsuario(int patenteId, int usuarioId);

        List<Patente> Cargar();

        int ObtenerIdPatentePorDescripcion(string descripcion);

        Patente ObtenerPatentePorDescripcion(string descripcion, int usuarioId);

        bool BorrarPatente(int familiaId, int patenteId);

        bool AsignarPatente(int familiaId, int patenteId);

        bool ComprobarPatentesUsuario(int usuarioId);

        List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId);

        List<UsuarioPatente> ConsultarPatenteUsuario(int usuarioId);

        void BorrarPatentesUsuario(List<int> ids, int usuarioId);

        bool CheckeoDePatentesParaBorrar(Usuario usuario, List<Usuario> usuariosGlobales, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool borrado = false, int quitarId = 0);

        List<Patente> ObtenerPatentesUsuario(int usuarioId);

        bool CheckeoUsuarioParaBorrar(Usuario usuario, List<Usuario> usuariosGlobales);

        bool CheckeoFamiliaParaBorrar(Familia familia, List<Usuario> usuariosGlobales);

        bool CheckeoPatenteParaBorrar(Patente patente, Usuario usuario, List<Usuario> usuariosGlobales, bool paraNegarOquitarDeFamilia = false);
    }
}