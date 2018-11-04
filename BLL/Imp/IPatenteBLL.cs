namespace BLL.Imp
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IPatenteBLL
    {
        void GuardarPatenteUsuario(int patenteId, int usuarioId);

        int ObtenerIdPatentePorDescripcion(string descripcion);

        List<Patente> Cargar();

        bool AsignarPatentes(int familiaId, List<int> patentesId);

        bool NegarPatentes(int familiaId, List<int> patentesId);

        bool ComprobarPatentesUsuario(int usuarioId);
    }
}