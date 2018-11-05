namespace DAL.Dao
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IPatenteDAL
    {
        void GuardarPatenteUsuario(int patenteId, int usuarioId);

        void NegarPatenteUsuario(List<int> patentesId, int usuarioId);

        List<Patente> Cargar();

        int ObtenerIdPatentePorDescripcion(string descripcion);

        bool BorrarPatente(int familiaId, int patenteId);

        bool AsignarPatente(int familiaId, int patenteId);

        bool ComprobarPatentesUsuario(int usuarioId);

        List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId);
    }
}