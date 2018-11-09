namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IPatenteBLL
    {
        void GuardarPatenteUsuario(int patenteId, int usuarioId);

        int ObtenerIdPatentePorDescripcion(string descripcion);

        List<Patente> Cargar();

        bool AsignarPatente(int familiaId, int patenteId);

        bool BorrarPatente(int familiaId, int patenteId);

        bool ComprobarPatentesUsuario(int usuarioId);

        List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId);

        bool NegarPatente(int patenteId, int usuarioId);

        bool HabilitarPatente(int patenteId, int usuarioId);

        List<UsuarioPatente> ConsultarPatenteUsuario(int usuarioId);
    }
}