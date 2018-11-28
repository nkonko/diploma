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

        public void GuardarPatentesUsuario(List<int> patenteId, int usuarioId)
        {
            patenteDAL.GuardarPatentesUsuario(patenteId, usuarioId);
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

        public bool NegarPatente(int patenteId, int usuarioId)
        {
          return patenteDAL.NegarPatenteUsuario(patenteId, usuarioId);
        }

        public bool HabilitarPatente(int patenteId, int usuarioId)
        {
           return patenteDAL.HabilitarPatenteUsuario(patenteId, usuarioId);
        }

        public List<UsuarioPatente> ConsultarPatenteUsuario(int usuarioId)
        {
            return patenteDAL.ConsultarPatenteUsuario(usuarioId);
        }

        public void BorrarPatentesUsuario(List<int> ids, int usuarioId)
        {
            patenteDAL.BorrarPatentesUsuario(ids, usuarioId);
        }

        public bool EsPatenteEnUso(int patenteId, int usuarioId)
        {
            return patenteDAL.EsPatenteEnUso(patenteId, usuarioId);
        }

        public bool CheckeoDePatentesParaBorrar(Usuario usuario, bool requestFamilia = false, bool requestFamiliaUsuario = false, int idFamiliaAQuitar = 0)
        {
           return patenteDAL.CheckeoDePatentesParaBorrar(usuario, requestFamilia, requestFamiliaUsuario, idFamiliaAQuitar);
        }
    }
}
