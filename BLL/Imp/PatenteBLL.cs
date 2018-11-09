namespace BLL.Imp
{
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class PatenteBLL : IPatenteBLL
    {
        private readonly IPatenteDAL patenteDAL;

        public PatenteBLL(IPatenteDAL patenteDAL)
        {
            this.patenteDAL = patenteDAL;
        }

        public bool AsignarPatente(int familiaId, int patenteId)
        {
            return patenteDAL.AsignarPatente(familiaId, patenteId);
        }

        public List<Patente> Cargar()
        {
            return patenteDAL.Cargar();
        }

        public void GuardarPatenteUsuario(int patenteId, int usuarioId)
        {
            patenteDAL.GuardarPatenteUsuario(patenteId, usuarioId);
        }

        public bool BorrarPatente(int familiaId, int patenteId)
        {
            return patenteDAL.BorrarPatente(familiaId, patenteId);
        }

        public int ObtenerIdPatentePorDescripcion(string descripcion)
        {
            return patenteDAL.ObtenerIdPatentePorDescripcion(descripcion);
        }

        public bool ComprobarPatentesUsuario(int usuarioId)
        {
            return patenteDAL.ComprobarPatentesUsuario(usuarioId);
        }

        public List<FamiliaPatente> ConsultarPatenteFamilia(int familiaId)
        {
            return patenteDAL.ConsultarPatenteFamilia(familiaId);
        }

        public void NegarPatente(int patenteId, int usuarioId)
        {
            patenteDAL.NegarPatenteUsuario(patenteId, usuarioId);
        }

        public void HabilitarPatente(int patenteId, int usuarioId)
        {
            patenteDAL.HabilitarPatenteUsuario(patenteId, usuarioId);
        }
    }
}
