namespace BLL.Imp
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IPatenteBLL
    {
        void GuardarPatenteUsuario(int patenteId, int usuarioId);

        int ObtenerIdPatentePorDescripcion(string descripcion);

        List<Patente> Cargar();

        bool AsignarPatentes(int idFamilia, List<int> PatentesId);

        bool NegarPatentes(int idFamilia, List<int> PatentesId);
    }
}