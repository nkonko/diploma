namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IPatenteBLL
    {
        void GuardarPatentesUsuario(List<int> patenteId, int usuarioId);

        int ObtenerIdPatentePorDescripcion(string descripcion);

        List<Patente> Cargar();

        bool AsignarPatente(int familiaId, int patenteId);

        bool BorrarPatente(int familiaId, int patenteId);

        bool ComprobarPatentesUsuario(int usuarioId);

        List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId);

        bool NegarPatente(int patenteId, int usuarioId);

        bool HabilitarPatente(int patenteId, int usuarioId);

        List<UsuarioPatente> ConsultarPatenteUsuario(int usuarioId);

        void BorrarPatentesUsuario(List<int> ids, int usuarioId);

        bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false, bool esBorrado = false, int idFamiliaAQuitar = 0);
    }
}