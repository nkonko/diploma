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

        bool NegarPatentes(int idFamilia, List<int> patentesId);

        bool AsignarPatentes(int idFamilia, List<int> patentesId);
    }
}