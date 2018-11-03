namespace BLL.Imp
{
    using System.Collections.Generic;
    using BE.Entidades;
    using DAL.Dao;

    public class PatenteBLL : IPatenteBLL
    {
        private readonly IPatenteDAL patenteDAL;

        public PatenteBLL(IPatenteDAL patenteDAL)
        {
            this.patenteDAL = patenteDAL;
        }

        public bool AsignarPatentes(int idFamilia, List<int> patentesId)
        {
           return patenteDAL.AsignarPatentes(idFamilia, patentesId);
        }

        public List<Patente> Cargar()
        {
            return patenteDAL.Cargar();
        }

        public void GuardarPatenteUsuario(int patenteId, int usuarioId)
        {
            patenteDAL.GuardarPatenteUsuario(patenteId, usuarioId);
        }

        public void NegarPatenteUsuario(List<int> patentesId, int usuarioId)
        {
            patenteDAL.NegarPatenteUsuario(patentesId, usuarioId);
        }

        public bool NegarPatentes(int idFamilia, List<int> patentesId)
        {
            return patenteDAL.NegarPatentes(idFamilia, patentesId);
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return patenteDAL.ObtenerIdPatentePorDescripcion(descripcion);
        }
    }
}
